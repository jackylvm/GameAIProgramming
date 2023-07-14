// *************************************************************************************
// FileName: SteeringBehaviors.Options.cs
// Description:
// 
// Version: v1.0.0
// Creator: Jacky(jackylvm@foxmail.com)
// CreationTime: 2023-07-14 23:40:00
// ==============================================================
// History update record:
// 
// ==============================================================
// *************************************************************************************

namespace Chapter03.Runtime.World
{
    public partial class SteeringBehaviors
    {
        private float m_dWanderJitter;
        private float m_dWanderRadius;
        private float m_dWanderDistance;

        private float m_dWeightSeparation;
        private float m_dWeightCohesion;
        private float m_dWeightAlignment;
        private float m_dWeightWander;
        private float m_dWeightObstacleAvoidance;
        private float m_dWeightWallAvoidance;
        private float m_dWeightSeek;
        private float m_dWeightFlee;
        private float m_dWeightArrive;
        private float m_dWeightPursuit;
        private float m_dWeightOffsetPursuit;
        private float m_dWeightInterpose;
        private float m_dWeightHide;
        private float m_dWeightEvade;
        private float m_dWeightFollowPath;
    }
}