// *************************************************************************************
// FileName: DoHouseWork.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-06 23:27:40
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Logger;
using UnityEngine;

namespace Chapter02.Runtime.Entity
{
    public class DoHouseWork : MinersWifeStateBase<DoHouseWork>
    {
        public override void Enter(MinersWife entity)
        {
        }

        public override void Execute(MinersWife entity, float deltaTime)
        {
            var random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                {
                    IL.UL.Debug(
                        $"{EntityNames.GetNameOfEntity(entity.ID())}: Moppin' the floor!"
                    );
                    break;
                }
                case 1:
                {
                    IL.UL.Debug(
                        $"{EntityNames.GetNameOfEntity(entity.ID())}: Washin' the dishes!"
                    );
                    break;
                }
                case 2:
                {
                    IL.UL.Debug(
                        $"{EntityNames.GetNameOfEntity(entity.ID())}: Makin' the bed!"
                    );
                    break;
                }
            }
        }

        public override void Exit(MinersWife entity)
        {
        }
    }
}