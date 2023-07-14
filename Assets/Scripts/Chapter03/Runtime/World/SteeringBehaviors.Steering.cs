// *************************************************************************************
// FileName: SteeringBehaviors.Steering.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-14 23:04:18
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter03.Runtime.Entity;
using Common.Enum;
using UnityEngine;

namespace Chapter03.Runtime.World
{
    public partial class SteeringBehaviors
    {
        public Vector3 Seek(Vector3 targetPos)
        {
            var desiredVelocity = (targetPos - m_pVehicle.Pos).normalized * m_pVehicle.MaxSpeed;
            return desiredVelocity - m_pVehicle.Velocity;
        }

        public Vector3 Flee(Vector3 targetPos)
        {
            var desiredVelocity = (m_pVehicle.Pos - targetPos).normalized * m_pVehicle.MaxSpeed;
            return desiredVelocity - m_pVehicle.Velocity;
        }

        public Vector3 Arrive(Vector3 targetPos, Deceleration deceleration)
        {
            var toTarget = targetPos - m_pVehicle.Pos;

            var dist = toTarget.magnitude;
            if (dist > 0)
            {
                const float DecelerationTweaker = 0.3f;

                var speed = dist / ((float) deceleration * DecelerationTweaker);
                speed = Mathf.Min(speed, m_pVehicle.MaxSpeed);

                var desiredVelocity = toTarget * speed / dist;
                return desiredVelocity - m_pVehicle.Velocity;
            }

            return Vector3.zero;
        }

        public Vector3 Pursuit(Vehicle evader)
        {
            var toEvader = evader.Pos - m_pVehicle.Pos;

            var RelativeHeading = Vector3.Dot(m_pVehicle.Heading, evader.Heading);

            if (
                (Vector3.Dot(toEvader, m_pVehicle.Heading) > 0) &&
                (RelativeHeading < -0.95) //acos(0.95)=18 degs
            )
            {
                return Seek(evader.Pos);
            }

            var lookAheadTime = toEvader.magnitude / (m_pVehicle.MaxSpeed + evader.Speed);
            return Seek(evader.Pos + evader.Velocity * lookAheadTime);
        }

        public Vector3 Evade(Vehicle pursuer)
        {
            var toPursuer = pursuer.Pos - m_pVehicle.Pos;

            const float ThreatRange = 100.0f;
            if (toPursuer.sqrMagnitude > ThreatRange * ThreatRange)
            {
                return Vector3.zero;
            }

            var lookAheadTime = toPursuer.magnitude / (m_pVehicle.MaxSpeed + pursuer.Speed);
            return Flee(pursuer.Pos + pursuer.Velocity * lookAheadTime);
        }
    }
}