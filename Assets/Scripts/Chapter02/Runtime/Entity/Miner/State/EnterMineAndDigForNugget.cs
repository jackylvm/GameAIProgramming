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

using Chapter02.Runtime.Enum;
using Common.Logger;

namespace Chapter02.Runtime.Entity
{
    public class EnterMineAndDigForNugget : MinerStateBase<EnterMineAndDigForNugget>
    {
        public override void Enter(Miner entity)
        {
            if (entity.Location != EmLocation.Goldmine)
            {
                IL.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: Walkin' to the goldmine!"
                );

                entity.Location = EmLocation.Goldmine;
            }
        }

        public override void Execute(Miner entity, float deltaTime)
        {
            entity.AddToGoldCarried(1);
            entity.IncreaseFatigue();

            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Pickin' up a nugget!"
            );

            if (entity.PocketsFull())
            {
                entity.FSM().ChangeState(VisitBankAndDepositGold.Instance);
            }

            if (entity.Thirsty())
            {
                entity.FSM().ChangeState(QuenchThirst.Instance);
            }
        }

        public override void Exit(Miner entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold!"
            );
        }
    }
}