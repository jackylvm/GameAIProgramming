// *************************************************************************************
// FileName: Miner.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 15:04:36
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.FSM;
using Common.Game;

namespace Chapter02.Runtime.Entity
{
    public class Miner : BaseGameEntity
    {
        private StateMachine<Miner> m_Machine;

        public Miner(int id) : base(id)
        {
        }
    }
}