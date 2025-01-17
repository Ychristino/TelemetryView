using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f121.Header;

namespace TelemetryViewer.Packets.f121.Lap
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapData
    {
        public uint m_lastLapTimeInMS;              // Last lap time in milliseconds
        public uint m_currentLapTimeInMS;           // Current time around the lap in milliseconds
        public ushort m_sector1TimeInMS;           // Sector 1 time in milliseconds
        public ushort m_sector2TimeInMS;           // Sector 2 time in milliseconds
        public float m_lapDistance;                 // Distance vehicle is around current lap in metres
        public float m_totalDistance;               // Total distance travelled in session in metres
        public float m_safetyCarDelta;             // Delta in seconds for safety car
        public byte m_carPosition;                 // Car race position
        public byte m_currentLapNum;               // Current lap number
        public byte m_pitStatus;                   // 0 = none, 1 = pitting, 2 = in pit area
        public byte m_numPitStops;                 // Number of pit stops taken in this race
        public byte m_sector;                      // 0 = sector1, 1 = sector2, 2 = sector3
        public byte m_currentLapInvalid;           // Current lap invalid - 0 = valid, 1 = invalid
        public byte m_penalties;                   // Accumulated time penalties in seconds to be added
        public byte m_warnings;                    // Accumulated number of warnings issued
        public byte m_numUnservedDriveThroughPens; // Num drive through pens left to serve
        public byte m_numUnservedStopGoPens;       // Num stop go pens left to serve
        public byte m_gridPosition;                // Grid position the vehicle started the race in
        public byte m_driverStatus;                // Status of driver - 0 = in garage, 1 = flying lap
                                                   // 2 = in lap, 3 = out lap, 4 = on track
        public byte m_resultStatus;                // Result status - 0 = invalid, 1 = inactive, 2 = active
                                                   // 3 = finished, 4 = didnotfinish, 5 = disqualified
                                                   // 6 = not classified, 7 = retired
        public byte m_pitLaneTimerActive;          // Pit lane timing, 0 = inactive, 1 = active
        public ushort m_pitLaneTimeInLaneInMS;     // If active, the current time spent in the pit lane in ms
        public ushort m_pitStopTimerInMS;          // Time of the actual pit stop in ms
        public byte m_pitStopShouldServePen;       // Whether the car should serve a penalty at this stop
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLap
    {
        public PacketHeader m_header;              // Header

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LapData[] m_lapData;                // Lap data for all cars on track
    }
}
