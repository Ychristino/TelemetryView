using System;
using System.Globalization;
using System.IO;
using System.Text;
using TelemetryViewer.Packets.f121.Session;

namespace TelemetryViewer.GeneratePDS.f121.Session
{
    public class PDSSession : PDSExport<PacketSessionData>
    {
        public override void ExportToPds(PacketSessionData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Session Data (F121)");
                writer.WriteLine("# Columns: Weather, Track Temperature, Air Temperature, Session Type, Track Length, " +
                    "Total Laps, Session Time Left, Session Duration, Pit Speed Limit, Game Paused, Spectating, " +
                    "Spectator Car Index, Safety Car Status, Network Game");

                // Escrever os dados principais da sessão
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}",
                    packetData.m_weather,
                    packetData.m_trackTemperature,
                    packetData.m_airTemperature,
                    packetData.m_sessionType,
                    packetData.m_trackLength,
                    packetData.m_totalLaps,
                    packetData.m_sessionTimeLeft,
                    packetData.m_sessionDuration,
                    packetData.m_pitSpeedLimit,
                    packetData.m_gamePaused,
                    packetData.m_isSpectating,
                    packetData.m_spectatorCarIndex,
                    packetData.m_safetyCarStatus,
                    packetData.m_networkGame
                ));

                // Escrever os dados das zonas de marshal
                writer.WriteLine("# Marshal Zones");
                for (int i = 0; i < packetData.m_numMarshalZones; i++)
                {
                    var zone = packetData.m_marshalZones[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}",
                        zone.m_zoneStart,
                        zone.m_zoneFlag
                    ));
                }

                // Escrever os dados da previsão do tempo
                writer.WriteLine("# Weather Forecast Samples");
                for (int i = 0; i < packetData.m_numWeatherForecastSamples; i++)
                {
                    var forecast = packetData.m_weatherForecastSamples[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}",
                        forecast.m_sessionType,
                        forecast.m_timeOffset,
                        forecast.m_weather,
                        forecast.m_trackTemperature,
                        forecast.m_airTemperature
                    ));
                }
            }

            Console.WriteLine($"Session Data F121 Exportado com sucesso: {filePath}");
        }
    }
}
