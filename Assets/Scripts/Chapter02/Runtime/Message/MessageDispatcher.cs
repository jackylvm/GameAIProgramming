// *************************************************************************************
// FileName: MessageDispatcher.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-07 23:12:22
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using System.Collections.Generic;
using Chapter02.Runtime.Entity;
using Common.Game;
using Common.Logger;
using Common.Message;
using UnityEngine;

namespace Chapter02.Runtime.Message
{
    public class MessageDispatcher
    {
        #region 单例模式

        private static MessageDispatcher m_Instance = null;

        public static MessageDispatcher Inst()
        {
            return m_Instance ??= new MessageDispatcher();
        }

        #endregion

        private readonly HashSet<Telegram> m_DelayMsg = new HashSet<Telegram>();

        public void DispatchDelayedMessages()
        {
            var currentTime = Time.timeSinceLevelLoad;

            var lst = new List<Telegram>();
            foreach (var telegram in m_DelayMsg)
            {
                if (telegram.DispatchTime > 0 && telegram.DispatchTime < currentTime)
                {
                    var receiverEntity = EntityMgr.Inst().GetEntityFromID(telegram.Receiver);

                    IL.UL.Info(
                        $"Queued telegram ready for dispatch: Sent to {EntityNames.GetNameOfEntity(receiverEntity.Id())}. Msg is {MsgUtils.MsgToStr(telegram.MsgType)}"
                    );

                    Discharge(receiverEntity, telegram);

                    lst.Add(telegram);
                }
            }

            foreach (var telegram in lst)
            {
                m_DelayMsg.Remove(telegram);
            }
        }

        public void DispatchMessage(double delay, int sender, int receiver, EmMsgType msg)
        {
            var senderEntity = EntityMgr.Inst().GetEntityFromID(sender);
            var receiverEntity = EntityMgr.Inst().GetEntityFromID(receiver);

            if (receiverEntity == null)
            {
                IL.UL.Error($"Warning! No Receiver with ID of {receiver} found!");
                return;
            }

            var telegram = new Telegram(0, sender, receiver, msg);
            if (delay <= 0.0f)
            {
                IL.UL.Info(
                    $"Instant telegram dispatched at time: {Time.timeSinceLevelLoad} by {EntityNames.GetNameOfEntity(sender)} for {EntityNames.GetNameOfEntity(senderEntity.Id())}. Msg is {MsgUtils.MsgToStr(msg)}"
                );

                Discharge(receiverEntity, telegram);
            }
            else
            {
                var currentTime = Time.timeSinceLevelLoad;
                telegram.DispatchTime = currentTime + delay;

                m_DelayMsg.Add(telegram);

                IL.UL.Info(
                    $"Delayed telegram from {EntityNames.GetNameOfEntity(sender)} recorded at time {Time.timeSinceLevelLoad} for {EntityNames.GetNameOfEntity(senderEntity.Id())}. Msg is {MsgUtils.MsgToStr(msg)}"
                );
            }
        }

        private void Discharge(BaseGameEntity receiver, Telegram telegram)
        {
            if (receiver != null)
            {
                var result = receiver.HandleMessage(telegram);
                if (!result)
                {
                    IL.UL.Error($"Message to {EntityNames.GetNameOfEntity(receiver.Id())} not handled!");
                }
            }
        }
    }
}