// *************************************************************************************
// FileName: MinersWife.Machine.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 23:24:30
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.FSM;

namespace Chapter02.Runtime.Entity
{
    public partial class MinersWife
    {
        private readonly StateMachine<MinersWife> m_Machine;

        public StateMachine<MinersWife> FSM()
        {
            return m_Machine;
        }
    }
}