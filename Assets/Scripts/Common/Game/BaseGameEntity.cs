// *************************************************************************************
// FileName: BaseGameEntity.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-04 14:41:05
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

namespace Common.Game
{
    public partial class BaseGameEntity
    {
        private int m_Id;

        public BaseGameEntity(int id)
        {
            SetId(id);
        }

        public int ID()
        {
            return m_Id;
        }

        public int Id()
        {
            return m_Id;
        }

        private void SetId(int val)
        {
            m_Id = val;
        }
    }
}