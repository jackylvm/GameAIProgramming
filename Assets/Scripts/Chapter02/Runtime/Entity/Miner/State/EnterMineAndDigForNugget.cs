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
            Logger.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Walkin' to the goldmine!"
            );

            entity.Location = EmLocation.Goldmine;
        }

        public override void Execute(Miner entity, float deltaTime)
        {
            entity.AddToGoldCarried(1);
            entity.IncreaseFatigue();

            Logger.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Pickin' up a nugget!"
            );
        }

        public override void Exit(Miner entity)
        {
            Logger.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Ah'm leavin' the goldmine with mah pockets full o' sweet gold!"
            );
        }
    }
}