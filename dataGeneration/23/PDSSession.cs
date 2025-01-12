using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Session;

namespace TelemetryViewer.GeneratePDS.f123.Session
{
    public class PDSSessionData : PDSExport<PacketSessionData>
    {
        public override void ExportToPds(PacketSessionData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Session Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Weather, Track Temperature, Air Temperature, Total Laps, Track Length, Session Type, Track ID, Formula, " +
                                  "Session Time Left, Session Duration, Pit Speed Limit, Game Paused, Is Spectating, Spectator Car Index, SLI Pro Support, " +
                                  "Num Marshal Zones, Safety Car Status, Network Game, Forecast Accuracy, AI Difficulty, Season Link, Weekend Link, Session Link, " +
                                  "Pit Stop Window Ideal Lap, Pit Stop Window Latest Lap, Pit Stop Rejoin Position, Steering Assist, Braking Assist, Gearbox Assist, " +
                                  "Pit Assist, Pit Release Assist, ERS Assist, DRS Assist, Dynamic Racing Line, Dynamic Racing Line Type, Game Mode, Rule Set, Time of Day, " +
                                  "Session Length, Speed Units Lead Player, Temperature Units Lead Player, Speed Units Secondary Player, Temperature Units Secondary Player, " +
                                  "Num Safety Car Periods, Num Virtual Safety Car Periods, Num Red Flag Periods");

                // Escrever os dados da sessão
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, " +
                    "{23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}, {38}, {39}, {40}, {41}, {42}, {43}",
                    packetData.Weather,                         // Condições climáticas (0 = claro, 1 = nuvens leves, etc.)
                    packetData.TrackTemperature,               // Temperatura da pista (graus Celsius)
                    packetData.AirTemperature,                 // Temperatura do ar (graus Celsius)
                    packetData.TotalLaps,                      // Total de voltas na sessão
                    packetData.TrackLength,                    // Comprimento da pista (em metros)
                    packetData.SessionType,                    // Tipo de sessão
                    packetData.TrackId,                        // ID da pista
                    packetData.Formula,                        // Fórmula (código do tipo de Fórmula)
                    packetData.SessionTimeLeft,                // Tempo restante da sessão (em segundos)
                    packetData.SessionDuration,                // Duração da sessão (em segundos)
                    packetData.PitSpeedLimit,                  // Limite de velocidade no pit stop (km/h)
                    packetData.GamePaused,                     // Se o jogo está pausado
                    packetData.IsSpectating,                   // Se o jogador está assistindo
                    packetData.SpectatorCarIndex,              // Índice do carro sendo assistido
                    packetData.SliProNativeSupport,            // Suporte SLI Pro (0 = inativo, 1 = ativo)
                    packetData.NumMarshalZones,                // Número de zonas de marshalls
                    packetData.SafetyCarStatus,                // Status do safety car (0 = inativo, 1 = ativo)
                    packetData.NetworkGame,                    // Se é um jogo em rede
                    packetData.ForecastAccuracy,               // Precisão da previsão do tempo
                    packetData.AiDifficulty,                   // Dificuldade da IA
                    packetData.SeasonLinkIdentifier,           // Identificador da temporada
                    packetData.WeekendLinkIdentifier,          // Identificador do final de semana
                    packetData.SessionLinkIdentifier,          // Identificador da sessão
                    packetData.PitStopWindowIdealLap,          // Volta ideal para o pit stop
                    packetData.PitStopWindowLatestLap,         // Última volta possível para o pit stop
                    packetData.PitStopRejoinPosition,          // Posição prevista após o pit stop
                    packetData.SteeringAssist,                 // Assistência de direção
                    packetData.BrakingAssist,                  // Assistência de frenagem
                    packetData.GearboxAssist,                  // Assistência de câmbio
                    packetData.PitAssist,                      // Assistência no pit stop
                    packetData.PitReleaseAssist,               // Assistência para liberar o carro do pit
                    packetData.ErsAssist,                      // Assistência de ERS
                    packetData.DrsAssist,                      // Assistência de DRS
                    packetData.DynamicRacingLine,              // Linha de corrida dinâmica
                    packetData.DynamicRacingLineType,          // Tipo da linha de corrida dinâmica
                    packetData.GameMode,                       // Modo de jogo
                    packetData.RuleSet,                        // Conjunto de regras
                    packetData.TimeOfDay,                      // Hora do dia
                    packetData.SessionLength,                  // Duração da sessão (em minutos)
                    packetData.SpeedUnitsLeadPlayer,           // Unidades de velocidade do jogador principal
                    packetData.TemperatureUnitsLeadPlayer,     // Unidades de temperatura do jogador principal
                    packetData.SpeedUnitsSecondaryPlayer,      // Unidades de velocidade do jogador secundário
                    packetData.TemperatureUnitsSecondaryPlayer, // Unidades de temperatura do jogador secundário
                    packetData.NumSafetyCarPeriods,            // Número de períodos de safety car
                    packetData.NumVirtualSafetyCarPeriods,     // Número de períodos de safety car virtual
                    packetData.NumRedFlagPeriods              // Número de períodos de bandeira vermelha
                ));
            }

            Console.WriteLine($"SessionData F123 Sucesso: {filePath}");
        }
    }
}
