// *************************************************************************************
// FileName: VisitBathroom.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 23:28:17
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Logger;

namespace Chapter02.Runtime.Entity
{
    public class VisitBathroom : MinersWifeStateBase<VisitBathroom>
    {
        public override void Enter(MinersWife entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Walkin' to the can. Need to powda mah pretty li'lle nose!"
            );
        }

        public override void Execute(MinersWife entity, float deltaTime)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Ahhhhhh! Sweet relief!"
            );

            entity.FSM().RevertToPreviousState();
        }

        public override void Exit(MinersWife entity)
        {
            IL.UL.Debug(
                $"{EntityNames.GetNameOfEntity(entity.ID())}: Leavin' the Jon!"
            );
        }
    }
}