using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Globalization;
using rfidLink.Extend;

namespace FoodTrace.Hardware
{
    /// <summary>
    /// 海康桌面(D500)发卡器
    /// </summary>
    [ClassInterface(ClassInterfaceType.None)]
    public class HKReader:IHKReader
    { //自定义 函数内使用
        #region 自定义 函数内使用

        /// <summary>
        /// 操作发卡器接口
        /// </summary>
        private LinkageExtend _hkReader = new LinkageExtend();

        /// <summary>
        /// 本次调用发卡器对像信息
        /// </summary>
        private RadioInformation _radioInfo;

        /// <summary>
        /// 读写器对像列表
        /// </summary>
        private List<RadioInformation> _lstRadios;

        /// <summary>
        /// 定义读写器封装接口变量
        /// </summary>
        private static HKReader _instance;

        /// <summary>
        /// 读写器串口名称 COM3
        /// </summary>
        private string _sReaderComName = "COM5";

        /// <summary>
        /// 访问密码
        /// </summary>
        private string _saccessPassword = "00000000";

        /// <summary>
        /// 销毁密码
        /// </summary>
        private string _skillPassword = "00000000";

        /// <summary>
        /// 传递EPC内容
        /// </summary>
        private string _stag;

        /// <summary>
        /// 处理盘点模式下识别EPC信息
        /// </summary>
        private string _sInventoryTag;

        /// <summary>
        /// 是否过滤 true:过滤;false:不过滤
        /// </summary>
        private bool _isChoose;

        /// <summary>
        /// 处理手动读EPC调用盘点模式下EPC
        /// </summary>
        private bool _isInventoryEpc = false;

        /// <summary>
        /// 是否使用盘点模式返回事件,true:表示盘点模式;false:表示读取EPC模式盘点
        /// </summary>
        private bool _isInventoryFlg = false;

        /// <summary>
        /// 匹配方式 0:正常 1:反向
        /// </summary>
        private int _iMatchType = 0;

        /// <summary>
        /// 表示函数内部执行EPC过滤 true:已执行过滤待去除过滤;false:表示无过滤
        /// </summary>
        private bool _isMaskFlg = false;

        #endregion

        //定义发卡器接口发布使用变量
        #region 定义发卡器接口发布使用变量
        /// <summary>
        /// 设置或读取 读写器串口名称
        /// </summary>
        public string ReaderComName
        {
            get
            {
                return _sReaderComName;
            }
            set
            {
                _sReaderComName = value;
            }
        }

        /// <summary>
        /// 读取或设置访问密码
        /// </summary>
        public string AccessPassword
        {
            get
            {
                return _saccessPassword;
            }
            set
            {
                _saccessPassword = value;
            }
        }

        /// <summary>
        /// 读取或设置销毁密码
        /// </summary>
        public string KillPassword
        {
            get
            {
                return _skillPassword;
            }
            set
            {
                _skillPassword = value;
            }
        }

        /// <summary>
        /// 读取或设置 是否过滤 true:过滤;false:不过滤
        /// </summary>
        public bool Choose
        {
            get
            {
                return _isChoose;
            }
            set
            {
                _isChoose = value;
            }
        }

        /// <summary>
        /// 传递跟据EPC信息过滤识别EPC信息
        /// </summary>
        public string TagEpc
        {
            get
            {
                return _stag;
            }
            set
            {
                _stag = value;
            }
        }

        /// <summary>
        /// 处理盘点模式下识别EPC信息
        /// </summary>
        public string InventoryTag
        {
            get
            {
                return _sInventoryTag;
            }
            set
            {
                _sInventoryTag = value;
            }
        }

        /// <summary>
        /// 匹配方式 0:正常 1:反向
        /// </summary>
        public int MatchType
        {
            get
            {
                return _iMatchType;
            }
            set
            {
                _iMatchType = value;
            }
        }

        /// <summary>
        /// 定义事件用于回调读取EPC信息
        /// </summary>
        /// <param name="epc">EPC信息</param>
        public delegate void InventoryPacketEventDelegate(string epc);

        /// <summary>
        /// 定义处理EPC回调
        /// </summary>
        public event InventoryPacketEventDelegate InventoryPacketEvent;

        #endregion

