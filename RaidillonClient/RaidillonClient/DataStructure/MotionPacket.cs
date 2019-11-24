using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class MotionPacket : DataPacket
    {
        internal static int nCars = 20;
        internal static int nPoints = 4;

        public CarMotionData[] m_carMotionData { get; internal set; }         // Data for all cars on track

        // Extra player car ONLY data
        public float[] m_suspensionPosition { get; internal set; }        // Note: All wheel arrays have the following order:
        public float[] m_suspensionVelocity { get; internal set; }        // RL, RR, FL, FR
        public float[] m_suspensionAcceleration { get; internal set; }   // RL, RR, FL, FR
        public float[] m_wheelSpeed{ get; internal set; }               // Speed of each wheel
        public float[] m_wheelSlip{ get; internal set; }                 // Slip ratio for each wheel
        public float m_localVelocityX { get; internal set; }              // Velocity in local space
        public float m_localVelocityY { get; internal set; }              // Velocity in local space
        public float m_localVelocityZ { get; internal set; }              // Velocity in local space
        public float m_angularVelocityX { get; internal set; }        // Angular velocity x-component
        public float m_angularVelocityY { get; internal set; }             // Angular velocity y-component
        public float m_angularVelocityZ { get; internal set; }             // Angular velocity z-component
        public float m_angularAccelerationX { get; internal set; }         // Angular velocity x-component
        public float m_angularAccelerationY { get; internal set; }    // Angular velocity y-component
        public float m_angularAccelerationZ { get; internal set; }         // Angular velocity z-component
        public float m_frontWheelsAngle { get; internal set; }             // Current front wheels angle in radians
    }
}
