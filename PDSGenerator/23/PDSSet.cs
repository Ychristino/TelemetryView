using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TelemetryViewer.Dicts.f123.Event;
using TelemetryViewer.Dicts.f123.Track;
using TelemetryViewer.GeneratePDS.f123.CarSetup;
using TelemetryViewer.GeneratePDS.f123.Classification;
using TelemetryViewer.GeneratePDS.f123.Damage;
using TelemetryViewer.GeneratePDS.f123.Event;
using TelemetryViewer.GeneratePDS.f123.Header;
using TelemetryViewer.GeneratePDS.f123.Lap;
using TelemetryViewer.GeneratePDS.f123.Lobby;
using TelemetryViewer.GeneratePDS.f123.Motion;
using TelemetryViewer.GeneratePDS.f123.MotionEx;
using TelemetryViewer.GeneratePDS.f123.Participants;
using TelemetryViewer.GeneratePDS.f123.Session;
using TelemetryViewer.GeneratePDS.f123.LapHistory;
using TelemetryViewer.GeneratePDS.f123.Status;
using TelemetryViewer.GeneratePDS.f123.Telemetry;
using TelemetryViewer.GeneratePDS.f123.TyreSets;
using TelemetryViewer.Packets.f123.CarSetup;
using TelemetryViewer.Packets.f123.Classification;
using TelemetryViewer.Packets.f123.Damage;
using TelemetryViewer.Packets.f123.Event;
using TelemetryViewer.Packets.f123.Header;
using TelemetryViewer.Packets.f123.Lap;
using TelemetryViewer.Packets.f123.Lobby;
using TelemetryViewer.Packets.f123.Motion;
using TelemetryViewer.Packets.f123.MotionEx;
using TelemetryViewer.Packets.f123.Participants;
using TelemetryViewer.Packets.f123.Session;
using TelemetryViewer.Packets.f123.SessionHistory;
using TelemetryViewer.Packets.f123.Status;
using TelemetryViewer.Packets.f123.Telemetry;
using TelemetryViewer.Packets.f123.TyreSets;

namespace TelemetryViewer.GeneratePDS.f123
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
            PacketEvent eventDataList,
            PacketFinalClassification finalClassificationData,
            PacketHeader headerData,
            PacketLap lapData,
            PacketSessionHistory lapHisotryData,
            PacketLobbyInfo lobbyInfoData,
            PacketMotion motionData,
            PacketMotionEx motionExData,
            PacketParticipants participantsData,
            PacketSession sessionData,
            PacketTyreSets tyreSetsData
        )
        {
            using (StreamWriter writer = new StreamWriter(_filePath, append: true))
            {
            //     writer.WriteLine("# Telemetry Data Export");
            //     writer.WriteLine($"# Track: {track}");
            //     writer.WriteLine($"# Driver: {driverName}");
            //     writer.WriteLine($"# Event: {eventCode}");
            //     writer.WriteLine($"# Date: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)}");
            //     writer.WriteLine();

            //     PDSCarDamage pDSCarDamage = new PDSCarDamage();
            //     pDSCarDamage.ExportPdsHeader(_filePath);
            //     pDSCarDamage.ExportToPds(carDamageData, _filePath);

            //     PDSCarSetup pDSCarSetupData = new PDSCarSetup();
            //     pDSCarSetupData.ExportPdsHeader(_filePath);
            //     pDSCarSetupData.ExportToPds(carSetupData, _filePath);

            //     PDSCarStatus pDSCarStatus = new PDSCarStatus();
            //     pDSCarStatus.ExportPdsHeader(_filePath);
            //     pDSCarStatus.ExportToPds(carStatusData, _filePath);

            //     PDSCarTelemetry pDSCarTelemetry = new PDSCarTelemetry();
            //     pDSCarTelemetry.ExportPdsHeader(_filePath);
            //     pDSCarTelemetry.ExportToPds(carTelemetryData, _filePath);

            //     PDSEvent pDSPacketEvent = new PDSEvent();
            //     pDSPacketEvent.ExportPdsHeader(_filePath);
            //     pDSPacketEvent.ExportToPds(eventDataList, _filePath);

            //     PDSFinalClassification pDSFinalClassification = new PDSFinalClassification();
            //     pDSFinalClassification.ExportPdsHeader(_filePath);
            //     pDSFinalClassification.ExportToPds(finalClassificationData, _filePath);

            //     PDSHeader pDSHeader = new PDSHeader();
            //     pDSHeader.ExportPdsHeader(_filePath);
            //     pDSHeader.ExportToPds(headerData, _filePath);

            //     PDSLap pDSLapData = new PDSLap();
            //     pDSLapData.ExportPdsHeader(_filePath);
            //     pDSLapData.ExportToPds(lapData, _filePath);

            //     PDSLapHistory pDSHistory = new PDSLapHistory();
            //     pDSHistory.ExportPdsHeader(_filePath);
            //     pDSHistory.ExportToPds(lapHisotryData, _filePath);

            //     PDSLobby pDSLobbyData = new PDSLobby();
            //     pDSLobbyData.ExportPdsHeader(_filePath);
            //     pDSLobbyData.ExportToPds(lobbyInfoData, _filePath);

            //     PDSMotion pDSMotionData = new PDSMotion();
            //     pDSMotionData.ExportPdsHeader(_filePath);
            //     pDSMotionData.ExportToPds(motionData, _filePath);

            //     PDSMotionEx pDSMotionEx = new PDSMotionEx();
            //     pDSMotionEx.ExportPdsHeader(_filePath);
            //     pDSMotionEx.ExportToPds(motionExData, _filePath);

            //     PDSParticipants pDSParticipants = new PDSParticipants();
            //     pDSParticipants.ExportPdsHeader(_filePath);
            //     pDSParticipants.ExportToPds(participantsData, _filePath);

            //     PDSSession pDSSession = new PDSSession();
            //     pDSSession.ExportPdsHeader(_filePath);
            //     pDSSession.ExportToPds(sessionData, _filePath);

            //     PDSTyreSets pDSTyreSets = new PDSTyreSets();
            //     pDSTyreSets.ExportPdsHeader(_filePath);
            //     pDSTyreSets.ExportToPds(tyreSetsData, _filePath);

            }

            Console.WriteLine($"Export completed successfully: {_filePath}");
        }
    }
}
