using System.Globalization;
using TelemetryViewer.Dicts.f120.Track;
using TelemetryViewer.Packets.f120.Session;

namespace TelemetryViewer.GeneratePDS.f120.Session
{
    public class PDSSession : PDSExport<PacketSession>
    {
        public override void ExportPdsHeader(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true)){
                // Escrever a seção de dados da sessão
                writer.WriteLine("# Session Data");
                writer.WriteLine("# Columns: Weather, Track Temperature, Air Temperature, Total Laps, " + 
                                 "Track Length, Session Type, Track ID, Formula, Time Left, Session Duration, " + 
                                 "Pit Speed Limit, Game Paused, Is Spectating, Spectator Car Index, SLI Pro Native Support, " + 
                                 "Number of Marshal Zones, Safety Car Status, Network Game, Number of Weather Forecast Samples");
            }
        }
        public override void ExportToPds(PacketSession sessionData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever os dados principais da sessão
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                    "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}",
                    sessionData.m_weather,
                    sessionData.m_trackTemperature,
                    sessionData.m_airTemperature,
                    sessionData.m_totalLaps,
                    sessionData.m_trackLength,
                    sessionData.m_sessionType,
                    Track.GetTrackName(sessionData.m_trackId),
                    sessionData.m_formula,
                    sessionData.m_sessionTimeLeft,
                    sessionData.m_sessionDuration,
                    sessionData.m_pitSpeedLimit,
                    sessionData.m_gamePaused,
                    sessionData.m_isSpectating,
                    sessionData.m_spectatorCarIndex,
                    sessionData.m_sliProNativeSupport,
                    sessionData.m_numMarshalZones,
                    sessionData.m_safetyCarStatus,
                    sessionData.m_networkGame,
                    sessionData.m_numWeatherForecastSamples
                ));

                // Escrever os dados das zonas de marshal
                for (int i = 0; i < sessionData.m_numMarshalZones; i++)
                {
                    var marshalZone = sessionData.m_marshalZones[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "Marshal Zone {0}: Start = {1}, Flag = {2}",
                        i + 1,
                        marshalZone.m_zoneStart,
                        marshalZone.m_zoneFlag
                    ));
                }

                // Escrever as previsões de clima
                for (int i = 0; i < sessionData.m_numWeatherForecastSamples; i++)
                {
                    var forecastSample = sessionData.m_weatherForecastSamples[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "Weather Forecast {0}: Session Type = {1}, Time Offset = {2}, Weather = {3}, Track Temperature = {4}, Air Temperature = {5}",
                        i + 1,
                        forecastSample.m_sessionType,
                        forecastSample.m_timeOffset,
                        forecastSample.m_weather,
                        forecastSample.m_trackTemperature,
                        forecastSample.m_airTemperature
                    ));
                }
            }

            Console.WriteLine($"Dados da sessão exportados para: {filePath}");
        }
    }
}
