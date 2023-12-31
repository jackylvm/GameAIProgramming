// *************************************************************************************
// FileName: SteeringBehaviors.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-12 22:49:16
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

using Chapter03.Runtime.Entity;
using UnityEngine;

namespace Chapter03.Runtime.World
{
    public partial class SteeringBehaviors
    {
        private readonly Vehicle m_pVehicle;

        public SteeringBehaviors(Vehicle vehicle)
        {
            m_pVehicle = vehicle;
        }

        public Vector3 ForwardComponent()
        {
            return Vector3.zero;
        }

        public Vector3 SideComponent()
        {
            return Vector3.zero;
        }

        public void SetPath()
        {
        }

        public void SetTarget(Vector3 val)
        {
        }

        public void SetTargetAgent1(Vehicle vehicle)
        {
        }

        public void SetTargetAgent2(Vehicle vehicle)
        {
        }
    }
}