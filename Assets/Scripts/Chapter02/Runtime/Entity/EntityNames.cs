// *************************************************************************************
// FileName: EntityNames.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 23:58
// Copyright: 2021 - 2023 咔丘互娱（上海）网络科技有限公司
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter02.Runtime.Enum;

namespace Chapter02.Runtime.Entity
{
    public static class EntityNames
    {
        public static string GetNameOfEntity(int val)
        {
            var en = (EmEntity) val;
            return en switch
            {
                EmEntity.EntMinerBob => "Miner Bob",
                EmEntity.EntElsa => "Elsa",
                _ => "UNKNOWN!"
            };
        }
    }
}