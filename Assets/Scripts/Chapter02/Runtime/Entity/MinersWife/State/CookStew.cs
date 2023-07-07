// *************************************************************************************
// FileName: CookStew.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-08 00:03:29
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using System;
using Chapter02.Runtime.Enum;
using Chapter02.Runtime.Message;
using Common.Logger;
using Common.Message;
using UnityEngine;

namespace Chapter02.Runtime.Entity
{
    public class CookStew : MinersWifeStateBase<CookStew>
    {
        public override void Enter(MinersWife entity)
        {
            if (!entity.Cooking)
            {
                IL.UL.Debug(
                    $"{EntityNames.GetNameOfEntity(entity.ID())}: Putting the stew in the oven!"
                );

                MessageDispatcher.Inst().DispatchMessage(1.5, entity.Id(), entity.Id(), EmMsgType.Msg_StewReady);

                entity.Cooking = true;
            }
        }

        public override void Execute(MinersWife entity, float deltaTime)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Fussin' over food!"
            );
        }

        public override bool OnMessage(MinersWife entity, Telegram telegram)
        {
            switch (telegram.MsgType)
            {
                case EmMsgType.Msg_StewReady:
                {
                    IL.UL.Debug(
                        $"Message received by {EntityNames.GetNameOfEntity(entity.ID())} at time: {Time.timeSinceLevelLoad}!"
                    );
                    IL.UL.Debug(
                        $"{EntityNames.GetNameOfEntity(entity.ID())}: StewReady! Lets eat!"
                    );

                    MessageDispatcher.Inst().DispatchMessage(0.0f, entity.Id(), (int) EmEntity.EntMinerBob, EmMsgType.Msg_StewReady);

                    entity.Cooking = false;

                    entity.FSM().ChangeState(DoHouseWork.Instance);
                    return true;
                }
            }

            return false;
        }

        public override void Exit(MinersWife entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Puttin' the stew on the table!"
            );
        }
    }
}