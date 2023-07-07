// *************************************************************************************
// FileName: EntityState.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 15:07:35
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Message;

namespace Common.FSM
{
    public abstract class EntityState<TEntityType>
    {
        public abstract void Enter(TEntityType entity);
        public abstract void Execute(TEntityType entity, float deltaTime);
        public abstract void Exit(TEntityType entity);
        public abstract bool OnMessage(TEntityType entity, Telegram telegram);
    }
}