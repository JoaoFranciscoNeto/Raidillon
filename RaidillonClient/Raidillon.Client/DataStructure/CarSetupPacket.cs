using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidillon.Client.DataStructure
{
    class CarSetupPacket : DataPacket
    {

        public class CarSetupData
        {
            public byte m_frontWing{get;internal set;}                // Front wing aero
            public byte m_rearWing{get;internal set;}                 // Rear wing aero
            public byte m_onThrottle {get;internal set;}               // Differential adjustment on throttle (percentage)
            public byte m_offThrottle {get;internal set;}              // Differential adjustment off throttle (percentage)
            public float m_frontCamber {get;internal set;}              // Front camber angle (suspension geometry)
            public float m_rearCamber {get;internal set;}               // Rear camber angle (suspension geometry)
            public float m_frontToe {get;internal set;}                 // Front toe angle (suspension geometry)
            public float m_rearToe {get;internal set;}                  // Rear toe angle (suspension geometry)
            public byte m_frontSuspension {get;internal set;}          // Front suspension
            public byte m_rearSuspension {get;internal set;}           // Rear suspension
            public byte m_frontAntiRollBar {get;internal set;}         // Front anti-roll bar
            public byte m_rearAntiRollBar {get;internal set;}          // Front anti-roll bar
            public byte m_frontSuspensionHeight {get;internal set;}    // Front ride height
            public byte m_rearSuspensionHeight {get;internal set;}     // Rear ride height
            public byte m_brakePressure {get;internal set;}            // Brake pressure (percentage)
            public byte m_brakeBias {get;internal set;}                // Brake bias (percentage)
            public float m_frontTyrePressure {get;internal set;}        // Front tyre pressure (PSI)
            public float m_rearTyrePressure {get;internal set;}         // Rear tyre pressure (PSI)
            public byte m_ballast {get;internal set;}                  // Ballast
            public float m_fuelLoad {get;internal set;}                 // Fuel load
        }

        public CarSetupData[] m_carSetups { get; internal set; }
    }
}
