// *************************************************************************************
// FileName: Miner.Machine.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-05 08:01:45
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.FSM;

namespace Chapter02.Runtime.Entity
{
    public partial class Miner
    {
        private StateMachine<Miner> m_Machine;

        public StateMachine<Miner> FSM()
        {
            return m_Machine;
        }
    }
}