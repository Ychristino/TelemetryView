using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f121.Header;

namespace TelemetryViewer.Packets.f121.FinalClassification
{
    // Structure for Final Classification Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FinalClassificationData
    {
        public byte m_position;               // Finishing position
        public byte m_numLaps;                // Number of laps completed
        public byte m_gridPosition;           // Grid position of the car
        public byte m_points;                 // Number of points scored
        public byte m_numPitStops;            // Number of pit stops made
        public byte m_resultStatus;           // Result status
                                              // 0 = invalid, 1 = inactive, 2 = active
                                              // 3 = finished, 4 = disqualified, 5 = not classified
                                              // 6 = retired
        public float m_bestLapTime;           // Best lap time of the session in seconds
        public double m_totalRaceTime;        // Total race time in seconds without penalties
        public byte m_penaltiesTime;          // Total penalties accumulated in seconds
        public byte m_numPenalties;           // Number of penalties applied to this driver
        public byte m_numTyreStints;          // Number of tyre stints up to maximum

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsActual;     // Actual tyres used by this driver

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsVisual;     // Visual tyres used by this driver
    }

    // Structure for Packet Final Classification Data
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketFinalClassificationData
    {
        public PacketHeader m_header;              // Header
        public byte m_numCars;                     // Number of cars in the final classification

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public FinalClassificationData[] m_classificationData;  // Final classification data for all cars
    }
}
