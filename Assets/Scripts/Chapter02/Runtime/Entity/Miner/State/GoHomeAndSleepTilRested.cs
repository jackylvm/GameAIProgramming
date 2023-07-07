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
using Chapter02.Runtime.Message;
using Common.Logger;
using Common.Message;
using UnityEngine;

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

                MessageDispatcher.Inst().DispatchMessage(0.0f, entity.Id(), (int) EmEntity.EntElsa, EmMsgType.Msg_HiHoneyImHome);
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

        public override bool OnMessage(Miner entity, Telegram telegram)
        {
            switch (telegram.MsgType)
            {
                case EmMsgType.Msg_HiHoneyImHome:
                {
                    IL.UL.Debug(
                        $"Message handled by {EntityNames.GetNameOfEntity(entity.ID())} at time: {Time.timeSinceLevelLoad}!"
                    );
                    IL.UL.Debug(
                        $"{EntityNames.GetNameOfEntity(entity.ID())}: Okay Hun, ahm a comin'!"
                    );

                    entity.FSM().ChangeState(EatStew.Instance);
                    return true;
                }
            }

            return false;
        }

        public override void Exit(Miner entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Leaving the house!"
            );
        }
    }
}