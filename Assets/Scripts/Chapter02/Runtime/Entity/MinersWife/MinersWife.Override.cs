// *************************************************************************************
// FileName: MinersWife.Override.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-07 23:41:23
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Message;

namespace Chapter02.Runtime.Entity
{
    public partial class MinersWife
    {
        public override bool HandleMessage(Telegram telegram)
        {
            return m_Machine.HandleMessage(telegram);
        }
    }
}