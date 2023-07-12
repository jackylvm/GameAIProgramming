// *************************************************************************************
// FileName: Vehicle.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-12 22:45:49
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter03.Runtime.World;
using Common.Extension;

namespace Chapter03.Runtime.Entity
{
    public class Vehicle : MovingEntity
    {
        private GameWorld GameWorld { get; set; }
        private SteeringBehaviors SteeringBehaviors { get; set; }

        public Vehicle(int id) : base(id)
        {
        }

        public override void DoStart()
        {
            base.DoStart();
        }

        public override void DoUpdate(float deltaTime)
        {
            var steeringForce = SteeringBehaviors.Calculate();
            var acceleration = steeringForce / m_dMass;

            m_vVelocity += acceleration * deltaTime;
            m_vVelocity.Truncate(m_dMaxSpeed);

            m_vPos += m_vVelocity * deltaTime;

            if (m_vVelocity.sqrMagnitude > float.Epsilon)
            {
                m_vHeading = m_vVelocity.normalized;
                m_vSide = m_vHeading.Perp();
            }
        }
    }
}