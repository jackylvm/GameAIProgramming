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

using System;
using Chapter02.Runtime.Enum;
using Common.FSM;
using Common.Game;

namespace Chapter02.Runtime.Entity
{
    [Serializable]
    public partial class Miner : BaseGameEntity
    {
        /// <summary>
        /// 当前所在位置
        /// </summary>
        public EmLocation Location { get; set; }

        /// <summary>
        /// 身上携带的黄金数量
        /// </summary>
        private int m_GoldCarried;

        /// <summary>
        /// 疲劳值
        /// </summary>
        private int m_Fatigue;

        /// <summary>
        /// 饥渴值
        /// </summary>
        private int m_Thirst;

        /// <summary>
        /// 存在银行里面的黄金数量
        /// </summary>
        private int m_MoneyInBank;

        public Miner(int id) : base(id)
        {
            m_GoldCarried = 0;
            m_Fatigue = 0;
            m_Thirst = 0;
            m_MoneyInBank = 0;

            m_Machine = new StateMachine<Miner>(this);
        }

        public override void DoStart()
        {
            m_Machine.ChangeState(EnterMineAndDigForNugget.Instance);
        }

        public override void DoUpdate(float deltaTime)
        {
            m_Machine.Update(deltaTime);
        }
    }
}