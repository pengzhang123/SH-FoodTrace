using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WL.NTAG203.Reader;

namespace FoodTrace.Forms.Helpers
{
    public class ReaderHelper
    {
       
        /// <summary>
        /// 串口名称
        /// </summary>
        public string PortName;

        /// <summary>
        /// 串口打开句柄
        /// </summary>
        public IntPtr m_ComHandle;

        /// <summary>
        /// 设备地址
        /// </summary>
        public int m_gAddress = 00;

        /// <summary>
        /// 定义读写器
        /// </summary>
        public WLNTAG203Reader _wlNTAG203Reader = WLNTAG203Reader.Instance();

        public List<SerilaPortDto> GetPortList()
        {
            var list = new List<SerilaPortDto>();

            try
            {
                var portArry = System.IO.Ports.SerialPort.GetPortNames();

                if (portArry.Length > 0)
                {
                    for (int i =1; i <= portArry.Length; i++)
                    {
                        var model = new SerilaPortDto();
                        model.PortId = i;
                        model.PortName = portArry[i];
                    }
                }
            }
            catch (Exception)
            {
               
            }

            return list;

        }
        public ReaderHelper()
        {
            //PortName = System.IO.Ports.SerialPort.GetPortNames()[0];
        }
        public string Read(string portName)
        {
            PortName = portName;
            Connect();
            byte mode = 0x52;
            byte cmd = 0x00;
            string Buffer = string.Empty;
            try
            {
                //if (kryrbtn_typeA_Idle.Checked)
                // mode = 0x26;

                if (_wlNTAG203Reader.MF_GET_SNR(m_ComHandle, m_gAddress, mode, cmd, ref Buffer) == 0)
                {
                    return Buffer.Replace(" ", "").Substring(2);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("krybtn_typeA_Query_Click.Error:" + ex.Message);
            }
            finally
            {
                DisConnect();
            }
            return string.Empty;
        }

        private void Connect()
        {
            int iCom, iBautrate;
            string sPortName;
            try
            {

                sPortName = PortName;

                iCom = int.Parse(sPortName.Substring(3));
                iBautrate = 9600;

                //读写器设备地址
                m_gAddress = (byte)ConvertHelper.HexStringToInt("00");

                m_ComHandle = _wlNTAG203Reader.OpenComm(iCom, iBautrate);

                if (m_ComHandle.ToInt32() > 0)
                {
                    string Buffer = string.Empty;
                    string VersionNum = string.Empty;
                    int ReaderAddress = 0;
                    //序号及版本
                    if (_wlNTAG203Reader.GetSerNum(m_ComHandle, m_gAddress, ref ReaderAddress, ref Buffer) != 0 ||
                    _wlNTAG203Reader.GetVersionNum(m_ComHandle, m_gAddress, ref VersionNum) != 0)
                    {
                        //失败则关闭串口
                        bool bReuslt = _wlNTAG203Reader.CloseComm(m_ComHandle);
                        MessageBox.Show("串口打开失败 ");
                    }
                   
                }
                else
                {
                    MessageBox.Show("串口打开失败 ");
                }



            }
            catch (Exception ex)
            {
                Console.WriteLine("krybtn_connect_Click.Error:" + ex.Message);
            }
        }

        private void DisConnect()
        {
            try
            {
                if (m_ComHandle.Equals(-1))
                {
                    return;
                }
                bool bReuslt = _wlNTAG203Reader.CloseComm(m_ComHandle);
                if (bReuslt)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("krybtn_disconnect_Click.Error:" + ex.Message);
            }
        }
    }

    public class SerilaPortDto
    {
       public int PortId { get; set; }

        public string PortName { get; set; }
    }
}
