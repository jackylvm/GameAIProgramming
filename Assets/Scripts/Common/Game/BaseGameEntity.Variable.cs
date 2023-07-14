// *************************************************************************************
// FileName: BaseGameEntity.Variable.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-12 23:31:43
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using UnityEngine;

namespace Common.Game
{
    public partial class BaseGameEntity
    {
        /// <summary>
        ///  位置
        /// </summary>
        protected Vector3 m_vPos;

        public Vector3 Pos
        {
            get => m_vPos;
            set => m_vPos = value;
        }

        /// <summary>
        /// 缩放
        /// </summary>
        protected Vector3 m_vScale;

        public Vector3 Scale
        {
            get => m_vScale;
            set => m_vScale = value;
        }

        /// <summary>
        /// 边界半径
        /// </summary>
        protected float m_dBoundingRadius;

        public float BRadius
        {
            get => m_dBoundingRadius;
            set => m_dBoundingRadius = value;
        }
    }
}