// *************************************************************************************
// FileName: StateMachine.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 15:09:00
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

namespace Common.FSM
{
    public class StateMachine<TEntityType>
    {
        private readonly TEntityType m_Owner;

        /// <summary>
        /// 当前状态
        /// </summary>
        private EntityState<TEntityType> CState { get; set; }

        /// <summary>
        /// 上一状态
        /// </summary>
        private EntityState<TEntityType> PState { get; set; }

        /// <summary>
        /// 全局状态
        /// </summary>
        private EntityState<TEntityType> GState { get; set; }

        public StateMachine(TEntityType owner)
        {
            m_Owner = owner;

            CState = null;
            PState = null;
            GState = null;
        }

        public void SetGlobalState(EntityState<TEntityType> state)
        {
            GState = state;
        }

        public void Update(float deltaTime)
        {
            GState?.Execute(m_Owner, deltaTime);
            CState?.Execute(m_Owner, deltaTime);
        }

        public void ChangeState(EntityState<TEntityType> state)
        {
            PState = CState;
            CState?.Exit(m_Owner);
            CState = state;
            CState?.Enter(m_Owner);
        }

        public void RevertToPreviousState()
        {
            ChangeState(PState);
        }
    }
}