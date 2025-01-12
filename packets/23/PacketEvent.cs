using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Event
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventDataDetails
    {
        // Union de detalhes do evento - apenas uma dessas estruturas será válida por vez
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct FastestLap
        {
            public byte VehicleIdx; // Vehicle index of car achieving fastest lap
            public float LapTime;   // Lap time is in seconds
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Retirement
        {
            public byte VehicleIdx; // Vehicle index of car retiring
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct TeamMateInPits
        {
            public byte VehicleIdx; // Vehicle index of team mate
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct RaceWinner
        {
            public byte VehicleIdx; // Vehicle index of the race winner
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Penalty
        {
            public byte PenaltyType;       // Penalty type – see Appendices
            public byte InfringementType;  // Infringement type – see Appendices
            public byte VehicleIdx;        // Vehicle index of the car the penalty is applied to
            public byte OtherVehicleIdx;   // Vehicle index of the other car involved
            public byte Time;              // Time gained or spent doing action in seconds
            public byte LapNum;            // Lap the penalty occurred on
            public byte PlacesGained;      // Number of places gained by this
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SpeedTrap
        {
            public byte VehicleIdx;                // Vehicle index of the vehicle triggering speed trap
            public float Speed;                   // Top speed achieved in km/h
            public byte IsOverallFastestInSession; // Overall fastest speed in session = 1, otherwise 0
            public byte IsDriverFastestInSession;  // Fastest speed for driver in session = 1, otherwise 0
            public byte FastestVehicleIdxInSession; // Vehicle index of the vehicle that is the fastest in this session
            public float FastestSpeedInSession;    // Speed of the vehicle that is the fastest in this session
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct StartLights
        {
            public byte NumLights; // Number of lights showing
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DriveThroughPenaltyServed
        {
            public byte VehicleIdx; // Vehicle index of the vehicle serving drive through
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct StopGoPenaltyServed
        {
            public byte VehicleIdx; // Vehicle index of the vehicle serving stop go
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Flashback
        {
            public uint FlashbackFrameIdentifier;  // Frame identifier flashed back to
            public float FlashbackSessionTime;     // Session time flashed back to
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Buttons
        {
            public uint ButtonStatus; // Bit flags specifying which buttons are being pressed currently
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Overtake
        {
            public byte OvertakingVehicleIdx;      // Vehicle index of the vehicle overtaking
            public byte BeingOvertakenVehicleIdx;  // Vehicle index of the vehicle being overtaken
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketEventData
    {
        public PacketHeader Header;               // Header
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] EventStringCode;            // Event string code
        public EventDataDetails EventDetails;     // Event details, interpreted differently for each type
    }
}
