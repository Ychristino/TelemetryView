using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f120.Header;

namespace TelemetryViewer.Packets.f120.Event
{
    // Enum para definir os tipos de evento
    public enum EventType
    {
        FastestLap = 1,
        Retirement = 2,
        TeamMateInPits = 3,
        RaceWinner = 4,
        Penalty = 5,
        SpeedTrap = 6
    }

    // A estrutura que contém os dados do evento
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EventDataDetails
    {
        public EventType eventType; // Tipo do evento (define qual estrutura deve ser lida)

        // Estrutura para o evento "FastestLap"
        public struct FastestLapDetails
        {
            public byte vehicleIdx;   // Vehicle index of car achieving fastest lap
            public float lapTime;     // Lap time in seconds
        }
        
        // Estrutura para o evento "Retirement"
        public struct RetirementDetails
        {
            public byte vehicleIdx;   // Vehicle index of car retiring
        }

        // Estrutura para o evento "TeamMateInPits"
        public struct TeamMateInPitsDetails
        {
            public byte vehicleIdx;   // Vehicle index of team mate
        }

        // Estrutura para o evento "RaceWinner"
        public struct RaceWinnerDetails
        {
            public byte vehicleIdx;   // Vehicle index of the race winner
        }

        // Estrutura para o evento "Penalty"
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

        // Estrutura para o evento "SpeedTrap"
        public struct SpeedTrapDetails
        {
            public byte vehicleIdx; // Vehicle index of the vehicle triggering speed trap
            public float speed;     // Top speed achieved in km/h
        }

        // Estruturas reais de dados baseadas no tipo de evento
        public FastestLapDetails fastestLap;
        public RetirementDetails retirement;
        public TeamMateInPitsDetails teamMateInPits;
        public RaceWinnerDetails raceWinner;
        public PenaltyDetails penalty;
        public SpeedTrapDetails speedTrap;
    }

    // Estrutura do pacote de dados de evento
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketEventData
    {
        public PacketHeader m_header;               // Cabeçalho do pacote

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_eventStringCode;            // Código de evento (4 bytes)
        
        public EventDataDetails m_eventDetails;     // Detalhes do evento, pode variar dependendo do tipo
    }
}
