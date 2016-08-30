using System.Threading;
using Caliburn.Micro;
using FoodTrace.Forms.Helpers;
using FoodTrace.Forms.Models;
using FoodTrace.Forms.Views;
using FoodTrace.IService;
using FoodTrace.Model;
using FoodTrace.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WL.NTAG203.Reader;

namespace FoodTrace.Forms.ViewModels
{
    [Export(typeof(ChipEditViewModel))]
    public class ChipEditViewModel : ViewAware
    {
        private ITidService iTidService = new TidService();
        private ICompanyService iCompanyService = new CompanyService();
        public TIDModel Model { get; set; }
        public EditMode Mode { get; set; }
        SynchronizationContext m_SyncContext = null;
        public void Save()
        {
            if (Model.ChipCode.Length != 8)
            {
                MessageBox.Show("该芯片不合法");
                return;
            }
            if (Mode == EditMode.CREATE)
            {
                if (iTidService.GetTidByChipCode(Model.ChipCode) != null) {
                    MessageBox.Show("该芯片已经存在");
                    return ;
                }
                iTidService.InsertSingleTid(Model);
            }
            else if (Mode == EditMode.UPDATE)
            {
                iTidService.UpdateSingleTid(Model);
            }
            var win = GetView() as System.Windows.Window;
            if (win != null)
            {
                win.DialogResult = true;
                win.Close();
            }
        }

        public void Cancel()
        {
            var win = GetView() as System.Windows.Window;
            if (win != null)
            {
                win.DialogResult = false;
                win.Close();
            }
        }

        public ChipEditView ChipEditViewSelf;
        public BindableCollection<CompanyModel> Companys { get; set; }

        public void LoadUserControl(ChipEditView view)
        {
            m_SyncContext = SynchronizationContext.Current;

            ChipEditViewSelf = view;

            var companys = iCompanyService.GetPagerCompany("", 1, 100);
            Companys = new BindableCollection<CompanyModel>(companys);
            NotifyOfPropertyChange(() => Companys);
            if (Mode == EditMode.CREATE)
            {
                ReaderHelper reader1 = new ReaderHelper();
                var portName = view.cbPort.Text;
                Model.ChipCode = reader1.Read(portName);
                var maxId = MaxId;
                CPRODUCTEPC96 pro96 = new CPRODUCTEPC96();
                //商品类别
                pro96.GoodsType = "3";
                //商品代号
                pro96.GoodsCode = maxId;
                //生成日期
                pro96.TagDate = DateTime.Now.ToString("yyyy年MM月dd日");
                //销售店号
                pro96.BusinessCode = maxId;
                //商品号型
                pro96.GoodsSize = "255";
                //序号
                pro96.SeqNo = maxId;

                pro96.EpcType = "4";
                Model.Epc = pro96.PackEpc();
                NotifyOfPropertyChange(() => Model);
            }


            Task.Factory.StartNew(() =>
            {
                m_SyncContext.Post(AsyncGetPortList, view);
            }); 
             
         

        }


        private void AsyncGetPortList(object data)
        {
            ReaderHelper reader = new ReaderHelper();

            ChipEditView view = (ChipEditView) data;
            var list = reader.GetPortList();
            view.cbPort.ItemsSource = list;
            view.cbPort.DisplayMemberPath = "PortId";
            view.cbPort.SelectedValuePath = "PortName";
        }
        public string MaxId
        {
            get
            {
                int maxId = 10000;
                string path = "maxid";

                if (File.Exists(path))
                {
                    using (TextReader reader = new StreamReader(path))
                    {
                        string txt = reader.ReadToEnd();
                        maxId = SerializeUtilities.Desrialize<int>(txt);
                    }
                }
                
                int newValue = maxId + 1;

                using (TextWriter writer = new StreamWriter(path,false))
                {
                    string txt = SerializeUtilities.Serialize<int>(newValue);
                    writer.Write(txt);
                }

                return maxId.ToString();
            }
        }
    }
}
