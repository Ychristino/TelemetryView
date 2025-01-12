using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Lap
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapData
    {
        public uint LastLapTimeInMS;             // Last lap time in milliseconds
        public uint CurrentLapTimeInMS;         // Current time around the lap in milliseconds
        public ushort Sector1TimeInMS;          // Sector 1 time in milliseconds
        public byte Sector1TimeMinutes;         // Sector 1 whole minute part
        public ushort Sector2TimeInMS;          // Sector 2 time in milliseconds
        public byte Sector2TimeMinutes;         // Sector 2 whole minute part
        public ushort DeltaToCarInFrontInMS;    // Time delta to car in front in milliseconds
        public ushort DeltaToRaceLeaderInMS;    // Time delta to race leader in milliseconds
        public float LapDistance;              // Distance vehicle is around current lap in metres
        public float TotalDistance;            // Total distance travelled in session in metres
        public float SafetyCarDelta;           // Delta in seconds for safety car
        public byte CarPosition;               // Car race position
        public byte CurrentLapNum;             // Current lap number
        public byte PitStatus;                 // 0 = none, 1 = pitting, 2 = in pit area
        public byte NumPitStops;               // Number of pit stops taken in this race
        public byte Sector;                    // 0 = sector1, 1 = sector2, 2 = sector3
        public byte CurrentLapInvalid;         // 0 = valid, 1 = invalid
        public byte Penalties;                 // Accumulated time penalties in seconds
        public byte TotalWarnings;             // Accumulated number of warnings issued
        public byte CornerCuttingWarnings;     // Accumulated corner cutting warnings
        public byte NumUnservedDriveThroughPens; // Num drive through pens left to serve
        public byte NumUnservedStopGoPens;     // Num stop go pens left to serve
        public byte GridPosition;              // Grid position the vehicle started the race in
        public byte DriverStatus;              // Driver status
        public byte ResultStatus;              // Result status
        public byte PitLaneTimerActive;        // Pit lane timing active: 0 = inactive, 1 = active
        public ushort PitLaneTimeInLaneInMS;   // Time spent in the pit lane in ms
        public ushort PitStopTimerInMS;        // Time of the actual pit stop in ms
        public byte PitStopShouldServePen;     // Should serve penalty at this stop
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLapData
    {
        public PacketHeader Header;                         // Packet header
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LapData[] LapData;                           // Lap data for all cars on track
        public byte TimeTrialPBCarIdx;                      // Index of Personal Best car in time trial
        public byte TimeTrialRivalCarIdx;                   // Index of Rival car in time trial
    }
}
