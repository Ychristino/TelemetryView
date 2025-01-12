using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f121.Header;

namespace TelemetryViewer.Packets.f121.CarStatus
{
    // Structure for Car Status Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarStatusData
    {
        public byte m_tractionControl;           // Traction control - 0 = off, 1 = medium, 2 = full
        public byte m_antiLockBrakes;            // 0 (off) - 1 (on)
        public byte m_fuelMix;                   // Fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
        public byte m_frontBrakeBias;            // Front brake bias (percentage)
        public byte m_pitLimiterStatus;          // Pit limiter status - 0 = off, 1 = on
        public float m_fuelInTank;               // Current fuel mass
        public float m_fuelCapacity;             // Fuel capacity
        public float m_fuelRemainingLaps;        // Fuel remaining in terms of laps (value on MFD)
        public ushort m_maxRPM;                  // Cars max RPM, point of rev limiter
        public ushort m_idleRPM;                 // Cars idle RPM
        public byte m_maxGears;                  // Maximum number of gears
        public byte m_drsAllowed;                // 0 = not allowed, 1 = allowed, -1 = unknown
        public ushort m_drsActivationDistance;   // 0 = DRS not available, non-zero - DRS will be available in [X] metres
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresWear;               // Tyre wear percentage
        
        public byte m_actualTyreCompound;        // Actual tyre compound (F1 Modern / F2 / F1 Classic)
        public byte m_tyreVisualCompound;        // Visual tyre compound (can differ from actual compound)
        public byte m_tyresAgeLaps;              // Age in laps of the current set of tyres
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresDamage;             // Tyre damage (percentage)
        
        public byte m_frontLeftWingDamage;       // Front left wing damage (percentage)
        public byte m_frontRightWingDamage;      // Front right wing damage (percentage)
        public byte m_rearWingDamage;            // Rear wing damage (percentage)
        public byte m_drsFault;                  // Indicator for DRS fault, 0 = OK, 1 = fault
        public byte m_engineDamage;              // Engine damage (percentage)
        public byte m_gearBoxDamage;             // Gear box damage (percentage)
        
        public sbyte m_vehicleFiaFlags;          // FIA vehicle flags (-1 = invalid/unknown, 0 = none, 1 = green, etc.)
        
        public float m_ersStoreEnergy;           // ERS energy store in Joules
        public byte m_ersDeployMode;             // ERS deployment mode, 0 = none, 1 = medium, 2 = overtake, 3 = hotlap
        public float m_ersHarvestedThisLapMGUK; // ERS energy harvested this lap by MGU-K
        public float m_ersHarvestedThisLapMGUH; // ERS energy harvested this lap by MGU-H
        public float m_ersDeployedThisLap;      // ERS energy deployed this lap
    }

    // Structure for Packet Car Status Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarStatusData
    {
        public PacketHeader m_header;             // Header

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarStatusData[] m_carStatusData;  // Car status data for all cars on track
    }
}
