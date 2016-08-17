using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.WebSite
{
    /// <summary>
    /// 96位环县溯源协议
    /// </summary>
    public class CPRODUCTEPC96
    {
        //私有参数信息
        #region 私有参数信息

        /// <summary>
        /// 算法版本
        /// </summary>
        private string _sAlgorithm = "1";

        /// <summary>
        /// EPC类型 1：畜牧养殖；2：畜牧屠宰；3：农产品种植；4：畜牧、农产品、工艺品销售标签；5：车辆标签；6：司机卡/员工卡
        /// </summary>
        private string _sEpcType;

        /// <summary>
        /// EPC信息内容
        /// </summary>
        private string _sEpc;

        /// <summary>
        /// 日期时间：车辆标签为领用时间
        /// </summary>
        private string _sTagDate;

        /// <summary>
        /// 车牌号
        /// </summary>
        private string _sCardNo;

        /// <summary>
        /// 序号
        /// </summary>
        private string _sSeqNo;

        /// <summary>
        /// 保留位
        /// </summary>
        private string _sReseridBit;

        /// <summary>
        /// 种子
        /// </summary>
        private string _sSeed;

        /// <summary>
        /// 标签TID信息
        /// </summary>
        private string _sTagTid;

        /// <summary>
        /// 畜牧、农产品、工艺品销售标签：销售店号；畜牧养殖：养殖场号；畜牧屠宰：屠宰场号；农产品种植：种植场号
        /// </summary>
        private string _sBusinessCode;

        /// <summary>
        /// 批次号
        /// </summary>
        private string _sBatchNo;

        //畜牧、农产品、工艺品销售标签
        #region 畜牧、农产品、工艺品销售标签
        /// <summary>
        /// 商品类别
        /// </summary>
        private string _sGoodsType;

        /// <summary>
        /// 商品代号
        /// </summary>
        private string _sGoodsCode;

        /// <summary>
        /// 商品号型
        /// </summary>
        private string _sGoodsSize;
        #endregion

        //司机卡/员工卡标签
        #region 司机卡/员工卡标签
        /// <summary>
        /// 所属类型 1：畜牧养殖场、2：畜牧屠宰场、3：农产品种植场、4：加工厂、5：销售场、6：物流公司
        /// </summary>
        private string _sCompanyType;

        /// <summary>
        /// 所属公司
        /// </summary>
        private string _sCompanyCode;

        /// <summary>
        /// 司机\员工号
        /// </summary>
        private string _sDriver;
        #endregion

        /// <summary>
        /// 省地区编号 京12
        /// </summary>
        private Hashtable _dicArea = new Hashtable();

        /// <summary>
        /// 市区车管所、武警地区编号 00 0
        /// </summary>
        private Hashtable _dicCity = new Hashtable();

        /// <summary>
        /// 车牌编号
        /// </summary>
        private Hashtable _dicCarCode = new Hashtable();

        /// <summary>
        /// 年
        /// </summary>
        private Hashtable _dicYear = new Hashtable();

        /// <summary>
        /// 月
        /// </summary>
        private Hashtable _dicMonth = new Hashtable();

        /// <summary>
        /// 日
        /// </summary>
        private Hashtable _dicDay = new Hashtable();

        #endregion

        //公共发布参数信息
        #region 公共发布参数信息

        /// <summary>
        /// 设置或读取算法版本
        /// </summary>
        public string Algorithm
        {
            get
            {
                return _sAlgorithm;
            }
            set
            {
                _sAlgorithm = value;
            }
        }

        /// <summary>
        /// EPC类型 1：畜牧养殖；2：畜牧屠宰；3：农产品种植；4：畜牧、农产品、工艺品销售标签；5：车辆标签；6：司机卡/员工卡
        /// </summary>
        public string EpcType
        {
            get
            {
                return _sEpcType;
            }
            set
            {
                _sEpcType = value;
            }
        }

        /// <summary>
        /// EPC信息内容
        /// </summary>
        public string Epc
        {
            get
            {
                return _sEpc;
            }
            set
            {
                _sEpc = value;
            }
        }

        /// <summary>
        /// 日期时间：车辆标签为领用时间
        /// </summary>
        public string TagDate
        {
            get
            {
                return _sTagDate;
            }
            set
            {
                _sTagDate = value;
            }
        }


        /// <summary>
        /// 车牌号
        /// </summary>
        public string CardNo
        {
            get
            {
                return _sCardNo;
            }
            set
            {
                _sCardNo = value;
            }
        }

        /// <summary>
        /// 设置或读取 标签序号
        /// </summary>
        public string SeqNo
        {
            get
            {
                return _sSeqNo;
            }
            set
            {
                _sSeqNo = value;
            }
        }

        /// <summary>
        /// 设置或读取 保留位
        /// </summary>
        public string ReseridBit
        {
            get
            {
                return _sReseridBit;
            }
            set
            {
                _sReseridBit = value;
            }
        }

        /// <summary>
        /// 设置或读取 种子
        /// </summary>
        public string Seed
        {
            get
            {
                return _sSeed;
            }
            set
            {
                _sSeed = value;
            }
        }

        /// <summary>
        /// 设置或读取 标签TID信息
        /// </summary>
        public string TagTid
        {
            get
            {
                return _sTagTid;
            }
            set
            {
                _sTagTid = value;
            }
        }

        /// <summary>
        /// 畜牧、农产品、工艺品销售标签：销售店号；畜牧养殖：养殖场号；畜牧屠宰：屠宰场号；农产品种植：种植场号
        /// </summary>
        public string BusinessCode
        {
            get
            {
                return _sBusinessCode;
            }
            set
            {
                _sBusinessCode = value;
            }
        }

        /// <summary>
        /// 批次号
        /// </summary>
        public string BatchNo
        {
            get
            {
                return _sBatchNo;
            }
            set
            {
                _sBatchNo = value;
            }
        }

        //畜牧、农产品、工艺品销售标签
        #region 畜牧、农产品、工艺品销售标签
        /// <summary>
        /// 商品类别
        /// </summary>
        public string GoodsType
        {
            get
            {
                return _sGoodsType;
            }
            set
            {
                _sGoodsType = value;
            }
        }

        /// <summary>
        /// 商品代号
        /// </summary>
        public string GoodsCode
        {
            get
            {
                return _sGoodsCode;
            }
            set
            {
                _sGoodsCode = value;
            }
        }

        /// <summary>
        /// 商品号型
        /// </summary>
        public string GoodsSize
        {
            get
            {
                return _sGoodsSize;
            }
            set
            {
                _sGoodsSize = value;
            }
        }
        #endregion


        //司机卡/员工卡标签
        #region 司机卡/员工卡标签
        /// <summary>
        /// 所属类型 1：畜牧养殖场、2：畜牧屠宰场、3：农产品种植场、4：加工厂、5：销售场、6：物流公司
        /// </summary>
        public string CompanyType
        {
            get
            {
                return _sCompanyType;
            }
            set
            {
                _sCompanyType = value;
            }
        }

        /// <summary>
        /// 所属公司
        /// </summary>
        public string CompanyCode
        {
            get
            {
                return _sCompanyCode;
            }
            set
            {
                _sCompanyCode = value;
            }
        }

        /// <summary>
        /// 司机\员工号
        /// </summary>
        public string Driver
        {
            get
            {
                return _sDriver;
            }
            set
            {
                _sDriver = value;
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// 初使化对像
        /// </summary>
        public CPRODUCTEPC96()
        {

            //初始化　省地区编号
            initArea();
            //初始化　市区车管所、武警地区编号
            initCity();
            //初始化　车牌编号
            initCarCode();
            //初始化 年
            initYear();
            //初始化 月
            initMonth();
            //初始化 日
            initDay();
            //初始化参数
            initParams(0);

        }

        /// <summary>
        /// 发布释放接口
        /// </summary>
        public void Dispose()
        {
            try
            {
                _dicArea.Clear();
                _dicCity.Clear();
                _dicCarCode.Clear();
                _dicYear.Clear();
                _dicMonth.Clear();
                _dicDay.Clear();
                initParams(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Dispose.Error:" + ex.Message);
            }
        }

        //组合标签EPC
        #region 组合标签EPC
        /// <summary>
        /// 组合生成EPC数据包
        /// </summary>
        /// <returns>返回组合数据 非空：成功；空：失败</returns>
        public string PackEpc()
        {
            string sResult = string.Empty;
            try
            {
                switch (EpcType)
                {
                    case "1"://1:畜牧养殖
                        sResult = packBreed();
                        break;
                    case "2"://2:畜牧屠宰
                        sResult = packKill();
                        break;
                    case "3"://3:农产品种植
                        sResult = packPlans();
                        break;
                    case "4"://4:畜牧、农产品、工艺品销售标签
                        sResult = packSale();
                        break;
                    case "5"://5:车辆标签
                        sResult = packVehicle();
                        break;
                    case "6"://6:司机卡/员工卡
                        sResult = packDrive();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("PackEpc.Error:" + ex.Message);
            }
            Epc = sResult;
            return sResult;
        }

        /// <summary>
        /// 组合 畜牧养殖标签 养殖场号+批次号+生成日期+序号
        /// </summary>
        /// <returns>返回组合数据 非空：成功；空：失败</returns>
        private string packBreed()
        {
            string sResult = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbCheck = new StringBuilder(); //给合检验加密
            try
            {

                //算法编号
                sb.Append(packLeftStr(Algorithm, 4));
                //标签类型
                sbCheck.Append(packLeftStr(EpcType, 4));
                //养殖场号+批次号+生成日期+序号
                //养殖场号 14bit
                sbCheck.Append(packLeftStr(BusinessCode, 14));
                //批次号 14bit
                sbCheck.Append(packLeftStr(BatchNo, 14));
                //生成日期 16bit
                sbCheck.Append(packTagDate(TagDate));
                //序号 14bit
                sbCheck.Append(packLeftStr(SeqNo, 14));

                //保留位 26位
                ReseridBit = ranDomStr(26);
                sbCheck.Append(packLeftStr(ReseridBit, 26));


                //组合 养殖场号+批次号+生成日期+序号+保留位 88位
                string sChk = packRightStr(sbCheck.ToString(), 88);

                byte[] byChk = System.Text.Encoding.Default.GetBytes(sChk);
                //取反
                for (int i = 0; i < byChk.Length; i++)
                {

                    switch (byChk[i])
                    {
                        case 48:
                            byChk[i] = 49;
                            break;
                        case 49:
                            byChk[i] = 48;
                            break;
                    }

                }
                //循环右移
                //MoveRight<byte>(ref byChk, 0, byChk.Length - 1);
                sb.Append(System.Text.Encoding.Default.GetString(byChk));
                //校验位
                string sCheck = checkStr(sb.ToString());
                sCheck = packLeftStr(sCheck, 4);
                sb.Append(sCheck);
                sResult = BinaryToHex(packRightStr(sb.ToString(), 4));

            }
            catch (Exception ex)
            {
                Console.WriteLine("packBreed.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 组合 畜牧屠宰标签
        /// </summary>
        /// <returns></returns>
        private string packKill()
        {
            string sResult = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbCheck = new StringBuilder(); //给合检验加密
            try
            {

                //算法编号
                sb.Append(packLeftStr(Algorithm, 4));
                //标签类型
                sbCheck.Append(packLeftStr(EpcType, 4));
                //屠宰场号+批次号+生成日期+序号
                //屠宰场号 14bit
                sbCheck.Append(packLeftStr(BusinessCode, 14));
                //批次号 14bit
                sbCheck.Append(packLeftStr(BatchNo, 14));
                //生成日期 16bit
                sbCheck.Append(packTagDate(TagDate));
                //序号 14bit
                sbCheck.Append(packLeftStr(SeqNo, 14));

                //保留位 26位
                ReseridBit = ranDomStr(26);
                sbCheck.Append(packLeftStr(ReseridBit, 26));


                //组合 屠宰场号+批次号+生成日期+序号+保留位 88位
                string sChk = packRightStr(sbCheck.ToString(), 88);

                byte[] byChk = System.Text.Encoding.Default.GetBytes(sChk);
                //取反
                for (int i = 0; i < byChk.Length; i++)
                {

                    switch (byChk[i])
                    {
                        case 48:
                            byChk[i] = 49;
                            break;
                        case 49:
                            byChk[i] = 48;
                            break;
                    }

                }
                //循环右移
                //MoveRight<byte>(ref byChk, 0, byChk.Length - 1);
                sb.Append(System.Text.Encoding.Default.GetString(byChk));
                //校验位
                string sCheck = checkStr(sb.ToString());
                sCheck = packLeftStr(sCheck, 4);
                sb.Append(sCheck);
                sResult = BinaryToHex(packRightStr(sb.ToString(), 4));

            }
            catch (Exception ex)
            {
                Console.WriteLine("packKill.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 组合 畜牧、农产品、工艺品销售标签
        /// </summary>
        /// <returns>返回组合数据 非空：成功；空：失败</returns>
        private string packSale()
        {
            string sResult = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbCheck = new StringBuilder(); //给合检验加密
            try
            {

                //算法编号
                sb.Append(packLeftStr(Algorithm, 4));
                //标签类型
                sbCheck.Append(packLeftStr(EpcType, 4));
                //销售店号+商口类别+商品代号+商品号型+生成日期+序号
                //销售店号 14bit
                sbCheck.Append(packLeftStr(BusinessCode, 14));
                //商品类别 4bit。其规则：1：畜牧；2：农产品；3：工艺品
                sbCheck.Append(packLeftStr(GoodsType, 4));
                //商品代号 14bit
                sbCheck.Append(packLeftStr(GoodsCode, 14));
                //商品号型 8bit
                sbCheck.Append(packLeftStr(GoodsSize, 8));
                //生成日期 16bit
                sbCheck.Append(packTagDate(TagDate));
                //序号     14bit
                sbCheck.Append(packLeftStr(SeqNo, 14));

                //保留位 14位
                ReseridBit = ranDomStr(8);
                sbCheck.Append(packLeftStr(ReseridBit, 14));

                //组合 养殖场号+批次号+生成日期+序号+保留位 88位
                string sChk = packRightStr(sbCheck.ToString(), 88);

                byte[] byChk = System.Text.Encoding.Default.GetBytes(sChk);
                //取反
                for (int i = 0; i < byChk.Length; i++)
                {

                    switch (byChk[i])
                    {
                        case 48:
                            byChk[i] = 49;
                            break;
                        case 49:
                            byChk[i] = 48;
                            break;
                    }

                }
                //循环右移
                //MoveRight<byte>(ref byChk, 0, byChk.Length - 1);
                sb.Append(System.Text.Encoding.Default.GetString(byChk));
                //校验位
                string sCheck = checkStr(sb.ToString());
                sCheck = packLeftStr(sCheck, 4);
                sb.Append(sCheck);
                sResult = BinaryToHex(packRightStr(sb.ToString(), 4));

            }
            catch (Exception ex)
            {
                Console.WriteLine("packSale.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 组合 农产品种植 
        /// </summary>
        /// <returns>返回组合数据 非空：成功；空：失败</returns>
        private string packPlans()
        {
            string sResult = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbCheck = new StringBuilder(); //给合检验加密
            try
            {

                //算法编号
                sb.Append(packLeftStr(Algorithm, 4));
                //标签类型
                sbCheck.Append(packLeftStr(EpcType, 4));
                //种植场号+批次号+生成日期+序号
                //种植场号 14bit
                sbCheck.Append(packLeftStr(BusinessCode, 14));
                //批次号 14bit
                sbCheck.Append(packLeftStr(BatchNo, 14));
                //生成日期 16bit
                sbCheck.Append(packTagDate(TagDate));
                //序号 14bit
                sbCheck.Append(packLeftStr(SeqNo, 14));

                //保留位 26位
                ReseridBit = ranDomStr(26);
                sbCheck.Append(packLeftStr(ReseridBit, 26));


                //组合 种植场号+批次号+生成日期+序号+保留位 88位
                string sChk = packRightStr(sbCheck.ToString(), 88);

                byte[] byChk = System.Text.Encoding.Default.GetBytes(sChk);
                //取反
                for (int i = 0; i < byChk.Length; i++)
                {

                    switch (byChk[i])
                    {
                        case 48:
                            byChk[i] = 49;
                            break;
                        case 49:
                            byChk[i] = 48;
                            break;
                    }

                }
                //循环右移
                //MoveRight<byte>(ref byChk, 0, byChk.Length - 1);
                sb.Append(System.Text.Encoding.Default.GetString(byChk));
                //校验位
                string sCheck = checkStr(sb.ToString());
                sCheck = packLeftStr(sCheck, 4);
                sb.Append(sCheck);
                sResult = BinaryToHex(packRightStr(sb.ToString(), 4));

            }
            catch (Exception ex)
            {
                Console.WriteLine("packPlans.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 组合EPC 车辆标签 车牌号+车辆标签领用日期
        /// </summary>
        /// <returns>返回组合数据 非空：成功；空：失败</returns>
        private string packVehicle()
        {
            string sResult = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbCheck = new StringBuilder(); //给合检验加密
            try
            {

                //例:沪A•A1234，车辆标签领用日期：2016年05月24日
                //算法编号
                sb.Append(packLeftStr(Algorithm, 4));
                //标签类型
                sbCheck.Append(packLeftStr(EpcType, 4));
                //车牌号+车辆标签领用日期
                //处理车牌号
                sbCheck.Append(packCardNo());
                //处理车辆标签领用日期 16位
                sbCheck.Append(packTagDate(TagDate));

                //保留位 26位
                ReseridBit = ranDomStr(26);
                sbCheck.Append(packLeftStr(ReseridBit, 26));

                //给合 车牌号+车辆标签领用日期+保留位 88位
                string sChk = packRightStr(sbCheck.ToString(), 88);

                byte[] byChk = System.Text.Encoding.Default.GetBytes(sChk);
                //取反
                for (int i = 0; i < byChk.Length; i++)
                {

                    switch (byChk[i])
                    {
                        case 48:
                            byChk[i] = 49;
                            break;
                        case 49:
                            byChk[i] = 48;
                            break;
                    }

                }
                //循环右移
                //MoveRight<byte>(ref byChk, 0, byChk.Length - 1);
                sb.Append(System.Text.Encoding.Default.GetString(byChk));
                //校验位
                string sCheck = checkStr(sb.ToString());
                sCheck = packLeftStr(sCheck, 4);
                sb.Append(sCheck);
                sResult = BinaryToHex(packRightStr(sb.ToString(), 4));

            }
            catch (Exception ex)
            {
                Console.WriteLine("packVehicle.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 组合 司机卡/员工卡标签
        /// </summary>
        /// <returns>返回组合数据 非空：成功；空：失败</returns>
        private string packDrive()
        {
            string sResult = string.Empty;
            StringBuilder sb = new StringBuilder();
            StringBuilder sbCheck = new StringBuilder(); //给合检验加密
            try
            {

                //例:
                //算法编号
                sb.Append(packLeftStr(Algorithm, 4));
                //标签类型
                sbCheck.Append(packLeftStr(EpcType, 4));

                //所属类型 4bit 1：畜牧养殖场、2：畜牧屠宰场、3：农产品种植场、4：加工厂、5：销售场
                sbCheck.Append(packLeftStr(CompanyType, 4));
                //所属公司 14bit
                sbCheck.Append(packLeftStr(CompanyCode, 14));
                //司机\员工号 14bit
                sbCheck.Append(packLeftStr(Driver, 14));
                //生成日期 16bit
                sbCheck.Append(packTagDate(TagDate));
                //处理保留位 14位
                ReseridBit = ranDomStr(8);
                sbCheck.Append(packLeftStr(ReseridBit, 14));

                //组合 所属类型+所属公司+司机\员工号+生成日期+保留位 88位
                string sChk = packRightStr(sbCheck.ToString(), 88);

                byte[] byChk = System.Text.Encoding.Default.GetBytes(sChk);
                //取反
                for (int i = 0; i < byChk.Length; i++)
                {

                    switch (byChk[i])
                    {
                        case 48:
                            byChk[i] = 49;
                            break;
                        case 49:
                            byChk[i] = 48;
                            break;
                    }

                }
                //循环右移
                //MoveRight<byte>(ref byChk, 0, byChk.Length - 1);
                sb.Append(System.Text.Encoding.Default.GetString(byChk));
                //校验位
                string sCheck = checkStr(sb.ToString());
                sCheck = packLeftStr(sCheck, 4);
                sb.Append(sCheck);
                sResult = BinaryToHex(packRightStr(sb.ToString(), 4));

            }
            catch (Exception ex)
            {
                Console.WriteLine("packDrive.Error:" + ex.Message);
            }
            return sResult;
        }
        #endregion

        //解析标签EPC
        #region 解析标签EPC
        /// <summary>
        /// 解析读取EPC信息
        /// </summary>
        public string UnPackEpc()
        {
            string sBinEpc = string.Empty;
            StringBuilder sb = new StringBuilder();
            try
            {
                //解码串
                #region 解码串
                //初始化参数
                initParams(1);

                //如果为空,则返回
                if (string.IsNullOrEmpty(Epc))
                {
                    return sb.ToString();
                }
                //转换成十六进制
                sBinEpc = HexToBinary(Epc);

                //校验是否完整EPC
                string sChkBuf = checkStr(sBinEpc.Substring(0, 92));
                //校验位
                string sCheck = sBinEpc.Substring(92);

                //校验是否标准标签EPC
                if (!packLeftStr(sChkBuf, 4).Equals(sCheck))
                {
                    return sb.ToString();
                }

                //算法编号
                string sAlgorithm = sBinEpc.Substring(0, 4);
                //内容串
                string sBuf = sBinEpc.Substring(4, 92);

                byte[] byChk = System.Text.Encoding.Default.GetBytes(sBuf);
                //取反
                for (int i = 0; i < byChk.Length; i++)
                {
                    switch (byChk[i])
                    {
                        case 48:
                            byChk[i] = 49;
                            break;
                        case 49:
                            byChk[i] = 48;
                            break;
                    }

                }
                #endregion
                //获取转换后内容
                string sBin = System.Text.Encoding.Default.GetString(byChk);

                //获取标签类型
                string sEpcType = sBin.Substring(0, 4);
                sBin = sBin.Substring(4);
                EpcType = Convert.ToInt32(sEpcType, 2).ToString();
                switch (EpcType)
                {
                    case "1"://1:畜牧养殖
                        unpackBreed(sBin);
                        break;
                    case "2"://2:畜牧屠宰
                        unpackKill(sBin);
                        break;
                    case "3"://3:农产品种植
                        unpackPlans(sBin);
                        break;
                    case "4"://4:畜牧、农产品、工艺品销售标签
                        unpackSale(sBin);
                        break;
                    case "5"://5:车辆标签
                        unpackVehicle(sBin);
                        break;
                    case "6"://6:司机卡/员工卡
                        unpackDrive(sBin);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UnPackEpc.Error:" + ex.Message);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 解析 畜牧养殖标签 养殖场号+批次号+生成日期+序号
        /// </summary>
        /// <param name="bin">传递待解析的串</param>
        /// <returns>返回是否成功 true:是；false:否</returns>
        private bool unpackBreed(string bin)
        {
            bool bResult = true;
            try
            {
                //养殖场号 14bit
                string sBreedCode = bin.Substring(0, 14);
                bin = bin.Substring(14);
                BusinessCode = Convert.ToInt32(sBreedCode, 2).ToString();
                //批次号 14bit
                string sBatchNo = bin.Substring(0, 14);
                bin = bin.Substring(14);
                BatchNo = Convert.ToInt32(sBatchNo, 2).ToString();
                //生成日期 16bit
                string sTagDate = bin.Substring(0, 16);
                bin = bin.Substring(16);
                TagDate = unpackDateTime(sTagDate);
                //序号 14bit
                string sSeqNo = bin.Substring(0, 14);
                bin = bin.Substring(14);
                SeqNo = Convert.ToInt32(sSeqNo, 2).ToString();

                //处理保留位
                ReseridBit = Convert.ToInt32(bin, 2).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackBreed.Error:" + ex.Message);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 解析 畜牧屠宰标签 屠宰场号+批次号+生成日期+序号
        /// </summary>
        /// <param name="bin">传递待解析的串</param>
        /// <returns>返回是否成功 true:是；false:否</returns>
        private bool unpackKill(string bin)
        {
            bool bResult = true;
            try
            {
                //屠宰场号 14bit
                string sKillCode = bin.Substring(0, 14);
                bin = bin.Substring(14);
                BusinessCode = Convert.ToInt32(sKillCode, 2).ToString();
                //批次号 14bit
                string sBatchNo = bin.Substring(0, 14);
                bin = bin.Substring(14);
                BatchNo = Convert.ToInt32(sBatchNo, 2).ToString();
                //生成日期 16bit
                string sTagDate = bin.Substring(0, 16);
                bin = bin.Substring(16);
                TagDate = unpackDateTime(sTagDate);
                //序号 14bit
                string sSeqNo = bin.Substring(0, 14);
                bin = bin.Substring(14);
                SeqNo = Convert.ToInt32(sSeqNo, 2).ToString();

                //处理保留位
                ReseridBit = Convert.ToInt32(bin, 2).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackKill.Error:" + ex.Message);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 解析 农产品种植 种植场号+批次号+生成日期+序号
        /// </summary>
        /// <param name="bin">传递待解析的串</param>
        /// <returns>返回是否成功 true:是；false:否</returns>
        private bool unpackPlans(string bin)
        {
            bool bResult = true;
            try
            {
                //种植场号 14bit
                string sPlansCode = bin.Substring(0, 14);
                bin = bin.Substring(14);
                BusinessCode = Convert.ToInt32(sPlansCode, 2).ToString();
                //批次号 14bit
                string sBatchNo = bin.Substring(0, 14);
                bin = bin.Substring(14);
                BatchNo = Convert.ToInt32(sBatchNo, 2).ToString();
                //生成日期 16bit
                string sTagDate = bin.Substring(0, 16);
                bin = bin.Substring(16);
                TagDate = unpackDateTime(sTagDate);
                //序号 14bit
                string sSeqNo = bin.Substring(0, 14);
                bin = bin.Substring(14);
                SeqNo = Convert.ToInt32(sSeqNo, 2).ToString();

                //处理保留位
                ReseridBit = Convert.ToInt32(bin, 2).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackPlans.Error:" + ex.Message);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 解析 畜牧、农产品、工艺品销售标签  销售店号+商口类别+商品代号+商品号型+生成日期+序号
        /// </summary>
        /// <param name="bin">传递待解析的串</param>
        /// <returns>返回是否成功 true:是；false:否</returns>
        private bool unpackSale(string bin)
        {
            bool bResult = true;
            try
            {
                //销售店号 14bit
                string sSaleCode = bin.Substring(0, 14);
                bin = bin.Substring(14);
                BusinessCode = Convert.ToInt32(sSaleCode, 2).ToString();
                //商品类别 4bit。其规则：1：畜牧；2：农产品；3：工艺品
                string sGoodsType = bin.Substring(0, 4);
                bin = bin.Substring(4);
                GoodsType = Convert.ToInt32(sGoodsType, 2).ToString();
                //商品代号 14bit
                string sGoodsCode = bin.Substring(0, 14);
                bin = bin.Substring(14);
                GoodsCode = Convert.ToInt32(sGoodsCode, 2).ToString();
                //商品号型 8bit
                string sGoodsSize = bin.Substring(0, 8);
                bin = bin.Substring(8);
                GoodsSize = Convert.ToInt32(sGoodsSize, 2).ToString();
                //生成日期 16bit
                string sTagDate = bin.Substring(0, 16);
                bin = bin.Substring(16);
                TagDate = unpackDateTime(sTagDate);
                //序号     14bit
                string sSeqNo = bin.Substring(0, 14);
                bin = bin.Substring(14);
                SeqNo = Convert.ToInt32(sSeqNo, 2).ToString();

                //处理保留位
                ReseridBit = Convert.ToInt32(bin, 2).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackSale.Error:" + ex.Message);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 解析 车辆标签 车牌号+车辆标签领用日期+保留位
        /// </summary>
        /// <param name="bin">传递待解析的串</param>
        /// <returns>返回是否成功 true:是；false:否</returns>
        private bool unpackVehicle(string bin)
        {
            bool bResult = true;
            try
            {
                //车牌号 42bit
                string sCardNo = bin.Substring(0, 42);
                bin = bin.Substring(42);

                //处理车牌号
                CardNo = unpackCardNo(sCardNo);

                //车辆标签领用日期 16bit
                string sTagDate = bin.Substring(0, 16);
                bin = bin.Substring(16);
                TagDate = unpackDateTime(sTagDate);

                //处理保留位
                ReseridBit = Convert.ToInt32(bin.Substring(0, 26), 2).ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackVehicle.Error:" + ex.Message);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 解析 司机卡/员工卡标签 所属类型+所属公司+司机\员工号+生成日期
        /// </summary>
        /// <param name="bin">传递待解析的串</param>
        /// <returns>返回是否成功 true:是；false:否</returns>
        private bool unpackDrive(string bin)
        {

            bool bResult = true;
            try
            {
                //所属类型 4bit 1：畜牧养殖场、2：畜牧屠宰场、3：农产品种植场、4：加工厂、5：销售场
                string sCompanyType = bin.Substring(0, 4);
                bin = bin.Substring(4);
                CompanyType = Convert.ToInt32(sCompanyType, 2).ToString();
                //所属公司 14bit
                string sCompanyCode = bin.Substring(0, 14);
                bin = bin.Substring(14);
                CompanyCode = Convert.ToInt32(sCompanyCode, 2).ToString();
                //司机\员工号 14bit
                string sDriver = bin.Substring(0, 14);
                bin = bin.Substring(14);
                Driver = Convert.ToInt32(sDriver, 2).ToString();
                //生成日期 16bit
                string sTagDate = bin.Substring(0, 16);
                bin = bin.Substring(16);
                TagDate = unpackDateTime(sTagDate);
                //处理保留位
                ReseridBit = Convert.ToInt32(bin, 2).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackDrive.Error:" + ex.Message);
                bResult = false;
            }
            return bResult;
        }

        /// <summary>
        /// 解析车牌号
        /// </summary>
        /// <param name="cardNo">传递待解析的车牌号数据串</param>
        /// <returns>返回车牌号</returns>
        private string unpackCardNo(string cardNo)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string sTemp = cardNo;
                //处理省地区编号 6bit
                string sArea = Convert.ToInt32(sTemp.Substring(0, 6), 2).ToString();
                foreach (System.Collections.DictionaryEntry area in _dicArea)
                {
                    if (area.Value.Equals(sArea))
                    {
                        sb.Append(area.Key);
                        break;
                    }
                }
                //处理市区车管所、武警地区编号 6bit
                string sCity = Convert.ToInt32(sTemp.Substring(6, 6), 2).ToString();
                foreach (System.Collections.DictionaryEntry city in _dicCity)
                {
                    if (city.Value.Equals(sCity))
                    {
                        sb.Append(city.Key);
                        break;
                    }
                }

                //添加分隔符
                sb.Append("•");

                //字母、数字和号牌
                sTemp = sTemp.Substring(12, 30);
                string sLetter = string.Empty;
                for (int i = 0; i < sTemp.Length / 6; i++)
                {
                    sLetter = Convert.ToInt32(sTemp.Substring(i * 6, 6), 2).ToString();

                    foreach (System.Collections.DictionaryEntry carcode in _dicCarCode)
                    {
                        if (carcode.Value.Equals(sLetter))
                        {
                            sb.Append(carcode.Key);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackCardNo.Error:" + ex.Message);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 解析日期 yyyy年xx月zz日
        /// </summary>
        /// <param name="sDate">二进制字符串</param>
        /// <returns>返回解析后日期信息</returns>
        private string unpackDateTime(string sDate)
        {
            StringBuilder sb = new StringBuilder();
            string sTemp = sDate;

            try
            {
                //处理年 7bit
                string sYear = Convert.ToInt32(sTemp.Substring(0, 7), 2).ToString();
                foreach (System.Collections.DictionaryEntry year in _dicYear)
                {
                    if (year.Value.Equals(sYear))
                    {
                        sb.Append(year.Key);
                        break;
                    }
                }
                sb.Append("年");
                //处理月 4bit
                string sMonth = Convert.ToInt32(sTemp.Substring(7, 4), 2).ToString();
                foreach (System.Collections.DictionaryEntry month in _dicMonth)
                {
                    if (month.Value.Equals(sMonth))
                    {
                        sb.Append(month.Key);
                        break;
                    }
                }
                sb.Append("月");
                //处理日期 5 bit
                string sDay = Convert.ToInt32(sTemp.Substring(11, 5), 2).ToString();
                foreach (System.Collections.DictionaryEntry day in _dicDay)
                {
                    if (day.Value.Equals(sDay))
                    {
                        sb.Append(day.Key);
                        break;
                    }
                }
                sb.Append("日");

            }
            catch (Exception ex)
            {
                Console.WriteLine("unpackDateTime.Error:" + ex.Message);
            }
            return sb.ToString();
        }

        #endregion

        //数据转换及操作
        #region 数据转换及操作
        /// <summary>
        /// 二进制转换成十六进制字符串
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        private string BinaryToHex(string binary)
        {
            StringBuilder sb = new StringBuilder();
            string sTemp = string.Empty;
            try
            {
                for (int j = 0; j < binary.Length / 4; j++)
                {
                    sTemp = binary.Substring(j * 4, 4);
                    sb.Append(Convert.ToString(Convert.ToInt32(sTemp, 2), 16));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("BinaryToHex.Error:" + ex.Message);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 十六进制转换成二进制
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private string HexToBinary(string hex)
        {
            StringBuilder sb = new StringBuilder();
            string sTemp = string.Empty;
            try
            {
                for (int j = 0; j < hex.Length; j++)
                {
                    sTemp = hex.Substring(j * 1, 1);
                    sb.Append(Convert.ToString(Convert.ToInt32(sTemp, 16), 2).PadLeft(4, '0'));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("BinaryToHex.Error:" + ex.Message);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 组合车牌号 传递车牌号 例：沪A.A1234
        /// </summary>
        /// <returns></returns>
        private string packCardNo()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string sCardNo = CardNo;
                string sTemp = string.Empty;

                //如果车牌号为空，则返回
                if (string.IsNullOrEmpty(sCardNo))
                {
                    return sb.ToString();
                }

                //去除车牌号中的.
                sCardNo = sCardNo.Replace(".", "").Replace("•", "");

                //判断是否为武警车牌号 例：WZ2128021
                if (sCardNo.Substring(0, 2).Equals("WJ"))
                {
                    //处理新式武警车牌
                    #region 处理新式武警车牌
                    //新式武警车牌 2位
                    string sArea = sCardNo.Substring(0, 2);

                    sArea = _dicArea[sArea].ToString();
                    if (!string.IsNullOrEmpty(sArea))
                    {
                        sb.Append(packLeftStr(sArea, 6));
                    }
                    //处理武警省编号 2位
                    sTemp = sCardNo.Substring(2);
                    string sCity = sTemp.Substring(0, 2);
                    sCity = _dicCity[sCity].ToString();
                    if (!string.IsNullOrEmpty(sCity))
                    {
                        sb.Append(packLeftStr(sCity, 6));
                    }
                    //字母、数字和号牌
                    sTemp = sTemp.Substring(2);
                    char[] c = sTemp.ToCharArray();
                    foreach (char _c in c)
                    {
                        //
                        sTemp = _dicCarCode[_c.ToString()].ToString();
                        if (!string.IsNullOrEmpty(sTemp))
                        {
                            sb.Append(packLeftStr(sTemp, 6));
                        }
                    }
                    #endregion
                }
                else
                {
                    //处理平常车牌号信息 冀J.R1234
                    #region 处理平常车牌号信息
                    //省信息 1位
                    string sArea = sCardNo.Substring(0, 1);
                    sArea = _dicArea[sArea].ToString();
                    if (!string.IsNullOrEmpty(sArea))
                    {
                        sb.Append(packLeftStr(sArea, 6));
                    }
                    //处理地区编号 1位
                    sTemp = sCardNo.Substring(1);
                    string sCity = sTemp.Substring(0, 1);
                    sCity = _dicCity[sCity].ToString();
                    if (!string.IsNullOrEmpty(sCity))
                    {
                        sb.Append(packLeftStr(sCity, 6));
                    }
                    //字母、数字和号牌
                    sTemp = sTemp.Substring(1);
                    char[] c = sTemp.ToCharArray();
                    foreach (char _c in c)
                    {
                        //
                        sTemp = _dicCarCode[_c.ToString()].ToString();
                        if (!string.IsNullOrEmpty(sTemp))
                        {
                            sb.Append(packLeftStr(sTemp, 6));
                        }
                    }
                    #endregion
                }
                //车牌信息补全 42
                string sCar = packRightStr(sb.ToString(), 42);
                sb.Remove(0, sb.Length);
                sb.Append(sCar);

            }
            catch (Exception ex)
            {
                Console.WriteLine("packCardNo.Error:" + ex.Message);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 组合日期
        /// </summary>
        /// <param name="sDate">传递时间 2013年12月22日</param>
        /// <returns>返回组合后日期信息</returns>
        private string packTagDate(string sDate)
        {
            StringBuilder sb = new StringBuilder();
            string sTemp = string.Empty;
            try
            {
                DateTime dtTime = DateTime.Parse(sDate);
                //处理年 7bit
                sTemp = dtTime.Year.ToString();
                sTemp = _dicYear[sTemp].ToString();
                if (!string.IsNullOrEmpty(sTemp))
                {
                    sb.Append(packLeftStr(sTemp, 7));
                }
                //处理月 4bit
                sTemp = dtTime.Month.ToString();
                sTemp = _dicMonth[sTemp].ToString();
                if (!string.IsNullOrEmpty(sTemp))
                {
                    sb.Append(packLeftStr(sTemp, 4));
                }

                //处理日期 5 bit
                sTemp = dtTime.Day.ToString();
                sTemp = _dicDay[sTemp].ToString();
                if (!string.IsNullOrEmpty(sTemp))
                {
                    sb.Append(packLeftStr(sTemp, 5));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("packCmainDate.Error:" + ex.Message);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 左补0字符串组合成参数规范参数
        /// </summary>
        /// <param name="sParams">传递待组合信息内容</param>
        /// <param name="len">组合数据长度</param>
        /// <returns>返回组合后数据</returns>
        private string packLeftStr(string sParams, int len)
        {
            StringBuilder sb = new StringBuilder();
            string sTemp = sParams;
            try
            {
                //int iLen = len - sTemp.Length;
                //for (int i = 0; i < iLen; i++)
                //{
                //    sTemp = "0" + sTemp;
                //}
                sTemp = Convert.ToString(int.Parse(sParams), 2).PadLeft(len, '0').Substring(0, len);

                sb.Append(sTemp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("packLenStr.Error:" + ex.Message);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 右补0字符串组合成参数规范参数
        /// </summary>
        /// <param name="sParams">传递待组合信息内容</param>
        /// <param name="len">组合数据长度</param>
        /// <returns>返回组合后数据</returns>
        private string packRightStr(string sParams, int len)
        {
            StringBuilder sb = new StringBuilder();
            string sTemp = sParams;
            try
            {
                //int iLen = len - sTemp.Length;
                //for (int i = 0; i < iLen; i++)
                //{
                //    sTemp = sTemp + "0";
                //}
                sTemp = sTemp.PadRight(len, '0');

                sb.Append(sTemp);
            }
            catch (Exception ex)
            {
                Console.WriteLine("packRightStr.Error:" + ex.Message);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 组合生成随机数
        /// </summary>
        /// <param name="len">传递待组合的数据长度</param>
        /// <returns>返回组合后的信息</returns>
        private string ranDomStr(int len)
        {
            string sResult = string.Empty;
            try
            {
                System.Random ro = new Random();
                switch (len)
                {
                    case 8:
                        sResult = ro.Next(0, 255).ToString();
                        break;
                    case 24:
                        sResult = ro.Next(0, 16777215).ToString();
                        break;
                    default:
                        sResult = ro.Next(0, 16777215).ToString();
                        break;
                }
                //for (int i = 0; i < len; i++)
                //{
                //    sResult = sResult + ro.Next(0, 1);
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("ranDomStr.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 第一版本，校验信息处理
        /// </summary>
        /// <param name="chkNote">传递待生成组合校验信息内容</param>
        /// <returns>返回组合后校验信息内容</returns>
        private string checkStr(string chkNote)
        {
            string sResult = string.Empty;
            try
            {
                int iNum = 0;
                for (int i = 0; i < chkNote.Length / 8; i++)
                {
                    iNum = iNum + Convert.ToInt32(chkNote.Substring(i * 8, 8), 2);
                }
                sResult = (iNum % 256).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("checkStr.Error:" + ex.Message);
            }
            return sResult;
        }

        /// <summary>
        /// 反序右移
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="arr">数组</param>
        /// <param name="b">起点下标</param>
        /// <param name="e">末点下标</param>
        private void moveRight<T>(ref T[] arr, int b, int e)
        {
            for (; b < e; b++, e--)
            {
                T temp = arr[e];
                arr[e] = arr[b];
                arr[b] = temp;
            }

        }

        /// <summary>
        /// 反序左移
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="arr">数组</param>
        /// <param name="b">起点下标</param>
        /// <param name="e">末点下标</param>
        private void moveLeft<T>(ref T[] arr, int b, int e)
        {
            for (; b < e; b++, e--)
            {
                T temp = arr[b];
                arr[b] = arr[e];
                arr[e] = temp;
            }
        }
        #endregion

        //初始化参数信息
        #region 初始化参数信息
        /// <summary>
        /// 初始化 省地区编号
        /// </summary>
        private void initArea()
        {

            try
            {
                //92、02式号牌省市区
                _dicArea.Add("京", "12");
                _dicArea.Add("津", "13");
                _dicArea.Add("晋", "14");
                _dicArea.Add("冀", "15");
                _dicArea.Add("蒙", "16");
                _dicArea.Add("辽", "17");
                _dicArea.Add("吉", "18");
                _dicArea.Add("黑", "19");
                _dicArea.Add("沪", "20");
                _dicArea.Add("苏", "21");
                _dicArea.Add("浙", "22");
                _dicArea.Add("皖", "23");
                _dicArea.Add("闽", "24");
                _dicArea.Add("赣", "25");
                _dicArea.Add("鲁", "26");
                _dicArea.Add("豫", "27");
                _dicArea.Add("鄂", "28");
                _dicArea.Add("湘", "29");
                _dicArea.Add("粤", "30");
                _dicArea.Add("桂", "31");
                _dicArea.Add("琼", "32");
                _dicArea.Add("川", "33");
                _dicArea.Add("贵", "34");
                _dicArea.Add("云", "35");
                _dicArea.Add("藏", "36");
                _dicArea.Add("陕", "37");
                _dicArea.Add("甘", "38");
                _dicArea.Add("青", "39");
                _dicArea.Add("宁", "40");
                _dicArea.Add("新", "41");
                _dicArea.Add("渝", "42");
                _dicArea.Add("港", "43");
                _dicArea.Add("澳", "44");
                _dicArea.Add("台", "45");
                //04式军用号牌
                _dicArea.Add("军", "1");
                _dicArea.Add("空", "2");
                _dicArea.Add("海", "3");
                _dicArea.Add("北", "4");
                _dicArea.Add("沈", "5");
                _dicArea.Add("兰", "6");
                _dicArea.Add("济", "7");
                _dicArea.Add("南", "8");
                _dicArea.Add("广", "9");
                _dicArea.Add("成", "10");
                //07式武警号牌
                _dicArea.Add("WJ", "11");
                //使领馆车牌
                _dicArea.Add("使", "0");
            }
            catch (Exception ex)
            {
                Console.WriteLine("initArea.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化 市区车管所、武警地区编
        /// </summary>
        private void initCity()
        {

            try
            {
                //07式武警
                #region
                _dicCity.Add("00", "0");
                _dicCity.Add("01", "1");
                _dicCity.Add("02", "2");
                _dicCity.Add("03", "3");
                _dicCity.Add("04", "4");
                _dicCity.Add("05", "5");
                _dicCity.Add("06", "6");
                _dicCity.Add("07", "7");
                _dicCity.Add("08", "8");
                _dicCity.Add("09", "9");
                _dicCity.Add("10", "10");
                _dicCity.Add("11", "11");
                _dicCity.Add("12", "12");
                _dicCity.Add("13", "13");
                _dicCity.Add("14", "14");
                _dicCity.Add("15", "15");
                _dicCity.Add("16", "16");
                _dicCity.Add("17", "17");
                _dicCity.Add("18", "18");
                _dicCity.Add("19", "19");
                _dicCity.Add("20", "20");
                _dicCity.Add("21", "21");
                _dicCity.Add("22", "22");
                _dicCity.Add("23", "23");
                _dicCity.Add("24", "24");
                _dicCity.Add("25", "25");
                _dicCity.Add("26", "26");
                _dicCity.Add("27", "27");
                _dicCity.Add("28", "28");
                _dicCity.Add("29", "29");
                _dicCity.Add("30", "30");
                _dicCity.Add("31", "31");
                _dicCity.Add("32", "32");
                #endregion
                //92、02、04式
                #region
                _dicCity.Add("A", "33");
                _dicCity.Add("B", "34");
                _dicCity.Add("C", "35");
                _dicCity.Add("D", "36");
                _dicCity.Add("E", "37");
                _dicCity.Add("F", "38");
                _dicCity.Add("G", "39");
                _dicCity.Add("H", "40");
                _dicCity.Add("I", "41");
                _dicCity.Add("J", "42");
                _dicCity.Add("K", "43");
                _dicCity.Add("L", "44");
                _dicCity.Add("M", "45");
                _dicCity.Add("N", "46");
                _dicCity.Add("O", "47");
                _dicCity.Add("P", "48");
                _dicCity.Add("Q", "49");
                _dicCity.Add("R", "50");
                _dicCity.Add("S", "51");
                _dicCity.Add("T", "52");
                _dicCity.Add("U", "53");
                _dicCity.Add("V", "54");
                _dicCity.Add("W", "55");
                _dicCity.Add("X", "56");
                _dicCity.Add("Y", "57");
                _dicCity.Add("Z", "58");
                #endregion
                //13式武警
                #region
                _dicCity.Add("", "59");
                _dicCity.Add("冀", "60");
                _dicCity.Add("蒙", "61");
                _dicCity.Add("晋", "62");
                _dicCity.Add("辽", "63");
                _dicCity.Add("吉", "64");
                _dicCity.Add("黑", "65");
                _dicCity.Add("沪", "66");
                _dicCity.Add("苏", "67");
                _dicCity.Add("浙", "68");
                _dicCity.Add("皖", "69");
                _dicCity.Add("赣", "70");
                _dicCity.Add("闽", "71");
                _dicCity.Add("鲁", "72");
                _dicCity.Add("粤", "73");
                _dicCity.Add("桂", "74");
                _dicCity.Add("鄂", "75");
                _dicCity.Add("湘", "76");
                _dicCity.Add("豫", "77");
                _dicCity.Add("川", "78");
                _dicCity.Add("云", "79");
                _dicCity.Add("贵", "80");
                _dicCity.Add("陕", "81");
                _dicCity.Add("甘", "82");
                _dicCity.Add("青", "83");
                _dicCity.Add("新", "84");
                _dicCity.Add("藏", "85");
                _dicCity.Add("津", "86");
                _dicCity.Add("宁", "87");
                _dicCity.Add("琼", "88");
                _dicCity.Add("京", "89");
                _dicCity.Add("渝", "90");
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine("initCity.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化 车牌编号
        /// </summary>
        private void initCarCode()
        {
            try
            {
                //0-9
                _dicCarCode.Add("0", "0");
                _dicCarCode.Add("1", "1");
                _dicCarCode.Add("2", "2");
                _dicCarCode.Add("3", "3");
                _dicCarCode.Add("4", "4");
                _dicCarCode.Add("5", "5");
                _dicCarCode.Add("6", "6");
                _dicCarCode.Add("7", "7");
                _dicCarCode.Add("8", "8");
                _dicCarCode.Add("9", "9");

                //A-Z
                _dicCarCode.Add("A", "24");
                _dicCarCode.Add("B", "25");
                _dicCarCode.Add("C", "26");
                _dicCarCode.Add("D", "27");
                _dicCarCode.Add("E", "28");
                _dicCarCode.Add("F", "29");
                _dicCarCode.Add("G", "30");
                _dicCarCode.Add("H", "31");
                _dicCarCode.Add("I", "32");
                _dicCarCode.Add("J", "33");
                _dicCarCode.Add("K", "34");
                _dicCarCode.Add("L", "35");
                _dicCarCode.Add("M", "36");
                _dicCarCode.Add("N", "37");
                _dicCarCode.Add("O", "38");
                _dicCarCode.Add("P", "39");
                _dicCarCode.Add("Q", "40");
                _dicCarCode.Add("R", "41");
                _dicCarCode.Add("S", "42");
                _dicCarCode.Add("T", "43");
                _dicCarCode.Add("U", "44");
                _dicCarCode.Add("V", "45");
                _dicCarCode.Add("W", "46");
                _dicCarCode.Add("X", "47");
                _dicCarCode.Add("Y", "48");
                _dicCarCode.Add("Z", "49");

                //其它
                _dicCarCode.Add("警", "10");
                _dicCarCode.Add("学", "11");
                _dicCarCode.Add("领", "12");
                _dicCarCode.Add("试", "13");
                _dicCarCode.Add("农", "14");
                _dicCarCode.Add("挂", "15");
                _dicCarCode.Add("拖", "16");
                _dicCarCode.Add("境", "17");

                //07武警警种
                _dicCarCode.Add("消", "18");
                _dicCarCode.Add("边", "19");
                _dicCarCode.Add("通", "20");
                _dicCarCode.Add("森", "21");
                _dicCarCode.Add("金", "22");
                _dicCarCode.Add("电", "23");

            }
            catch (Exception ex)
            {
                Console.WriteLine("initCarCode.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化 年
        /// </summary>
        private void initYear()
        {
            try
            {
                _dicYear.Add("2010", "0");
                _dicYear.Add("2011", "1");
                _dicYear.Add("2012", "2");
                _dicYear.Add("2013", "3");
                _dicYear.Add("2014", "4");
                _dicYear.Add("2015", "5");
                _dicYear.Add("2016", "6");
                _dicYear.Add("2017", "7");
                _dicYear.Add("2018", "8");
                _dicYear.Add("2019", "9");
                _dicYear.Add("2020", "10");
                _dicYear.Add("2021", "11");
                _dicYear.Add("2022", "12");
                _dicYear.Add("2023", "13");
                _dicYear.Add("2024", "14");
                _dicYear.Add("2025", "15");
                _dicYear.Add("2026", "16");
                _dicYear.Add("2027", "17");
                _dicYear.Add("2028", "18");
                _dicYear.Add("2029", "19");
                _dicYear.Add("2030", "20");
                _dicYear.Add("2031", "21");
                _dicYear.Add("2032", "22");
                _dicYear.Add("2033", "23");
                _dicYear.Add("2034", "24");
                _dicYear.Add("2035", "25");
                _dicYear.Add("2036", "26");
                _dicYear.Add("2037", "27");
                _dicYear.Add("2038", "28");
                _dicYear.Add("2039", "29");
                _dicYear.Add("2040", "30");
                _dicYear.Add("2041", "31");
                _dicYear.Add("2042", "32");
                _dicYear.Add("2043", "33");
                _dicYear.Add("2044", "34");
                _dicYear.Add("2045", "35");
                _dicYear.Add("2046", "36");
                _dicYear.Add("2047", "37");
                _dicYear.Add("2048", "38");
                _dicYear.Add("2049", "39");
                _dicYear.Add("2050", "40");
                _dicYear.Add("2051", "41");
                _dicYear.Add("2052", "42");
                _dicYear.Add("2053", "43");
                _dicYear.Add("2054", "44");
                _dicYear.Add("2055", "45");
                _dicYear.Add("2056", "46");
                _dicYear.Add("2057", "47");
                _dicYear.Add("2058", "48");
                _dicYear.Add("2059", "49");
                _dicYear.Add("2060", "50");
                _dicYear.Add("2061", "51");
                _dicYear.Add("2062", "52");
                _dicYear.Add("2063", "53");
                _dicYear.Add("2064", "54");
                _dicYear.Add("2065", "55");
                _dicYear.Add("2066", "56");
                _dicYear.Add("2067", "57");
                _dicYear.Add("2068", "58");
                _dicYear.Add("2069", "59");
                _dicYear.Add("2070", "60");
                _dicYear.Add("2071", "61");
                _dicYear.Add("2072", "62");
                _dicYear.Add("2073", "63");

                _dicYear.Add("2074", "64");
                _dicYear.Add("2075", "65");
                _dicYear.Add("2076", "66");
                _dicYear.Add("2077", "67");
                _dicYear.Add("2078", "68");
                _dicYear.Add("2079", "69");
                _dicYear.Add("2080", "70");
                _dicYear.Add("2081", "71");
                _dicYear.Add("2082", "72");
                _dicYear.Add("2083", "73");
                _dicYear.Add("2084", "74");
                _dicYear.Add("2085", "75");
                _dicYear.Add("2086", "76");
                _dicYear.Add("2087", "77");
                _dicYear.Add("2088", "78");
                _dicYear.Add("2089", "79");
                _dicYear.Add("2090", "80");
                _dicYear.Add("2091", "81");
                _dicYear.Add("2092", "82");
                _dicYear.Add("2093", "83");
                _dicYear.Add("2094", "84");
                _dicYear.Add("2095", "85");
                _dicYear.Add("2096", "86");
                _dicYear.Add("2097", "87");
                _dicYear.Add("2098", "88");
                _dicYear.Add("2099", "89");
                _dicYear.Add("2100", "90");
                _dicYear.Add("2101", "91");
                _dicYear.Add("2102", "92");
                _dicYear.Add("2103", "93");
                _dicYear.Add("2104", "94");
                _dicYear.Add("2105", "95");
                _dicYear.Add("2106", "96");
                _dicYear.Add("2107", "97");
                _dicYear.Add("2108", "98");
                _dicYear.Add("2109", "99");
                _dicYear.Add("2110", "100");
                _dicYear.Add("2111", "101");
                _dicYear.Add("2112", "102");
                _dicYear.Add("2113", "103");
                _dicYear.Add("2114", "104");
                _dicYear.Add("2115", "105");
                _dicYear.Add("2116", "106");
                _dicYear.Add("2117", "107");
                _dicYear.Add("2118", "108");
                _dicYear.Add("2119", "109");
                _dicYear.Add("2120", "110");

            }
            catch (Exception ex)
            {
                Console.WriteLine("initYear.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化 月
        /// </summary>
        private void initMonth()
        {
            try
            {

                for (int i = 1; i < 13; i++)
                {
                    _dicMonth.Add(i.ToString(), i.ToString());
                }
                //老方式
                #region 老方式
                //_dicMonth.Add("1", "1");
                //_dicMonth.Add("2", "2");
                //_dicMonth.Add("3", "3");
                //_dicMonth.Add("4", "4");
                //_dicMonth.Add("5", "5");
                //_dicMonth.Add("6", "6");
                //_dicMonth.Add("7", "7");
                //_dicMonth.Add("8", "8");
                //_dicMonth.Add("9", "9");
                //_dicMonth.Add("10", "10");
                //_dicMonth.Add("11", "11");
                //_dicMonth.Add("12", "12");
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine("initMonth.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 初始化 日
        /// </summary>
        private void initDay()
        {
            try
            {
                for (int i = 1; i < 32; i++)
                {
                    _dicDay.Add(i.ToString(), i.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("initDay.Error:" + ex.Message);
            }
        }

        /// <summary>
        /// 初使化参数
        /// </summary>
        /// <param name="flg">0:所有清空；1：除EPC外不清空</param>
        private void initParams(int flg)
        {
            try
            {
                this.CardNo = "";
                this.TagDate = "";
                if (flg.Equals(0))
                    this.Epc = "";
                this.EpcType = "";
                this.TagDate = "";
                this.ReseridBit = "";
                this.Seed = "";
                this.SeqNo = "";
                this.TagTid = "";
                this.BusinessCode = "";
                this.BatchNo = "";
                this.GoodsType = "";
                this.GoodsCode = "";
                this.GoodsSize = "";
                this.CompanyType = "";
                this.CompanyCode = "";
                this.Driver = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("initParams.Error:" + ex.Message);
            }
        }
        #endregion
    }
}
