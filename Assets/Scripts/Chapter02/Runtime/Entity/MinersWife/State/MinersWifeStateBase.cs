// *************************************************************************************
// FileName: MinersWifeStateBase.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 23:18:51
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using System;
using Common.FSM;
using Common.Message;

namespace Chapter02.Runtime.Entity
{
    public class MinersWifeStateBase<TState> : EntityState<MinersWife> where TState : class
    {
        private class Nested
        {
            internal static readonly TState ClassInstance = Activator.CreateInstance(typeof(TState), true) as TState;

            public static Nested CreateInstance()
            {
                return new Nested();
            }
        }

        public static TState Instance => Nested.ClassInstance;

        public override void Enter(MinersWife entity)
        {
        }

        public override void Execute(MinersWife entity, float deltaTime)
        {
        }

        public override void Exit(MinersWife entity)
        {
        }

        public override bool OnMessage(MinersWife entity, Telegram telegram)
        {
            return false;
        }
    }
}