// *************************************************************************************
// FileName: Miner.Static.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-05 07:51:52
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

namespace Chapter02.Runtime.Entity
{
    public partial class Miner
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
    }
}