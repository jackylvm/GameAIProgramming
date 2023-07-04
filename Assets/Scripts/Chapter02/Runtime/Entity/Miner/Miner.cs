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

using Chapter02.Runtime.Enum;
using Common.FSM;
using Common.Game;

namespace Chapter02.Runtime.Entity
{
    public class Miner : BaseGameEntity
    {
        #region 常量

        // the amount of gold a miner must have before he feels comfortable
        // 矿工在感到舒适之前必须拥有的黄金数量
        public static readonly int ComfortLevel = 5;

        // the amount of nuggets a miner can carry
        // 矿工可以携带的金块数量
        public static readonly int MaxNuggets = 3;

        // above this value a miner is thirsty
        // 超过此值，矿工口渴
        public static readonly int ThirstLevel = 5;

        // above this value a miner is sleepy
        // 超过此值，矿工就昏昏欲睡
        public static readonly int TirednessThreshold = 5;

        #endregion

        public EmLocation Location { get; set; }

        private StateMachine<Miner> m_Machine;

        private int m_GoldCarried;
        private int m_Fatigue;

        public Miner(int id) : base(id)
        {
            m_GoldCarried = 0;
            m_Fatigue = 0;

            m_Machine = new StateMachine<Miner>(this);
        }

        public void AddToGoldCarried(int val)
        {
            m_GoldCarried += val;
            if (m_GoldCarried < 0)
            {
                m_GoldCarried = 0;
            }
        }

        public bool Fatigued()
        {
            if (m_Fatigue > TirednessThreshold)
            {
                return true;
            }

            return false;
        }

        public void DecreaseFatigue()
        {
            m_Fatigue -= 1;
        }

        public void IncreaseFatigue()
        {
            m_Fatigue += 1;
        }
    }
}