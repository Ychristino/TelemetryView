using System;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Session
{
    // Estrutura para representar uma zona de marshalls
    public struct MarshalZone
    {
        public float m_zoneStart; // Fração (0..1) do percurso que a zona de marshalls começa
        public sbyte m_zoneFlag; // -1 = inválido/desconhecido, 0 = nenhum, 1 = verde, 2 = azul, 3 = amarela, 4 = vermelha
    }

    // Estrutura para representar uma amostra de previsão do tempo
    public struct WeatherForecastSample
    {
        public byte m_sessionType; // 0 = desconhecido, 1 = P1, 2 = P2, 3 = P3, 4 = P curta, 5 = Q1
        // 6 = Q2, 7 = Q3, 8 = Q curta, 9 = OSQ, 10 = R, 11 = R2
        // 12 = R3, 13 = Time Trial
        public byte m_timeOffset; // Tempo em minutos para a previsão
        public byte m_weather; // Clima - 0 = céu limpo, 1 = nuvem leve, 2 = nublado
        // 3 = chuva leve, 4 = chuva forte, 5 = tempestade
        public sbyte m_trackTemperature; // Temperatura da pista em graus Celsius
        public sbyte m_trackTemperatureChange; // Mudança na temperatura da pista – 0 = aumento, 1 = diminuição, 2 = sem alteração
        public sbyte m_airTemperature; // Temperatura do ar em graus Celsius
        public sbyte m_airTemperatureChange; // Mudança na temperatura do ar – 0 = aumento, 1 = diminuição, 2 = sem alteração
        public byte m_rainPercentage; // Percentual de chuva (0-100)
    }

    // Estrutura para os dados de uma sessão de corrida
    public struct PacketSession
    {
        public PacketHeader m_header; // Cabeçalho
        public byte m_weather; // Clima - 0 = céu limpo, 1 = nuvem leve, 2 = nublado
        // 3 = chuva leve, 4 = chuva forte, 5 = tempestade
        public sbyte m_trackTemperature; // Temperatura da pista em graus Celsius
        public sbyte m_airTemperature; // Temperatura do ar em graus Celsius
        public byte m_totalLaps; // Total de voltas nesta corrida
        public ushort m_trackLength; // Comprimento da pista em metros
        public byte m_sessionType; // 0 = desconhecido, 1 = P1, 2 = P2, 3 = P3, 4 = P curta
        // 5 = Q1, 6 = Q2, 7 = Q3, 8 = Q curta, 9 = OSQ
        // 10 = R, 11 = R2, 12 = R3, 13 = Time Trial
        public sbyte m_trackId; // -1 para desconhecido, veja o apêndice
        public byte m_formula; // Fórmula, 0 = F1 Moderna, 1 = F1 Clássica, 2 = F2,
        // 3 = F1 Genérica, 4 = Beta, 5 = Supercars
        // 6 = Esports, 7 = F2 2021
        public ushort m_sessionTimeLeft; // Tempo restante na sessão em segundos
        public ushort m_sessionDuration; // Duração da sessão em segundos
        public byte m_pitSpeedLimit; // Limite de velocidade no pitstop em quilômetros por hora
        public byte m_gamePaused; // Indica se o jogo está pausado – jogo de rede apenas
        public byte m_isSpectating; // Indica se o jogador está assistindo a outro carro
        public byte m_spectatorCarIndex; // Índice do carro que está sendo assistido
        public byte m_sliProNativeSupport; // Suporte SLI Pro, 0 = inativo, 1 = ativo
        public byte m_numMarshalZones; // Número de zonas de marshalls para seguir
        public MarshalZone[] m_marshalZones; // Lista de zonas de marshalls – máximo 21
        public byte m_safetyCarStatus; // 0 = sem safety car, 1 = completo
        // 2 = virtual, 3 = volta de formação
        public byte m_networkGame; // 0 = offline, 1 = online
        public byte m_numWeatherForecastSamples; // Número de amostras de previsão do tempo para seguir
        public WeatherForecastSample[] m_weatherForecastSamples; // Array de amostras de previsão do tempo
        public byte m_forecastAccuracy; // 0 = Perfeita, 1 = Aproximada
        public byte m_aiDifficulty; // Classificação de dificuldade da IA – 0-110
        public uint m_seasonLinkIdentifier; // Identificador da temporada - persiste entre salvamentos
        public uint m_weekendLinkIdentifier; // Identificador do fim de semana - persiste entre salvamentos
        public uint m_sessionLinkIdentifier; // Identificador da sessão - persiste entre salvamentos
        public byte m_pitStopWindowIdealLap; // Volta ideal para parar no pitstop para a estratégia atual (jogador)
        public byte m_pitStopWindowLatestLap; // Última volta para parar no pitstop para a estratégia atual (jogador)
        public byte m_pitStopRejoinPosition; // Posição prevista para reentrar após o pitstop (jogador)
        public byte m_steeringAssist; // 0 = desligado, 1 = ligado
        public byte m_brakingAssist; // 0 = desligado, 1 = baixo, 2 = médio, 3 = alto
        public byte m_gearboxAssist; // 1 = manual, 2 = manual & marcha sugerida, 3 = automático
        public byte m_pitAssist; // 0 = desligado, 1 = ligado
        public byte m_pitReleaseAssist; // 0 = desligado, 1 = ligado
        public byte m_ERSAssist; // 0 = desligado, 1 = ligado
        public byte m_DRSAssist; // 0 = desligado, 1 = ligado
        public byte m_dynamicRacingLine; // 0 = desligado, 1 = apenas curvas, 2 = completo
        public byte m_dynamicRacingLineType; // 0 = 2D, 1 = 3D
        public byte m_gameMode; // ID do modo de jogo - veja o apêndice
        public byte m_ruleSet; // Conjunto de regras - veja o apêndice
        public uint m_timeOfDay; // Hora local do dia - minutos desde a meia-noite
        public byte m_sessionLength; // 0 = Nenhum, 2 = Muito Curto, 3 = Curto, 4 = Médio
        // 5 = Médio Longo, 6 = Longo, 7 = Completo
    }
}
