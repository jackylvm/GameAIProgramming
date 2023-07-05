// *************************************************************************************
// FileName: QuenchThirst.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 00:01:23
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter02.Runtime.Enum;
using Common.Logger;

namespace Chapter02.Runtime.Entity
{
    public class QuenchThirst : MinerStateBase<QuenchThirst>
    {
        public override void Enter(Miner entity)
        {
            if (entity.Location != EmLocation.Saloon)
            {
                Logger.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: Boy, ah sure is thusty! Walking to the saloon!"
                );

                entity.Location = EmLocation.Saloon;
            }
        }

        public override void Execute(Miner entity, float deltaTime)
        {
            if (entity.Thirsty())
            {
                entity.BuyAndDrinkAWhiskey();
                Logger.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: That's mighty fine sippin liquer!"
                );

                entity.FSM().ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
            {
                Logger.UL.Debug(
                    "ERROR!ERROR!ERROR!"
                );
            }
        }

        public override void Exit(Miner entity)
        {
            Logger.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Leaving the saloon, feelin' good!"
            );
        }
    }
}