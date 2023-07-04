// *************************************************************************************
// FileName: MinerStateBase.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 15:18:52
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using System;
using Common.FSM;
using MS.Log4Unity;

namespace Chapter02.Runtime.Entity
{
    public class MinerStateBase<TState> : EntityState<Miner> where TState : class
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

        protected static ULogger logger = LogFactory.GetLogger();

        public override void Enter(Miner entity)
        {
        }

        public override void Execute(Miner entity, float deltaTime)
        {
        }

        public override void Exit(Miner entity)
        {
        }
    }
}