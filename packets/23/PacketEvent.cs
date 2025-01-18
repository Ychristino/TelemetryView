using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Event
{
    // União para armazenar diferentes tipos de detalhes de eventos
    public struct EventDataDetails
    {
        // Detalhes para o evento de volta mais rápida
        public struct FastestLap
        {
            public byte VehicleIdx; // Índice do veículo que obteve a volta mais rápida
            public float LapTime;   // Tempo da volta em segundos
        }

        // Detalhes para o evento de aposentadoria
        public struct Retirement
        {
            public byte VehicleIdx; // Índice do veículo que se aposentou
        }

        // Detalhes para o evento de companheiro de equipe nos pits
        public struct TeamMateInPits
        {
            public byte VehicleIdx; // Índice do veículo do companheiro de equipe nos pits
        }

        // Detalhes para o evento de vencedor da corrida
        public struct RaceWinner
        {
            public byte VehicleIdx; // Índice do veículo vencedor da corrida
        }

        // Detalhes para o evento de penalidade
        public struct Penalty
        {
            public byte PenaltyType;    // Tipo de penalidade - ver os anexos
            public byte InfringementType; // Tipo de infração - ver os anexos
            public byte VehicleIdx;      // Índice do veículo penalizado
            public byte OtherVehicleIdx; // Índice do outro veículo envolvido
            public byte Time;            // Tempo ganho, ou tempo gasto realizando a ação em segundos
            public byte LapNum;          // Volta onde a penalidade ocorreu
            public byte PlacesGained;    // Número de posições ganhas por isso
        }

        // Detalhes para o evento de medição de velocidade
        public struct SpeedTrap
        {
            public byte VehicleIdx;                // Índice do veículo que ativou o radar de velocidade
            public float Speed;                     // Velocidade máxima atingida em quilômetros por hora
            public byte IsOverallFastestInSession;  // 1 se for a maior velocidade geral da sessão, caso contrário 0
            public byte IsDriverFastestInSession;   // 1 se for a maior velocidade do piloto na sessão, caso contrário 0
            public byte FastestVehicleIdxInSession; // Índice do veículo mais rápido da sessão
            public float FastestSpeedInSession;     // Velocidade do veículo mais rápido na sessão
        }

        // Detalhes para o evento de luzes de largada
        public struct StartLights
        {
            public byte NumLights; // Número de luzes acesas
        }

        // Detalhes para o evento de penalidade de drive-through servida
        public struct DriveThroughPenaltyServed
        {
            public byte VehicleIdx; // Índice do veículo servindo a penalidade de drive-through
        }

        // Detalhes para o evento de penalidade de stop-go servida
        public struct StopGoPenaltyServed
        {
            public byte VehicleIdx; // Índice do veículo servindo a penalidade de stop-go
        }

        // Detalhes para o evento de retroceder no tempo (flashback)
        public struct Flashback
        {
            public uint FlashbackFrameIdentifier;   // Identificador do quadro para o qual foi retrocedido
            public float FlashbackSessionTime;      // Tempo da sessão para o qual foi retrocedido
        }

        // Detalhes para o evento de botões pressionados
        public struct Buttons
        {
            public uint ButtonStatus; // Flags de bits especificando quais botões estão sendo pressionados
            // atualmente - ver anexos
        }

        // Detalhes para o evento de ultrapassagem
        public struct Overtake
        {
            public byte OvertakingVehicleIdx;      // Índice do veículo que está ultrapassando
            public byte BeingOvertakenVehicleIdx;  // Índice do veículo que está sendo ultrapassado
        }

        // Membros para armazenar diferentes tipos de eventos
        public FastestLap fastestLap;
        public Retirement retirement;
        public TeamMateInPits teamMateInPits;
        public RaceWinner raceWinner;
        public Penalty penalty;
        public SpeedTrap speedTrap;
        public StartLights startLights;
        public DriveThroughPenaltyServed driveThroughPenaltyServed;
        public StopGoPenaltyServed stopGoPenaltyServed;
        public Flashback flashback;
        public Buttons buttons;
        public Overtake overtake;
    }

    // Pacote de dados do evento
    public struct PacketEvent
    {
        public PacketHeader Header;              // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] EventStringCode;           // Código da string do evento (4 bytes)
        public EventDataDetails EventDetails;    // Detalhes do evento - interpretados de forma diferente
                                               // para cada tipo de evento
    }
}
