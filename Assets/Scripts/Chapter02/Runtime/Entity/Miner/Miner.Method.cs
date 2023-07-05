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
    }
}