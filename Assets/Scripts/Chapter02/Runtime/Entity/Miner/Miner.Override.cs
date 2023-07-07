// *************************************************************************************
// FileName: Miner.Override.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-07 23:40:41
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Message;

namespace Chapter02.Runtime.Entity
{
    public partial class Miner
    {
        public override bool HandleMessage(Telegram telegram)
        {
            return m_Machine.HandleMessage(telegram);
        }
    }
}