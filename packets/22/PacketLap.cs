using System;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Lap
{
    // Estrutura para representar os dados de uma volta
    public struct LapData
    {
        public uint m_lastLapTimeInMS; // Último tempo de volta em milissegundos
        public uint m_currentLapTimeInMS; // Tempo atual na volta em milissegundos
        public ushort m_sector1TimeInMS; // Tempo do setor 1 em milissegundos
        public ushort m_sector2TimeInMS; // Tempo do setor 2 em milissegundos
        public float m_lapDistance; // Distância percorrida na volta atual em metros – pode ser negativa
        // se a linha ainda não tiver sido cruzada
        public float m_totalDistance; // Distância total percorrida na sessão em metros – pode ser negativa
        // se a linha ainda não tiver sido cruzada
        public float m_safetyCarDelta; // Delta em segundos para o safety car
        public byte m_carPosition; // Posição do carro na corrida
        public byte m_currentLapNum; // Número da volta atual
        public byte m_pitStatus; // 0 = nenhum, 1 = pitando, 2 = na área de pit
        public byte m_numPitStops; // Número de pit stops feitos nesta corrida
        public byte m_sector; // 0 = setor1, 1 = setor2, 2 = setor3
        public byte m_currentLapInvalid; // Volta atual inválida - 0 = válida, 1 = inválida
        public byte m_penalties; // Penalidades acumuladas em segundos a serem adicionadas
        public byte m_warnings; // Número de advertências acumuladas
        public byte m_numUnservedDriveThroughPens; // Número de penalidades de "drive through" restantes
        public byte m_numUnservedStopGoPens; // Número de penalidades de "stop and go" restantes
        public byte m_gridPosition; // Posição na grelha em que o veículo iniciou a corrida
        public byte m_driverStatus; // Status do motorista - 0 = na garagem, 1 = volta rápida
        // 2 = volta de entrada, 3 = volta de saída, 4 = na pista
        public byte m_resultStatus; // Status do resultado - 0 = inválido, 1 = inativo, 2 = ativo
        // 3 = terminou, 4 = não terminou, 5 = desqualificado
        // 6 = não classificado, 7 = retirado
        public byte m_pitLaneTimerActive; // Tempo de pit lane, 0 = inativo, 1 = ativo
        public ushort m_pitLaneTimeInLaneInMS; // Se ativo, o tempo atual gasto na pit lane em ms
        public ushort m_pitStopTimerInMS; // Tempo do pit stop real em ms
        public byte m_pitStopShouldServePen; // Se o carro deve servir uma penalidade neste pit stop
    }

    // Estrutura para os dados da volta de todos os carros
    public struct PacketLap
    {
        public PacketHeader m_header; // Cabeçalho
        public LapData[] m_lapData; // Dados de volta para todos os carros na pista
        public byte m_timeTrialPBCarIdx; // Índice do carro de Melhor Tempo Pessoal no Time Trial (255 se inválido)
        public byte m_timeTrialRivalCarIdx; // Índice do carro Rivais no Time Trial (255 se inválido)
    }
}
