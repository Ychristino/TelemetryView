using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f121.Header;

namespace TelemetryViewer.Packets.f121.Event
{
    // Enum to define event types
    public enum EventType
    {
        FastestLap = 1,
        Retirement = 2,
        TeamMateInPits = 3,
        RaceWinner = 4,
        Penalty = 5,
        SpeedTrap = 6
    }

    // Structure for event data details
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventDataDetails
    {
        public EventType eventType; // Event type (determines which structure to read)

        // Structure for the "FastestLap" event
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FastestLapDetails
        {
            public byte vehicleIdx; // Vehicle index of car achieving fastest lap
            public float lapTime;   // Lap time in seconds
        }
        
        // Structure for the "Retirement" event
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RetirementDetails
        {
            public byte vehicleIdx; // Vehicle index of car retiring
        }

        // Structure for the "TeamMateInPits" event
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TeamMateInPitsDetails
        {
            public byte vehicleIdx; // Vehicle index of team mate
        }

        // Structure for the "RaceWinner" event
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RaceWinnerDetails
        {
            public byte vehicleIdx; // Vehicle index of the race winner
        }

        // Structure for the "Penalty" event
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PenaltyDetails
        {
            public byte penaltyType;      // Penalty type
            public byte infringementType; // Infringement type
            public byte vehicleIdx;       // Vehicle index of the car the penalty is applied to
            public byte otherVehicleIdx;  // Vehicle index of the other car involved
            public byte time;             // Time gained or spent doing the action in seconds
            public byte lapNum;           // Lap the penalty occurred on
            public byte placesGained;     // Number of places gained by this
        }

        // Structure for the "SpeedTrap" event
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SpeedTrapDetails
        {
            public byte vehicleIdx;       // Vehicle index of the vehicle triggering speed trap
            public float speed;           // Top speed achieved in km/h
            public byte overallFastestInSession; // Overall fastest speed in session = 1, otherwise 0
            public byte driverFastestInSession;  // Fastest speed for driver in session = 1, otherwise 0
        }

        // Fields representing the actual data for each event type
        public FastestLapDetails fastestLap;
        public RetirementDetails retirement;
        public TeamMateInPitsDetails teamMateInPits;
        public RaceWinnerDetails raceWinner;
        public PenaltyDetails penalty;
        public SpeedTrapDetails speedTrap;
    }

    // Structure for event data packet
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketEvent
    {
        public PacketHeader m_header;               // Packet header

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_eventStringCode;            // Event string code (4 bytes)

        public EventDataDetails m_eventDetails;     // Event details (varies by event type)
    }
}
