using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f121.Header;

namespace TelemetryViewer.Packets.f121.CarTelemetry
{
    // Structure for Car Telemetry Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarTelemetryData
    {
        public ushort m_speed;                   // Speed of car in kilometres per hour
        public float m_throttle;                 // Amount of throttle applied (0.0 to 1.0)
        public float m_steer;                    // Steering (-1.0 (full lock left) to 1.0 (full lock right))
        public float m_brake;                    // Amount of brake applied (0.0 to 1.0)
        public byte m_clutch;                    // Amount of clutch applied (0 to 100)
        public sbyte m_gear;                     // Gear selected (1-8, N=0, R=-1)
        public ushort m_engineRPM;               // Engine RPM
        public byte m_drs;                       // 0 = off, 1 = on
        public byte m_revLightsPercent;          // Rev lights indicator (percentage)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] m_brakesTemperature;     // Brakes temperature (celsius)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresSurfaceTemperature; // Tyres surface temperature (celsius)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresInnerTemperature;   // Tyres inner temperature (celsius)

        public ushort m_engineTemperature;       // Engine temperature (celsius)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_tyresPressure;          // Tyres pressure (PSI)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_surfaceType;             // Driving surface, see appendices
    }

    // Structure for Packet Car Telemetry Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarTelemetry
    {
        public PacketHeader m_header;            // Header

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarTelemetryData[] m_carTelemetryData;  // Data for all cars on track

        public uint m_buttonStatus;               // Bit flags specifying which buttons are being pressed currently - see appendices

        public byte m_mfdPanelIndex;              // Index of MFD panel open - 255 = MFD closed
                                                 // Single player, race – 0 = Car setup, 1 = Pits
                                                 // 2 = Damage, 3 = Engine, 4 = Temperatures
                                                 // May vary depending on game mode

        public byte m_mfdPanelIndexSecondaryPlayer; // See above

        public sbyte m_suggestedGear;             // Suggested gear for the player (1-8), 0 if no gear suggested
    }
}
