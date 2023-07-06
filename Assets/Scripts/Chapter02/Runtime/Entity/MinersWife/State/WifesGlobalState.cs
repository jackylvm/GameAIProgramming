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

        public override void Exit(MinersWife entity)
        {
        }
    }
}