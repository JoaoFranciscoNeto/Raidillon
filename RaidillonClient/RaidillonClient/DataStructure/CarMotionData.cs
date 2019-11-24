using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaidillonClient.DataStructure
{
    class CarMotionData
    {
        public float m_worldPositionX { get; internal set; }           // World space X position
        public float m_worldPositionY { get; internal set; }           // World space Y position
        public float m_worldPositionZ { get; internal set; }           // World space Z position
        public float m_worldVelocityX { get; internal set; }           // Velocity in world space X
        public float m_worldVelocityY { get; internal set; }           // Velocity in world space Y
        public float m_worldVelocityZ { get; internal set; }           // Velocity in world space Z
        public short m_worldForwardDirX { get; internal set; }         // World space forward X direction (normalised)
        public short m_worldForwardDirY { get; internal set; }         // World space forward Y direction (normalised)
        public short m_worldForwardDirZ { get; internal set; }         // World space forward Z direction (normalised)
        public short m_worldRightDirX { get; internal set; }           // World space right X direction (normalised)
        public short m_worldRightDirY { get; internal set; }           // World space right Y direction (normalised)
        public short m_worldRightDirZ { get; internal set; }           // World space right Z direction (normalised)
        public float m_gForceLateral { get; internal set; }            // Lateral G-Force component
        public float m_gForceLongitudinal { get; internal set; }       // Longitudinal G-Force component
        public float m_gForceVertical { get; internal set; }           // Vertical G-Force component
        public float m_yaw { get; internal set; }                      // Yaw angle in radians
        public float m_pitch { get; internal set; }                    // Pitch angle in radians
        public float m_roll { get; internal set; }                     // Roll angle in radians

        internal CarMotionData() { }

        public override string ToString()
        {
            return $"({m_worldPositionX},{m_worldPositionY},{m_worldPositionZ})";
        }
    }
}
