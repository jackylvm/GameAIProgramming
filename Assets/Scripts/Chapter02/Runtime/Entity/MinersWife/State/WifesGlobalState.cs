// *************************************************************************************
// FileName: WifesGlobalState.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 23:21:43
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Logger;
using Common.Message;
using UnityEngine;

namespace Chapter02.Runtime.Entity
{
    public class WifeGlobalState : MinersWifeStateBase<WifeGlobalState>
    {
        public override void Enter(MinersWife entity)
        {
        }

        public override void Execute(MinersWife entity, float deltaTime)
        {
            var random = Random.Range(0, 10);
            if (random < 4)
            {
                entity.FSM().ChangeState(VisitBathroom.Instance);
            }
        }

        public override bool OnMessage(MinersWife entity, Telegram telegram)
        {
            switch (telegram.MsgType)
            {
                case EmMsgType.Msg_HiHoneyImHome:
                {
                    IL.UL.Debug(
                        $"Message handled by {EntityNames.GetNameOfEntity(entity.ID())} at time: {Time.timeSinceLevelLoad}!"
                    );
                    IL.UL.Debug(
                        $"{EntityNames.GetNameOfEntity(entity.ID())}: Hi honey. Let me make you some of mah fine country stew!"
                    );

                    entity.FSM().ChangeState(CookStew.Instance);
                    return true;
                }
            }

            return false;
        }

        public override void Exit(MinersWife entity)
        {
        }
    }
}