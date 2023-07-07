// *************************************************************************************
// FileName: EntityMgr.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-07 22:55:41
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using System.Collections.Generic;
using Common.Game;

namespace Chapter02.Runtime.Entity
{
    public class EntityMgr
    {
        #region 单例模式

        private static EntityMgr m_Instance = null;

        public static EntityMgr Inst()
        {
            return m_Instance ??= new EntityMgr();
        }

        #endregion

        private readonly Dictionary<int, BaseGameEntity> m_Entities = new Dictionary<int, BaseGameEntity>();

        public void RegisterEntity(BaseGameEntity val)
        {
            m_Entities.TryAdd(val.Id(), val);
        }

        public BaseGameEntity GetEntityFromID(int Id)
        {
            return m_Entities.TryGetValue(Id, out var entity) ? entity : null;
        }

        public void RemoveEntity(BaseGameEntity val)
        {
            m_Entities.Remove(val.Id());
        }
    }
}