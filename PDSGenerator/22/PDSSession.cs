using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Dicts.f120.Track;
using TelemetryViewer.Dicts.f122.GameMode;
using TelemetryViewer.Packets.f122.Session; // Alterado para o namespace f122.Session

namespace TelemetryViewer.GeneratePDS.f122.Session
{
    public class PDSSession : PDSExport<PacketSession>
    {
        public override void ExportPdsHeader(string filePath){
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Session Data (F122)"); // Alterado para F122
                writer.WriteLine("# Columns: Weather, Track Temperature, Air Temperature, Total Laps, Track Length, Session Type, " +
                                    "Track ID, Formula, Session Time Left, Session Duration, Pit Speed Limit, Game Paused, " +
                                    "Is Spectating, Spectator Car Index, SLI Pro Native Support, Num Marshal Zones, Safety Car Status, " +
                                    "Network Game, Num Weather Forecast Samples, Forecast Accuracy, AI Difficulty, Season Link Identifier, " +
                                    "Weekend Link Identifier, Session Link Identifier, Pit Stop Window Ideal Lap, Pit Stop Window Latest Lap, " +
                                    "Pit Stop Rejoin Position, Steering Assist, Braking Assist, Gearbox Assist, Pit Assist, Pit Release Assist, " +
                                    "ERS Assist, DRS Assist, Dynamic Racing Line, Dynamic Racing Line Type, Game Mode, Rule Set, Time of Day, " +
                                    "Session Length");
            }
        }
        public override void ExportToPds(PacketSession packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados da sessão no arquivo CSV
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, " +
                    "{19}, {20}, {21}, {22}, {23}, {24}, {25}, {26}, {27}, {28}, {29}, {30}, {31}, {32}, {33}, {34}, {35}, {36}, {37}",
                    packetData.m_weather,
                    packetData.m_trackTemperature,
                    packetData.m_airTemperature,
                    packetData.m_totalLaps,
                    packetData.m_trackLength,
                    packetData.m_sessionType,
                    Track.GetTrackName(packetData.m_trackId),
                    packetData.m_formula,
                    packetData.m_sessionTimeLeft,
                    packetData.m_sessionDuration,
                    packetData.m_pitSpeedLimit,
                    packetData.m_gamePaused,
                    packetData.m_isSpectating,
                    packetData.m_spectatorCarIndex,
                    packetData.m_sliProNativeSupport,
                    packetData.m_numMarshalZones,
                    packetData.m_safetyCarStatus,
                    packetData.m_networkGame,
                    packetData.m_numWeatherForecastSamples,
                    packetData.m_forecastAccuracy,
                    packetData.m_aiDifficulty,
                    packetData.m_seasonLinkIdentifier,
                    packetData.m_weekendLinkIdentifier,
                    packetData.m_sessionLinkIdentifier,
                    packetData.m_pitStopWindowIdealLap,
                    packetData.m_pitStopWindowLatestLap,
                    packetData.m_pitStopRejoinPosition,
                    packetData.m_steeringAssist,
                    packetData.m_brakingAssist,
                    packetData.m_gearboxAssist,
                    packetData.m_pitAssist,
                    packetData.m_pitReleaseAssist,
                    packetData.m_ERSAssist,
                    packetData.m_DRSAssist,
                    packetData.m_dynamicRacingLine,
                    packetData.m_dynamicRacingLineType,
                    GameMode.GetModeName(packetData.m_gameMode),
                    packetData.m_ruleSet,
                    packetData.m_timeOfDay,
                    packetData.m_sessionLength
                ));
            }

            Console.WriteLine($"PacketSessionData F122 Sucesso: {filePath}");
        }
    }
}
