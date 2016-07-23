namespace FoodTrace.Hardware
{
    /// <summary>
    /// 海康桌面(D500)发卡器 接口
    /// </summary>
    public interface IHKReader
    { //定义发卡器接口发布使用变量
        #region 定义发卡器接口发布使用变量
        /// <summary>
        /// 设置或读取 读写器串口名称
        /// </summary>
        string ReaderComName { get; set; }

        /// <summary>
        /// 读取或设置访问密码
        /// </summary>
        string AccessPassword { get; set; }

        /// <summary>
        /// 读取或设置销毁密码
        /// </summary>
        string KillPassword { get; set; }

        /// <summary>
        /// 读取或设置 是否过滤 true:过滤;false:不过滤
        /// </summary>
        bool Choose { get; set; }

        /// <summary>
        /// 传递跟据EPC信息过滤识别EPC信息
        /// </summary>
        string TagEpc { get; set; }

        /// <summary>
        /// 处理盘点模式下识别EPC信息
        /// </summary>
        string InventoryTag { get; set; }

        /// <summary>
        /// 匹配方式 0:正常 1:反向
        /// </summary>
        int MatchType { get; set; }

        #endregion

        /// <summary>
        /// 获取本地读写器对应的串列表
        /// </summary>
        /// <returns></returns>
        string[] GetReaderList();

        /// <summary>
        /// 打开桌面发卡器
        /// </summary>
        /// <returns></returns>
        bool Open();

        /// <summary>
        /// 判断读写器是否连接成功
        /// </summary>
        /// <returns>true:表示打开成功;false:表示打开失败</returns>
        bool IsOpen();

        /// <summary>
        /// 关闭桌面发卡器
        /// </summary>
        /// <returns></returns>
        bool Close();

        /// <summary>
        /// 盘点模式启动
        /// </summary>
        /// <returns>true:表示启动成功;false:表示失败</returns>
        bool Start();

        /// <summary>
        /// 盘点模式停止
        /// </summary>
        /// <returns>true:表示停止成功;false:表示失败</returns>
        bool Stop();

        /// <summary>
        /// 读取访问密码
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到访问密码信息</returns>
        string ReadAccessPassWord();

        /// <summary>
        /// 获取访问题密码
        /// </summary>
        /// <returns></returns>
        string GetAccessPassWord();

        /// <summary>
        /// 读取销毁密码
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到销毁密码信息</returns>
        string ReadKillPassWord();

        /// <summary>
        /// 读取销毁密码
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到销毁密码信息</returns>
        string GetKillPassWord();

        /// <summary>
        /// 读取EPC 单模式
        /// </summary>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到EPC信息</returns>
        string ReadEpc();

        /// <summary>
        /// 读取EPC(盘点一次) 
        /// </summary>
        /// <param name="tid">返回盘点到的TID信息</param>
        /// <returns>空值:表示没有读取读取信息;有值:表示读取到EPC信息</returns>
        string ReadEpcOnce(out string tid);

        /// <summary>
        /// 读取EPC信息
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        string ReadEpcBySetAndLen(byte offset, byte dataLen);

        /// <summary>
        /// 读取TID
        /// </summary>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        string ReadTid(byte dataLen);

        /// <summary>
        /// 读取用户区
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        string ReadUser(byte offset, byte dataLen);

        /// <summary>
        /// 读Bank
        /// </summary>
        /// <param name="bank">Bank(0=Reserved  1=EPC  2=TID  3=USER)</param>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        string ReadBank(byte bank, byte offset, byte dataLen);

        /// <summary>
        /// 读用户区扩展
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <returns></returns>
        string ReadUserBankParmsEx(byte offset, byte dataLen);

        /// <summary>
        /// 写访问密码
        /// </summary>
        /// <param name="accessPwd">传递修改的访问密码 2个字</param>
        /// <returns>true:表示写成功;false:表示写入失败</returns>
        bool WriteAccessPassWord(string accessPwd);

        /// <summary>
        /// 修改访问密码
        /// </summary>
        /// <param name="accessPwd"></param>
        /// <returns></returns>
        bool ModifyAccessPassWord(string accessPwd);

        /// <summary>
        /// 写销毁密码
        /// </summary>
        /// <param name="killPwd">传递修改的销毁密码 2个字</param>
        /// <returns>true:表示写成功;false:表示写入失败</returns>
        bool WriteKillPassWord(string killPwd);

        /// <summary>
        /// 写销毁密码
        /// </summary>
        /// <param name="killPwd">传递修改的销毁密码 2个字</param>
        /// <returns>true:表示写成功;false:表示写入失败</returns>
        bool ModifyKillPassWord(string killPwd);

        /// <summary>
        /// 写EPC信息
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data">数据信息 111122223333444455556666</param>
        /// <returns></returns>
        bool WriteEpcBySetAndLen(byte offset, byte dataLen, string data);

        /// <summary>
        /// 写EPC信息
        /// </summary>
        /// <param name="data">数据信息 111122223333444455556666</param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        bool WriteEpc(string data);

        /// <summary>
        /// 写TID信息
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data"></param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        bool WriteTID(byte offset, byte dataLen, string data);

        /// <summary>
        /// 写用户区
        /// </summary>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data">数据信息 3b0556fbdf3bf0d3d9affff0</param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        bool WriteUser(byte offset, byte dataLen, string data);

        /// <summary>
        /// 写内存块
        /// </summary>
        /// <param name="bank">Bank(0=Reserved  1=EPC  2=TID  3=USER)</param>
        /// <param name="offset">偏移量（以word为单位）</param>
        /// <param name="dataLen">数据长度（以word为单位）</param>
        /// <param name="data">数据信息</param>
        /// <returns>true:表示写入成功;false:表示写入失败</returns>
        bool WriteBank(byte bank, byte offset, byte dataLen, string data);

        /// <summary>
        /// 锁标签
        /// </summary>
        /// <param name="killPassword">销毁密码区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="accessPassword">访问密码区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="epc">EPC区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="tid">TID区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <param name="user">用户区 0:可读写;1:永久可读写;2:授权下可读写;3:永久不可读写;4:维持原状态</param>
        /// <returns>true:表示锁定成功;false:表示锁定失败</returns>
        bool LockTag(int killPassword, int accessPassword, int epc, int tid, int user);

        /// <summary>
        /// 销毁标签
        /// </summary>
        /// <returns>true:成功 false:失败</returns>
        bool KillTag();

        /// <summary>
        /// 获取发卡器读写功率
        /// </summary>
        /// <returns>空值:表示没有获取功率;不为空:表示获取到功率</returns>
        string GetTxPower();

        /// <summary>
        /// 设置发卡器读写功率
        /// </summary>
        /// <param name="save">是否保存 true:表示保存;false:表示不保存</param>
        /// <param name="power">传递待写入的发卡器功率 3-13之间数据</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool SetTxPower(bool save, string power);

        /// <summary>
        /// 获取芯片信息
        /// </summary>
        /// <returns>返回芯片信息</returns>
        string GetTagChipInfo();

        /// <summary>
        /// 跟据TID信息判断标签芯片信息
        /// </summary>
        /// <param name="tid">传递标签tid信息</param>
        /// <returns>返回芯片信息</returns>
        string GetTagChipInfoByTid(string tid);

        //扩展其它函数
        #region 扩展其它函数
        /// <summary>
        /// 设置测试天线读写功率
        /// </summary>
        /// <param name="antennaID">天线ID号</param>
        /// <param name="power">传递待写入的发卡器功率 5-30之间数据</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool SetTestAntenna(int antennaID, uint power);

        /// <summary>
        /// 设置设置当前测试使用的频点
        /// </summary>
        /// <param name="div">传递DIVValue 0:DIV_24;1:DIV_60</param>
        /// <param name="frequencyMhz">传递频点</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool SetTestFrequency(int div, decimal frequencyMhz);

        /// <summary>
        /// 重置设备
        /// </summary>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool Reset();

        /// <summary>
        /// 打开天线载波
        /// </summary>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool SetTurnCarrierWaveOn();

        /// <summary>
        /// 关闭天线载波
        /// </summary>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool SetTurnCarrierWaveOff();

        /// <summary>
        /// 开启RFID模块的TagFocus功能
        /// </summary>
        /// <param name="focus">TagFocus状态 0:Disabled;1:Enabled;其它:未知</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool SetTagFocus(int focus);

        /// <summary>
        /// 启用或停止FastID功能，该功能对支持FastID功能的标签有效
        /// </summary>
        /// <param name="fastid">FastIDStatus状态 0:Disabled;1:Enabled;其它:未知</param>
        /// <returns>true:表示设置成功;false:表示设置失败</returns>
        bool SetFastID(int fastid);

        #endregion
    }
}
