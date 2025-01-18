using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f121.Header;

namespace TelemetryViewer.Packets.f121.SessionHistory
{
    // Structure for Lap History Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapHistoryData
    {
        public uint m_lapTimeInMS;           // Lap time in milliseconds
        public ushort m_sector1TimeInMS;     // Sector 1 time in milliseconds
        public ushort m_sector2TimeInMS;     // Sector 2 time in milliseconds
        public ushort m_sector3TimeInMS;     // Sector 3 time in milliseconds
        public byte m_lapValidBitFlags;      // 0x01 bit set-lap valid, 0x02 bit set-sector 1 valid
                                            // 0x04 bit set-sector 2 valid, 0x08 bit set-sector 3 valid
    }

    // Structure for Tyre Stint History Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TyreStintHistoryData
    {
        public byte m_endLap;               // Lap the tyre usage ends on (255 for current tyre)
        public byte m_tyreActualCompound;   // Actual tyres used by this driver
        public byte m_tyreVisualCompound;   // Visual tyres used by this driver
    }

    // Structure for Packet Session History Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketSessionHistory
    {
        public PacketHeader m_header;                // Header
        public byte m_carIdx;                        // Index of the car this lap data relates to
        public byte m_numLaps;                       // Number of laps in the data (including current partial lap)
        public byte m_numTyreStints;                 // Number of tyre stints in the data
        public byte m_bestLapTimeLapNum;             // Lap the best lap time was achieved on
        public byte m_bestSector1LapNum;             // Lap the best Sector 1 time was achieved on
        public byte m_bestSector2LapNum;             // Lap the best Sector 2 time was achieved on
        public byte m_bestSector3LapNum;             // Lap the best Sector 3 time was achieved on

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public LapHistoryData[] m_lapHistoryData;   // 100 laps of data max

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public TyreStintHistoryData[] m_tyreStintsHistoryData; // Tyre stint history data (up to 8)
    }
}