        /// <summary>
        /// 初使化对像
        /// </summary>
        public HKReader()
        {
            try
            {
                this._hkReader.Initialization();
                _hkReader.RadioInventory -= new EventHandler<RadioInventoryEventArgs>(wl_RadioInventory);
                _hkReader.RadioInventory += new EventHandler<RadioInventoryEventArgs>(wl_RadioInventory);
                InventoryPacketEvent = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("WLHKReader.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 控件释放
        /// </summary>
        ~HKReader()
        {
            try
            {
                Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("~WLHKReader.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            try
            {
                Close();
                _hkReader = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dispose.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 获取本地读写器对应的串列表
        /// </summary>
        /// <returns></returns>
        public string[] GetReaderList()
        {
            string[] ports = null;
            _lstRadios = _hkReader.GetRadioEnumeration();
            if (_lstRadios != null)
            {
                ports = new string[_lstRadios.Count];
                int i = 0;
                foreach (RadioInformation r in _lstRadios)
                {
                    ports[i] = r.radioHandle.ToString();
                    i++;
                }
                ReaderComName = ports[0];
            }
            return ports;
        }

        /// <summary>
        /// 打开桌面发卡器
        /// </summary>
        /// <returns></returns>
        public bool Open()
        {
            bool bResult = true;
            try
            {
                if (_lstRadios != null && _lstRadios.Count > 0)
                {
                    foreach (RadioInformation r in _lstRadios)
                    {
                        if (r.radioHandle.ToString().Equals(ReaderComName))
                        {
                            _radioInfo = r;
                            break;
                        }
                    }
                    operResult result = _hkReader.Connect(_radioInfo.radioHandle);
                    if (result != operResult.Ok)
                    {
                        bResult = false;
                    }
                }
                else
                {
                    bResult = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Open.Error:" + ex.Message);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 判断读写器是否连接成功
        /// </summary>
        /// <returns>true:表示打开成功;false:表示打开失败</returns>
        public bool IsOpen()
        {
            bool bResult = false;
            connectStatus status; //状态
            try
            {
                operResult result = _hkReader.GetRadioConnectStatus(_radioInfo.radioHandle, out status);
                if (result == operResult.Ok)
                {
                    if (status == connectStatus.Connected)
                    {
                        bResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("IsOpen.Error:" + ex.Message);
            }

            return bResult;
        }

        /// <summary>
        /// 关闭桌面发卡器
        /// </summary>
        /// <returns></returns>
        public bool Close()
        {
            bool bResult = true;
            try
            {
                operResult result = _hkReader.Disconnect(_radioInfo.radioHandle);
                if (result != operResult.Ok)
                {
                    bResult = false;
                }
            }
            catch (Exception ex)
            {
                bResult = false;
                Console.WriteLine("Close.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 读取访问密码
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到访问密码信息</returns>
        public string ReadAccessPassWord()
        {
            string sResult = string.Empty;
            try
            {
                sResult = ReadBank(0, 2, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadAccessPassWord.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 获取访问密码
        /// </summary>
        /// <returns></returns>
        public string GetAccessPassWord()
        {
            string sResult = string.Empty;
            uint accessPassword = 0;
            try
            {
                //设置过滤
                setMaskCriteria();
                _hkReader.GetTagAccessPassword(_radioInfo.radioHandle, accessPassword);
                sResult = accessPassword.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetAccessPassWord.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 读取销毁密码
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到销毁密码信息</returns>
        public string ReadKillPassWord()
        {
            string sResult = string.Empty;
            try
            {
                sResult = ReadBank(0, 0, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadKillPassWord.Error:" + ex.Message);
            }
            return sResult;

        }

        /// <summary>
        /// 读取销毁密码
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到销毁密码信息</returns>
        public string GetKillPassWord()
        {
            string sResult = string.Empty;
            uint accesspassword = 0;
            try
            {
                //设置过滤
                setMaskCriteria();
                validateHex_uint(this.AccessPassword, out accesspassword);
                List<KillPasswordResult> lstKill = _hkReader.GetTagKillPassword(_radioInfo.radioHandle, accesspassword);
                foreach (KillPasswordResult k in lstKill)
                {
                    sResult = k.killPasswordValue.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetKillPassWord.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 识别标签信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void wl_RadioInventory(object sender, RadioInventoryEventArgs e)
        {
            InventoryTag = string.Empty;
            for (int i = 0; i < e.tagInfo.epclength; i++)
            {
                InventoryTag += String.Format("{0:X4}", e.tagInfo.epc[i]);
            }
            //处理盘点模式下，事件回调
            if (_isInventoryFlg)
            {
                if (InventoryPacketEvent != null)
                {
                    InventoryPacketEvent(InventoryTag);
                }
            }
            else
            {
                //有EPC信息，状态设为TRUE
                if (!string.IsNullOrEmpty(InventoryTag))
                {
                    _isInventoryEpc = true;
                }
            }
        }

        /// <summary>
        /// 盘点模式启动
        /// </summary>
        /// <returns>true:表示启动成功;false:表示失败</returns>
        public bool Start()
        {
            bool bResult = false;
            try
            {
                operResult result = this._hkReader.StartInventory(this._radioInfo.radioHandle);
                if (result == operResult.Ok)
                {
                    _isInventoryFlg = true;
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Start.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 盘点模式停止
        /// </summary>
        /// <returns>true:表示停止成功;false:表示失败</returns>
        public bool Stop()
        {
            bool bResult = false;
            try
            {
                operResult result = _hkReader.StopInventory(_radioInfo.radioHandle);
                if (result == operResult.Ok)
                {
                    _isInventoryFlg = false;
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Stop.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 读取EPC 单模式
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到EPC信息</returns>
        public string ReadEpc()
        {
            string sResult = string.Empty;
            InventoryTag = string.Empty;
            DateTime dtstart = DateTime.Now;
            try
            {
                //设置盘点模式方式标志
                _isInventoryFlg = false;
                //设置过滤
                setMaskCriteria();
                _isInventoryEpc = false;//读取状态设为False
                operResult result = this._hkReader.StartInventory(this._radioInfo.radioHandle);
                if (result != operResult.Ok)
                {
                    return sResult;
                }
                System.Threading.Thread.Sleep(200);
                while (true)
                {
                    if (this._isInventoryEpc)
                    {
                        break;
                    }
                    if (dtstart.AddSeconds(5) > DateTime.Now)
                    {
                        break;
                    }
                    System.Threading.Thread.Sleep(2);
                }

                //停止
                result = _hkReader.StopInventory(_radioInfo.radioHandle);
                if (result != operResult.Ok)
                {
                }

                sResult = InventoryTag;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadEpc.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 读取EPC(盘点一次) 
        /// </summary>
        /// <param name="tid">返回盘点到的TID信息</param>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到EPC信息</returns>
        public string ReadEpcOnce(out string tid)
        {
            string sResult = string.Empty;
            string sEPC = string.Empty;
            string sTID = string.Empty;
            try
            {
                List<InventoryTagInfo> inventoryResults = null;
                //设置过滤
                setMaskCriteria();
                operResult result = this._hkReader.InventoryOnce(this._radioInfo.radioHandle, out inventoryResults);
                if (result != operResult.Ok)
                {
                    tid = "";
                    return sResult;
                }
                //盘点一次获取EPC信息和TID      
                if (inventoryResults != null || inventoryResults.Count > 0)
                {
                    for (int i = 0; i < inventoryResults[0].epclength; i++)
                    {
                        sEPC += String.Format("{0:X4}", inventoryResults[0].epc[i]);
                    }

                    for (int i = 0; i < inventoryResults[0].tidlength; i++)
                    {
                        sTID += String.Format("{0:X4}", inventoryResults[0].tid[i]);
                    }
                }
                sResult = sEPC;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadEpcOnce.Error:" + ex.Message);
            }
            tid = sTID;
            return sResult;
        }

        /// <summary>
        /// 读取EPC信息
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        public string ReadEpcBySetAndLen(byte offset, byte dataLen)
        {
            return ReadBank(1, offset, dataLen);
        }

        /// <summary>
        /// 读取TID
        /// </summary>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        public string ReadTid(byte dataLen)
        {
            return ReadBank(2, 0, dataLen);
        }

        /// <summary>
        /// 读取用户区
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        public string ReadUser(byte offset, byte dataLen)
        {
            return ReadBank(3, offset, dataLen);
        }

        /// <summary>
        /// 读Bank
        /// </summary>
        /// <param name="bank">Bank(0=Reserved  1=EPC  2=TID  3=USER)</param>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        public string ReadBank(byte bank, byte offset, byte dataLen)
        {
            string sResult = string.Empty;
            try
            {

                //设置过滤
                setMaskCriteria();

                ReadParms parm = new ReadParms();
                switch (bank)
                {
                    case 0: //访问密码区
                        parm.memBank = MemoryBank.Reserved;
                        break;
                    case 1://EPC
                        parm.memBank = MemoryBank.EPC;
                        break;
                    case 2://TID
                        parm.memBank = MemoryBank.TID;
                        break;
                    case 3://USER
                        parm.memBank = MemoryBank.USER;
                        break;
                    default:
                        parm.memBank = MemoryBank.EPC;
                        break;
                }

                uint accesspassword = 0;
                validateHex_uint(this.AccessPassword, out accesspassword);
                parm.accesspassword = accesspassword;
                parm.offset = (ushort)offset;
                parm.length = (ushort)dataLen;

                List<ReadResult> readResults;
                operResult result = this._hkReader.TagInfoRead(this._radioInfo.radioHandle, parm, out readResults);
                if (result == operResult.Ok)
                {
                    foreach (ReadResult readInfo in readResults)
                    {
                        string strTemp = string.Empty;
                        if (readInfo.result == tagMemoryOpResult.Ok)
                        {
                            //去除更一种处理方式EPC
                            #region 去除更一种处理方式EPC
                            //for (int i = 0; i < readInfo.epclength; i++)
                            //{
                            //    strTemp += String.Format("{0:X4}", readInfo.epc[i]);
                            //}
                            #endregion

                            //读取信息内容
                            for (int i = 0; i < readInfo.datalength; i++)
                            {
                                strTemp += String.Format("{0:X4}", readInfo.readData[i]);
                            }
                        }
                        else
                        {
                            strTemp = "";
                        }

                        //EPC参数信息取值
                        sResult = strTemp;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadBank.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 设置过滤
        /// </summary>
        private void setMaskCriteria()
        {
            try
            {
                if (!Choose && !_isMaskFlg)
                {//表示没有过滤
                    return;
                }

                SingulationCriteria criteria;

                _hkReader.Get18K6CPostMatchCriteria(this._radioInfo.radioHandle, out criteria);
                //表示过滤
                if (Choose)
                {
                    criteria.status = SingulationCriteriaStatus.Enabled;
                    //正向过滤与反向过滤
                    if (MatchType.Equals(0))
                    {
                        criteria.match = matchType.Regular;
                    }
                    else
                    {
                        criteria.match = matchType.Inverse;
                    }
                    //EPC启始位
                    criteria.offset = ((uint)0) * 0x10;
                    //总长
                    criteria.count = ((uint)(TagEpc.Length / 4)) * 0x10;
                    //数据内容
                    for (int i = 0; i < (TagEpc.Length / 2); i++)
                    {
                        if (!ValidateHex_byte(TagEpc.Substring(i * 2, 2), out criteria.mask[i]))
                        {
                            return;
                        }
                    }
                    _isMaskFlg = true;
                }
                else
                {
                    criteria.status = SingulationCriteriaStatus.Disabled;
                    _isMaskFlg = false;
                }
                operResult oResult = _hkReader.Set18K6CPostMatchCriteria(this._radioInfo.radioHandle, criteria);
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetMaskCriteria.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 读用户区扩展
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        public string ReadUserBankParmsEx(byte offset, byte dataLen)
        {
            string sResult = string.Empty;
            try
            {

                //设置过滤
                setMaskCriteria();
                this._hkReader.SetCurrentLinkProfile(this._radioInfo.radioHandle, 3);
                ReadUserBankParmsEx parm = new ReadUserBankParmsEx();
                uint accesspassword = 0;
                validateHex_uint(this.AccessPassword, out accesspassword);
                parm.accesspassword = accesspassword;
                parm.offset = (ushort)offset;
                parm.length = (ushort)dataLen;
                parm.tidlength = 6;

                ReadUserBankParmsEx readpp = (ReadUserBankParmsEx)parm;
                List<ReadUserBankExResult> results;

                operResult result = _hkReader.TagInfoReadUserBankEx(_radioInfo.radioHandle, readpp, out results);
                if (result == operResult.Ok)
                {
                    foreach (ReadUserBankExResult readInfo in results)
                    {
                        string strTemp = string.Empty;
                        if (readInfo.result == tagMemoryOpResult.Ok)
                        {

                            for (int i = 0; i < readInfo.userDatalength; i++)
                            {
                                strTemp += String.Format("{0:X4}", readInfo.userData[i]);
                            }
                        }
                        else
                        {
                            strTemp = "";
                        }

                        sResult = strTemp;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("ReadUserBankParmsEx.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 写访问密码
        /// </summary>
        /// <param name="accessPwd">传递修改的访问密码 2个字</param>
        /// <returns>true:表示写成功;false:表示写入失败</returns>
        public bool WriteAccessPassWord(string accessPwd)
        {
            bool bResult = false;
            uint accesspassword = 0;
            uint accessnewpassword = 0;
            try
            {
                //设置过滤
                setMaskCriteria();

                validateHex_uint(this.AccessPassword, out accesspassword);

                validateHex_uint(accessPwd, out accessnewpassword);

                List<TagOperResult> tagOperResults;
                operResult result = _hkReader.ModifyTagAccessPassword(_radioInfo.radioHandle, accesspassword, accessnewpassword, out tagOperResults);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("WriteAccessPassWord.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 修改访问密码
        /// </summary>
        /// <param name="accessPwd"></param>
        /// <returns></returns>
        public bool ModifyAccessPassWord(string accessPwd)
        {
            bool bResult = false;
            try
            {
                bResult = WriteBank(0, 2, 2, accessPwd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ModifyAccessPassWord.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 写销毁密码
        /// </summary>
        /// <param name="killPwd">传递修改的销毁密码 2个字</param>
        /// <returns>true:表示写成功;false:表示写入失败</returns>
        public bool WriteKillPassWord(string killPwd)
        {
            bool bResult = false;
            uint accesspassword = 0;
            uint accessnewpassword = 0;
            try
            {
                //设置过滤
                setMaskCriteria();
                validateHex_uint(this.AccessPassword, out accesspassword);
                validateHex_uint(killPwd, out accessnewpassword);
                List<TagOperResult> tagOperResults;
                operResult result = _hkReader.ModifyTagKillPassword(_radioInfo.radioHandle, accesspassword, accessnewpassword, out tagOperResults);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("WriteAccessPassWord.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 写销毁密码
        /// </summary>
        /// <param name="killPwd">传递修改的销毁密码 2个字</param>
        /// <returns>true:表示写成功;false:表示写入失败</returns>
        public bool ModifyKillPassWord(string killPwd)
        {
            bool bResult = false;
            try
            {
                bResult = WriteBank(0, 0, 2, killPwd);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ModifyKillPassWord.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 写EPC信息
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data">数据信息 111122223333444455556666</param>
        /// <returns></returns>
        public bool WriteEpcBySetAndLen(byte offset, byte dataLen, string data)
        {
            return WriteBank(1, offset, dataLen, data);
        }

        /// <summary>
        /// 写EPC信息
        /// </summary>
        /// <param name="data">数据信息 111122223333444455556666</param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        public bool WriteEpc(string data)
        {
            int offset = 1;
            int pcNum;
            int len = data.Length / 4;
            string strPc = Convert.ToString(Math.DivRem(len, 2, out pcNum), 0x10);
            if (pcNum == 1)
            {
                strPc = strPc + "800";
            }
            data = strPc.PadRight(4, '0') + data;
            int dataLen = data.Length / 4;
            return WriteBank(1, (byte)offset, (byte)dataLen, data);
        }

        /// <summary>
        /// 写TID信息
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data"></param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        public bool WriteTID(byte offset, byte dataLen, string data)
        {
            return WriteBank(2, offset, dataLen, data);
        }

        /// <summary>
        /// 写用户区
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data">数据信息 3b0556fbdf3bf0d3d9affff0</param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        public bool WriteUser(byte offset, byte dataLen, string data)
        {
            return WriteBank(3, offset, dataLen, data);
        }

        /// <summary>
        /// 写内存块
        /// </summary>
        /// <param name="bank">Bank(0=Reserved  1=EPC  2=TID  3=USER)</param>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data">数据信息</param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        public bool WriteBank(byte bank, byte offset, byte dataLen, string data)
        {
            bool bResult = false;
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    return bResult;
                }

                if ((data.Length % 4) != 0)
                {
                    return bResult;
                }

                if ((data.Length / 4) != (dataLen))
                {
                    return bResult;
                }

                ushort[] writeData = new ushort[(data.Length / 4)];
                for (int i = 0; i < writeData.Length; i++)
                {
                    if (!validateHex_ushort(data.Substring(i * 4, 4), out writeData[i]))
                    {
                        return bResult;
                    }
                }

                //设置过滤
                setMaskCriteria();

                WriteParms parm = new WriteParms();
                switch (bank)
                {
                    case 0: //访问密码区
                        parm.memBank = MemoryBank.Reserved;
                        break;
                    case 1://EPC
                        parm.memBank = MemoryBank.EPC;
                        break;
                    case 2://TID
                        parm.memBank = MemoryBank.TID;
                        break;
                    case 3://USER
                        parm.memBank = MemoryBank.USER;
                        break;
                    default:
                        parm.memBank = MemoryBank.EPC;
                        break;
                }

                uint accesspassword = 0;
                validateHex_uint(this.AccessPassword, out accesspassword);
                parm.accesspassword = accesspassword;
                parm.offset = (ushort)offset;
                parm.length = (ushort)dataLen;
                List<TagOperResult> tagOperResults;
                operResult result = this._hkReader.TagInfoWrite(this._radioInfo.radioHandle, parm, writeData, out tagOperResults);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("WriteBank.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 锁标签
        /// </summary>
        /// <param name="killPassword">销毁密码区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="accessPassword">访问密码区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="epc">EPC区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="tid">TID区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="user">用户区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <returns>true:表示锁定成功;false:表示锁定失败</returns>
        public bool LockTag(int killPassword, int accessPassword, int epc, int tid, int user)
        {
            bool bResult = false;
            byte[] bLock = new byte[20];
            try
            {
                //设置过滤
                setMaskCriteria();
                uint accesspassword = 0;
                validateHex_uint(this.AccessPassword, out accesspassword);
                LockParms parm = new LockParms();

                parm.accessPasswordPermission = getPasswordChoicePermission(accessPassword);
                parm.killPasswordPermission = getPasswordChoicePermission(killPassword);
                parm.EPCMemoryBankPermissions = getMemoryChoicePermission(epc);
                parm.TIDMemoryBankPermissions = getMemoryChoicePermission(tid);
                parm.USERMemoryBankPermissions = getMemoryChoicePermission(user);
                List<TagOperResult> tagOperResults;
                operResult result = this._hkReader.TagLock(this._radioInfo.radioHandle, accesspassword, parm, out tagOperResults);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("LockTag.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <returns>true:成功 false:失败</returns>
        public bool KillTag()
        {
            bool bResult = false;
            uint accesspassword;
            uint killpassword;
            try
            {
                //设置过滤
                setMaskCriteria();
                validateHex_uint(this.AccessPassword, out accesspassword);
                validateHex_uint(this.KillPassword, out killpassword);
                List<TagOperResult> tagOperResults;
                operResult result = _hkReader.TagKill(_radioInfo.radioHandle, accesspassword, killpassword, out tagOperResults);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("KillTag.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 获取发卡器读写功率
        /// </summary>
        /// <returns>空值:表示没有获取功率;不为空:表示获取到功率</returns>
        public string GetTxPower()
        {
            string sResult = string.Empty;
            try
            {
                AntennaPortConfigurationAndStatus s = _hkReader.GetAntennaPortConfigurationAndStatus(_radioInfo.radioHandle, 0);
                sResult = (s.antennaPortConfiguration.powerLevel / 10).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetTxPower.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 设置发卡器读写功率
        /// </summary>
        /// <param name="save">是否保存 true:表示保存;false:表示不保存</param>
        /// <param name="power">传递待写入的发卡器功率 5-30之间数据</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool SetTxPower(bool save, string power)
        {
            bool bResult = false;
            try
            {
                operResult result = SetAntenna(0, true, 0, decimal.Parse(power));
                if (result == operResult.Ok)
                {
                    bResult = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("SetTxPower.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 获取芯片信息
        /// </summary>
        /// <returns>返回芯片信息</returns>
        public string GetTagChipInfo()
        {
            string sResult = "未知";
            try
            {
                string stid = ReadTid(2);
                if (string.IsNullOrEmpty(stid))
                {
                    return sResult;
                }
                stid = Convert.ToString(Convert.ToInt32(stid, 0x10), 2);
                switch (stid.Substring(20, 12))
                {
                    case "000010010011":
                        sResult = "Impinj:Monza 3";
                        break;
                    case "000100000101":
                        sResult = "Impinj:Monza 4QT";
                        break;
                    case "000100001100":
                        sResult = "Impinj:Monza 4E";
                        break;
                    case "000100000000":
                        sResult = "Impinj:Monza 4D";
                        break;
                    case "000100000100":
                        sResult = "Impinj:Monza 4U";
                        break;
                    case "000100110000":
                        sResult = "Impinj:Monza 5";
                        break;
                    case "010000010010":
                        sResult = "Alien Technology:Higgs 3";
                        break;
                    case "010000010001":
                        sResult = "Alien Technology:Higgs 2";
                        break;
                    case "000000000100":
                        sResult = "NXP:G2XL";
                        break;
                    case "001101010001":
                        sResult = "坤锐:";
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetTagChipInfo.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 跟据TID信息判断标签芯片信息
        /// </summary>
        /// <param name="tid">传递标签tid信息</param>
        /// <returns>返回芯片信息</returns>
        public string GetTagChipInfoByTid(string tid)
        {
            string sResult = "未知";
            try
            {
                string stid = tid;
                if (string.IsNullOrEmpty(stid))
                {
                    return sResult;
                }
                stid = Convert.ToString(Convert.ToInt32(stid, 0x10), 2);
                switch (stid.Substring(20, 12))
                {
                    case "000010010011":
                        sResult = "Impinj:Monza 3";
                        break;
                    case "000100000101":
                        sResult = "Impinj:Monza 4QT";
                        break;
                    case "000100001100":
                        sResult = "Impinj:Monza 4E";
                        break;
                    case "000100000000":
                        sResult = "Impinj:Monza 4D";
                        break;
                    case "000100000100":
                        sResult = "Impinj:Monza 4U";
                        break;
                    case "000100110000":
                        sResult = "Impinj:Monza 5";
                        break;
                    case "010000010010":
                        sResult = "Alien Technology:Higgs 3";
                        break;
                    case "010000010001":
                        sResult = "Alien Technology:Higgs 2";
                        break;
                    case "000000000100":
                        sResult = "NXP:G2XL";
                        break;
                    case "001101010001":
                        sResult = "坤锐:";
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetTagChipInfoByTid.Error:" + ex.Message);
            }
            return sResult;
        }

        //扩展其它函数
        #region 扩展其它函数
        /// <summary>
        /// 设置测试天线读写功率
        /// </summary>
        /// <param name="antennaID">天线ID号</param>
        /// <param name="power">传递待写入的发卡器功率 5-30之间数据</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool SetTestAntenna(int antennaID, uint power)
        {
            bool bResult = false;
            try
            {
                power = power * 100;
                operResult result = _hkReader.SetTestAntenna(_radioInfo.radioHandle, antennaID, power);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("SetTestAntenna.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 设置设置当前测试使用的频点
        /// </summary>
        /// <param name="div">传递DIVValue 0:DIV_24;1:DIV_60</param>
        /// <param name="frequencyMhz">传递频点</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool SetTestFrequency(int div, decimal frequencyMhz)
        {
            bool bResult = false;
            try
            {
                DivValue divValue = DivValue.DIV_24;
                if (div.Equals(1))
                    divValue = DivValue.DIV_60;
                operResult result = _hkReader.SetTestFrequency(_radioInfo.radioHandle, divValue, frequencyMhz);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("SetTestFrequency.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 重置设备
        /// </summary>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool Reset()
        {
            bool bResult = false;
            try
            {
                operResult result = _hkReader.RadioReset(_radioInfo.radioHandle);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reset.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 打开天线载波
        /// </summary>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool SetTurnCarrierWaveOn()
        {
            bool bResult = false;
            try
            {
                operResult result = _hkReader.RadioTurnCarrierWaveOn(_radioInfo.radioHandle);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetTurnCarrierWaveOn.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 关闭天线载波
        /// </summary>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool SetTurnCarrierWaveOff()
        {
            bool bResult = false;
            try
            {
                operResult result = _hkReader.RadioTurnCarrierWaveOff(_radioInfo.radioHandle);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetTurnCarrierWaveOff.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 开启RFID模块的TagFocus功能
        /// </summary>
        /// <param name="focus">TagFocus状态 0:Disabled;1:Enabled;其它:未知</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool SetTagFocus(int focus)
        {
            bool bResult = false;
            try
            {
                TagFocusStatus tagFocusStatus = TagFocusStatus.Unknow;
                switch (focus)
                {
                    case 0:
                        tagFocusStatus = TagFocusStatus.Disabled;
                        break;
                    case 1:
                        tagFocusStatus = TagFocusStatus.Enabled;
                        break;
                }
                operResult result = _hkReader.SetTagFocus(_radioInfo.radioHandle, tagFocusStatus);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetTagFocus.Error:" + ex.Message);
            }
            return bResult;
        }

        /// <summary>
        /// 启用或停止FastID功能，该功能对支持FastID功能的标签有效
        /// </summary>
        /// <param name="fastid">FastIDStatus状态 0:Disabled;1:Enabled;其它:未知</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        public bool SetFastID(int fastid)
        {
            bool bResult = false;
            try
            {
                FastIDStatus fastIdStatus = FastIDStatus.Unknow;
                switch (fastid)
                {
                    case 0:
                        fastIdStatus = FastIDStatus.Disabled;
                        break;
                    case 1:
                        fastIdStatus = FastIDStatus.Enabled;
                        break;
                }
                operResult result = _hkReader.SetFastID(_radioInfo.radioHandle, fastIdStatus);
                if (result == operResult.Ok)
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetFastID.Error:" + ex.Message);
            }
            return bResult;
        }

        #endregion

        //函数内部使用
        #region 函数内部使用
        /// <summary>
        /// 获取密码参数转换
        /// </summary>
        /// <param name="flg">0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <returns></returns>
        private PasswordPermission getPasswordChoicePermission(int flg)
        {
            switch (flg)
            {
                case 0: //可读写
                    return PasswordPermission.Accessible;
                case 1://永久可读写
                    return PasswordPermission.AlwaysAccessible;
                case 2://授权状态下可读写
                    return PasswordPermission.SecuredAccessible;
                case 3://永久不可读写
                    return PasswordPermission.AlwaysNotAccessible;
                case 4://维持原状态
                    return PasswordPermission.NoChange;
                default://维持原状态
                    return PasswordPermission.NoChange;
            }
        }

        /// <summary>
        /// 获取用户区EPC等锁状态
        /// </summary>
        /// <param name="flg">0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <returns></returns>
        private MemoryPermission getMemoryChoicePermission(int flg)
        {
            switch (flg)
            {
                case 0://可读写
                    return MemoryPermission.Writeable;
                case 1://永久可读写
                    return MemoryPermission.AlwaysWriteable;
                case 2://授权下可读写
                    return MemoryPermission.SecuredWriteable;
                case 3://永久不可读写
                    return MemoryPermission.AlwaysNotWriteable;
                case 4://维持原状态
                    return MemoryPermission.NoChange;
                default:
                    return MemoryPermission.NoChange;
            }
        }

        /// <summary>
        /// 设置天线功率
        /// </summary>
        /// <param name="logicalAntenna">天线号</param>
        /// <param name="enable">是否设置 true:是;false:否</param>
        /// <param name="antenna">天线号</param>
        /// <param name="power">功率</param>
        /// <returns>Ok:表示设置成功;其它表示失败</returns>
        private operResult SetAntenna(uint logicalAntenna, bool enable, uint antenna, decimal power)
        {
            operResult result = operResult.NotInitalized;

            rfidLink.Core.Structures.AntennaPortConfig config = new rfidLink.Core.Structures.AntennaPortConfig();
            AntennaPortState dISABLED = AntennaPortState.Disabled;
            dISABLED = enable ? AntennaPortState.Enabled : AntennaPortState.Disabled;
            rfidLink.Extend.AntennaPortConfiguration apConfig = new AntennaPortConfiguration();
            try
            {
                result = _hkReader.SetAntennaPortState(_radioInfo.radioHandle, (int)logicalAntenna, dISABLED);
            }
            catch (Exception)
            {
                return result;
            }
            if (result == operResult.Ok)
            {
                try
                {
                    apConfig = this._hkReader.GetAntennaPortConfiguration(_radioInfo.radioHandle, (int)logicalAntenna);
                }
                catch (Exception)
                {
                    return result;
                }
                if (result != operResult.Ok)
                {
                    return result;
                }
                config.powerLevel = (uint)(power * 10M);
                try
                {
                    apConfig.powerLevel = (uint)(power * 10M);
                    result = this._hkReader.SetAntennaPortConfiguration(_radioInfo.radioHandle, (int)logicalAntenna, apConfig);
                }
                catch (Exception)
                {
                    return result;
                }
                if (result == operResult.Ok)
                {
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// 验证是否正确
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidateHex_byte(string input, out byte value)
        {
            if (!byte.TryParse(input, NumberStyles.AllowHexSpecifier, (IFormatProvider)null, out value))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 验证是否正确
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool validateHex_uint(string input, out uint value)
        {
            if (!uint.TryParse(input, NumberStyles.AllowHexSpecifier, null, out value))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 验证是滞正确
        /// </summary>
        /// <param name="input"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool validateHex_ushort(string input, out ushort value)
        {
            if (!ushort.TryParse(input, NumberStyles.AllowHexSpecifier, (IFormatProvider)null, out value))
            {
                return false;
            }

            return true;
        }

        #endregion

        /// <summary>
        /// 初使化对像读写器接口
        /// </summary>
        /// <returns>读写器接口类</returns>
        public static HKReader Instance()
        {
            HKReader _cWLHKReader = null;
            try
            {
                //判断列表对像中是否已经存在
                if (_instance != null)
                {
                    _cWLHKReader = _instance;
                }
                else
                {
                    _instance = new HKReader();
                    _cWLHKReader = _instance;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Instance.Error:" + ex.Message);
            }
            return _cWLHKReader;
        }
    }
}
