// *************************************************************************************
// FileName: EnterMineAndDigForNugget.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 15:21:25
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Logger;

namespace Chapter02.Runtime.Entity
{
    public class EnterMineAndDigForNugget : MinerStateBase<EnterMineAndDigForNugget>
    {
        public override void Enter(Miner entity)
        {
            Logger.UL.Debug($"Hahaha!");

            base.Enter(entity);
        }

        public override void Execute(Miner entity, float deltaTime)
        {
            base.Execute(entity, deltaTime);
        }

        public override void Exit(Miner entity)
        {
            base.Exit(entity);
        }
    }
}