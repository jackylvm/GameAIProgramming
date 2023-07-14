// *************************************************************************************
// FileName: MovingEntity.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-12 22:34:50
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Common.Game;
using UnityEngine;

namespace Chapter03.Runtime.Entity
{
    public partial class MovingEntity : BaseGameEntity
    {
        /// <summary>
        /// 速度
        /// </summary>
        protected Vector3 m_vVelocity;

        public Vector3 Velocity
        {
            get => m_vVelocity;
            set => m_vVelocity = value;
        }

        public float Speed => m_vVelocity.magnitude;
        public float SpeedSq => m_vVelocity.sqrMagnitude;

        /// <summary>
        /// 归一化向量,指向实体的朝向
        /// </summary>
        protected Vector3 m_vHeading;

        public Vector3 Heading
        {
            get => m_vHeading;
            set => m_vHeading = value;
        }

        /// <summary>
        /// 垂直于朝向向量的向量
        /// </summary>
        protected Vector3 m_vSide;

        public Vector3 Side
        {
            get => m_vSide;
            set => m_vSide = value;
        }

        /// <summary>
        /// 实体质量
        /// </summary>
        protected float m_dMass;

        public float Mass
        {
            get => m_dMass;
            set => m_dMass = value;
        }

        /// <summary>
        /// 最大速度
        /// </summary>
        protected float m_dMaxSpeed;

        public float MaxSpeed
        {
            get => m_dMaxSpeed;
            set => m_dMaxSpeed = value;
        }

        /// <summary>
        /// 最大动力
        /// </summary>
        protected float m_dMaxForce;

        public float MaxForce
        {
            get => m_dMaxForce;
            set => m_dMaxForce = value;
        }

        /// <summary>
        /// 最大旋转速率(弧度每秒)
        /// </summary>
        protected float m_dMaxTurnRate;

        public float MaxTurnRate
        {
            get => m_dMaxTurnRate;
            set => m_dMaxTurnRate = value;
        }

        public MovingEntity(int id) : base(id)
        {
        }
    }
}