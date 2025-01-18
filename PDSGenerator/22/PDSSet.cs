using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.CarStatus;
using TelemetryViewer.Packets.f122.CarTelemetry;
using TelemetryViewer.Packets.f122.Event;
using TelemetryViewer.Dicts.f122.Event;
using TelemetryViewer.Packets.f122.Damage;
using TelemetryViewer.Packets.f122.CarSetup;
using TelemetryViewer.Packets.f122.Classification;
using TelemetryViewer.Packets.f122.Header;
using TelemetryViewer.Packets.f122.Lap;
using TelemetryViewer.Packets.f122.Lobby;
using TelemetryViewer.Packets.f122.Motion;
using TelemetryViewer.Packets.f122.Participants;
using TelemetryViewer.Packets.f122.Session;
using TelemetryViewer.Packets.f122.SessionHistory;
using TelemetryViewer.GeneratePDS.f122.Damage;
using TelemetryViewer.GeneratePDS.f122.CarSetup;
using TelemetryViewer.GeneratePDS.f122.CarStatus;
using TelemetryViewer.GeneratePDS.f122.CarTelemetry;
using TelemetryViewer.GeneratePDS.f122.Event;
using TelemetryViewer.GeneratePDS.f122.Classification;
using TelemetryViewer.GeneratePDS.f122.Header;
using TelemetryViewer.GeneratePDS.f122.Lap;
using TelemetryViewer.GeneratePDS.f122.Lobby;
using TelemetryViewer.GeneratePDS.f122.Motion;
using TelemetryViewer.GeneratePDS.f122.Participants;
using TelemetryViewer.GeneratePDS.f122.Session;
using TelemetryViewer.GeneratePDS.f122.SessionHistory;
using TelemetryViewer.Dicts.f122.Track;

namespace TelemetryViewer.GeneratePDS.f122
{
    public class PDSExporter
    {
        private readonly string _filePath;

        public PDSExporter(string filePath)
        {
            _filePath = filePath;
        }

        public void Export(
            Track track,
            string driverName,
            EventCode eventCode,
            PacketCarDamage carDamageData,
            PacketCarSetup carSetupData,
            PacketCarStatus carStatusData,
            PacketCarTelemetry carTelemetryData,
            List<PacketEvent> eventDataList,
            PacketFinalClassification finalClassificationData,
            PacketHeader headerData,
            PacketLap lapData,
            PacketLobbyInfo lobbyInfoData,
            PacketMotion motionData,
            PacketParticipants participantsData,
            PacketSession sessionData,
            PacketSessionHistory sessionHistoryData
        )
        {
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                // writer.WriteLine("# Telemetry Data Export");
                // writer.WriteLine($"# Track: {track}");
                // writer.WriteLine($"# Driver: {driverName}");
                // writer.WriteLine($"# Event: {eventCode}");
                // writer.WriteLine($"# Date: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}");
                // writer.WriteLine();

                // // Seção: Car Damage Data
                // writer.WriteLine("# Section: Car Damage Data");
                // foreach (var damage in carDamageData.CarDamageList)
                // {
                //     new PDSCarDamage().ExportToPds(damage, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Car Setup Data
                // writer.WriteLine("# Section: Car Setup Data");
                // foreach (var setup in carSetupData.CarSetups)
                // {
                //     new PDSCarSetup().ExportToPds(setup, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Car Status Data
                // writer.WriteLine("# Section: Car Status Data");
                // foreach (var status in carStatusData.CarStatusList)
                // {
                //     new PDSCarStatus().ExportToPds(status, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Car Telemetry Data
                // writer.WriteLine("# Section: Car Telemetry Data");
                // foreach (var telemetry in carTelemetryData.CarTelemetries)
                // {
                //     new PDSCarTelemetry().ExportToPds(telemetry, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Event Data
                // writer.WriteLine("# Section: Event Data");
                // foreach (var eventData in eventDataList)
                // {
                //     new PDSEventData().ExportToPds(eventData, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Final Classification Data
                // writer.WriteLine("# Section: Final Classification Data");
                // foreach (var classification in finalClassificationData.Classifications)
                // {
                //     new PDSPacketFinalClassificationData().ExportToPds(classification, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Header Data
                // writer.WriteLine("# Section: Header Data");
                // new PDSHeaderData().ExportToPds(headerData, _filePath);
                // writer.WriteLine();

                // // Seção: Lap Data
                // writer.WriteLine("# Section: Lap Data");
                // foreach (var lap in lapData.Laps)
                // {
                //     new PDSLapData().ExportToPds(lap, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Lobby Info Data
                // writer.WriteLine("# Section: Lobby Info Data");
                // foreach (var lobby in lobbyInfoData.Lobbies)
                // {
                //     new PDSLobbyInfoData().ExportToPds(lobby, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Motion Data
                // writer.WriteLine("# Section: Motion Data");
                // foreach (var motion in motionData.Motions)
                // {
                //     new PDSMotionData().ExportToPds(motion, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Participants Data
                // writer.WriteLine("# Section: Participants Data");
                // foreach (var participant in participantsData.Participants)
                // {
                //     new PDSParticipantData().ExportToPds(participant, _filePath);
                // }
                // writer.WriteLine();

                // // Seção: Session Data
                // writer.WriteLine("# Section: Session Data");
                // new PDSSessionData().ExportToPds(sessionData, _filePath);
                // writer.WriteLine();

                // // Seção: Session History Data
                // writer.WriteLine("# Section: Session History Data");
                // foreach (var history in sessionHistoryData.Histories)
                // {
                //     new PDSSessionHistoryData().ExportToPds(history, _filePath);
                // }
            }

            Console.WriteLine($"Export completed successfully: {_filePath}");
        }
    }
}
