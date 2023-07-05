// *************************************************************************************
// FileName: Miner.Method.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-05 07:52:51
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

namespace Chapter02.Runtime.Entity
{
    public partial class Miner
    {
        /// <summary>
        /// 增加携带的黄金量
        /// </summary>
        /// <param name="val"></param>
        public void AddToGoldCarried(int val)
        {
            m_GoldCarried += val;
            if (m_GoldCarried < 0)
            {
                m_GoldCarried = 0;
            }
        }

        /// <summary>
        /// 检查是否疲劳
        /// </summary>
        /// <returns></returns>
        public bool Fatigued()
        {
            if (m_Fatigue > TirednessThreshold)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 减少疲劳值
        /// </summary>
        public void DecreaseFatigue()
        {
            m_Fatigue -= 1;
        }

        /// <summary>
        /// 增加疲劳值
        /// </summary>
        public void IncreaseFatigue()
        {
            m_Fatigue += 1;
        }

        /// <summary>
        /// 背包是否已满
        /// </summary>
        /// <returns>true:已满</returns>
        public bool PocketsFull()
        {
            return m_GoldCarried >= MaxNuggets;
        }

        /// <summary>
        /// 是否饥渴
        /// </summary>
        /// <returns>true:饥渴</returns>
        public bool Thirsty()
        {
            return m_Thirst >= ThirstLevel;
        }

        /// <summary>
        /// 买瓶酒喝
        /// </summary>
        public void BuyAndDrinkAWhiskey()
        {
            m_Thirst = 0;
            m_MoneyInBank -= 2;
        }

        /// <summary>
        /// 获取携带的金块
        /// </summary>
        /// <returns></returns>
        public int GoldCarried()
        {
            return m_GoldCarried;
        }

        /// <summary>
        /// 设置携带的黄金
        /// </summary>
        /// <param name="val"></param>
        public void SetGoldCarried(int val)
        {
            m_GoldCarried = val;
        }

        /// <summary>
        /// 获得银行内的黄金
        /// </summary>
        /// <returns></returns>
        public int Wealth()
        {
            return m_MoneyInBank;
        }

        /// <summary>
        /// 设置黄金
        /// </summary>
        /// <param name="val"></param>
        public void SetWealth(int val)
        {
            m_MoneyInBank += val;
        }

        /// <summary>
        /// 存入银行
        /// </summary>
        /// <param name="val"></param>
        public void AddToWealth(int val)
        {
            m_MoneyInBank += val;
            if (m_MoneyInBank < 0)
            {
                m_MoneyInBank = 0;
            }
        }
    }
}