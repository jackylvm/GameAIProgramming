// *************************************************************************************
// FileName: GoHomeAndSleepTilRested.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-05 23:59:33
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter02.Runtime.Enum;
using Common.Logger;

namespace Chapter02.Runtime.Entity
{
    public class GoHomeAndSleepTilRested : MinerStateBase<GoHomeAndSleepTilRested>
    {
        public override void Enter(Miner entity)
        {
            if (entity.Location != EmLocation.Shack)
            {
                IL.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: Walkin' home!"
                );

                entity.Location = EmLocation.Shack;
            }
        }

        public override void Execute(Miner entity, float deltaTime)
        {
            if (!entity.Fatigued())
            {
                IL.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: What a God darn fantastic nap! Time to find more gold!"
                );

                entity.FSM().ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                entity.DecreaseFatigue();

                IL.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: ZZZZ... "
                );
            }
        }

        public override void Exit(Miner entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Leaving the house!"
            );
        }
    }
}