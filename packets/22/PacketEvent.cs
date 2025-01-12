using System;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Event
{
    // União para armazenar diferentes tipos de detalhes de eventos
    public struct EventDataDetails
    {
        // Detalhes para o evento de volta mais rápida
        public struct FastestLap
        {
            public byte vehicleIdx; // Índice do veículo que obteve a volta mais rápida
            public float lapTime;   // Tempo da volta em segundos
        }

        // Detalhes para o evento de aposentadoria
        public struct Retirement
        {
            public byte vehicleIdx; // Índice do veículo que se aposentou
        }

        // Detalhes para o evento de companheiro de equipe nos pits
        public struct TeamMateInPits
        {
            public byte vehicleIdx; // Índice do veículo do companheiro de equipe nos pits
        }

        // Detalhes para o evento de vencedor da corrida
        public struct RaceWinner
        {
            public byte vehicleIdx; // Índice do veículo vencedor da corrida
        }

        // Detalhes para o evento de penalidade
        public struct Penalty
        {
            public byte penaltyType;    // Tipo de penalidade - ver os anexos
            public byte infringementType; // Tipo de infração - ver os anexos
            public byte vehicleIdx;      // Índice do veículo penalizado
            public byte otherVehicleIdx; // Índice do outro veículo envolvido
            public byte time;            // Tempo ganho, ou tempo gasto realizando a ação em segundos
            public byte lapNum;          // Volta onde a penalidade ocorreu
            public byte placesGained;    // Número de posições ganhas por isso
        }

        // Detalhes para o evento de medição de velocidade
        public struct SpeedTrap
        {
            public byte vehicleIdx;                // Índice do veículo que ativou o radar de velocidade
            public float speed;                     // Velocidade máxima atingida em quilômetros por hora
            public byte isOverallFastestInSession;  // 1 se for a maior velocidade geral da sessão, caso contrário 0
            public byte isDriverFastestInSession;   // 1 se for a maior velocidade do piloto na sessão, caso contrário 0
            public byte fastestVehicleIdxInSession; // Índice do veículo mais rápido da sessão
            public float fastestSpeedInSession;     // Velocidade do veículo mais rápido na sessão
        }

        // Detalhes para o evento de luzes de largada
        public struct StartLights
        {
            public byte numLights; // Número de luzes acesas
        }

        // Detalhes para o evento de penalidade de drive-through servida
        public struct DriveThroughPenaltyServed
        {
            public byte vehicleIdx; // Índice do veículo servindo a penalidade de drive-through
        }

        // Detalhes para o evento de penalidade de stop-go servida
        public struct StopGoPenaltyServed
        {
            public byte vehicleIdx; // Índice do veículo servindo a penalidade de stop-go
        }

        // Detalhes para o evento de retroceder no tempo (flashback)
        public struct Flashback
        {
            public uint flashbackFrameIdentifier;   // Identificador do quadro para o qual foi retrocedido
            public float flashbackSessionTime;      // Tempo da sessão para o qual foi retrocedido
        }

        // Detalhes para o evento de botões pressionados
        public struct Buttons
        {
            public uint m_buttonStatus; // Flags de bits especificando quais botões estão sendo pressionados
            // atualmente - ver anexos
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
    }

    // Pacote de dados do evento
    public struct PacketEventData
    {
        public PacketHeader m_header;           // Cabeçalho
        public byte[] m_eventStringCode;       // Código da string do evento (4 bytes)
        public EventDataDetails m_eventDetails; // Detalhes do evento - devem ser interpretados de forma diferente
        // para cada tipo de evento
    }
}
