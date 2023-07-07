// *************************************************************************************
// FileName: EatStew.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-08 00:18:07
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Logger;

namespace Chapter02.Runtime.Entity
{
    public class EatStew : MinerStateBase<EatStew>
    {
        public override void Enter(Miner entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Smells Reaaal goood Elsa!"
            );
        }

        public override void Execute(Miner entity, float deltaTime)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Tastes real good too!"
            );
            entity.FSM().RevertToPreviousState();
        }

        public override void Exit(Miner entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Thankya li'lle lady. Ah better get back to whatever ah wuz doin'!"
            );
        }
    }
}