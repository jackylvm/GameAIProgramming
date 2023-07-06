// *************************************************************************************
// FileName: VisitBankAndDepositGold.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-05 23:44:19
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter02.Runtime.Enum;
using Common.Logger;

namespace Chapter02.Runtime.Entity
{
    public class VisitBankAndDepositGold : MinerStateBase<VisitBankAndDepositGold>
    {
        public override void Enter(Miner entity)
        {
            if (entity.Location != EmLocation.Bank)
            {
                IL.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: Goin' to the bank. Yes siree!"
                );

                entity.Location = EmLocation.Bank;
            }
        }

        public override void Execute(Miner entity, float deltaTime)
        {
            entity.AddToWealth(entity.GoldCarried());
            entity.SetGoldCarried(0);

            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Depositing gold. Total savings now: {entity.Wealth()}"
            );

            if (entity.Wealth() >= Miner.ComfortLevel)
            {
                IL.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: WooHoo! Rich enough for now. Back home to mah li'lle lady!"
                );

                entity.FSM().ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else
            {
                entity.FSM().ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Leavin' the bank!"
            );
        }
    }
}