// *************************************************************************************
// FileName: MinersWife.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 23:13:34
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using System;
using Chapter02.Runtime.Enum;
using Common.FSM;
using Common.Game;

namespace Chapter02.Runtime.Entity
{
    [Serializable]
    public partial class MinersWife : BaseGameEntity
    {
        public EmLocation Location { get; set; }

        public MinersWife(int id) : base(id)
        {
            Location = EmLocation.Shack;

            m_Machine = new StateMachine<MinersWife>(this);
        }

        public override void DoStart()
        {
            m_Machine.ChangeState(DoHouseWork.Instance);
            m_Machine.SetGlobalState(WifeGlobalState.Instance);
        }

        public override void DoUpdate(float deltaTime)
        {
            m_Machine.Update(deltaTime);
        }
    }
}