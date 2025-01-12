using System;
using System.Collections.Generic;
using TelemetryViewer.Packets.f122.CarSetup;
using TelemetryViewer.Packets.f122.CarStatus;
using TelemetryViewer.Packets.f122.CarTelemetry;
using TelemetryViewer.Packets.f122.Classification;
using TelemetryViewer.Packets.f122.Damage;
using TelemetryViewer.Packets.f122.Event;
using TelemetryViewer.Packets.f122.Lap;
using TelemetryViewer.Packets.f122.Lobby;
using TelemetryViewer.Packets.f122.Motion;
using TelemetryViewer.Packets.f122.Participants;
using TelemetryViewer.Packets.f122.Session;
using TelemetryViewer.Packets.f122.SessionHistory;

namespace TelemetryViewer.Dicts.f122.PacketInfo
{
    public class PacketInfo
    {
        // Dicionário que mapeia o ID do pacote para o nome, a descrição e o tipo de estrutura do pacote
        private static readonly Dictionary<int, (string Name, string Description, Type? StructureType)> PacketDictionary = new Dictionary<int, (string, string, Type?)>
        {
            { 0, ("Motion", "Contains all motion data for player’s car – only sent while player is in control", typeof(PacketMotionData)) },
            { 1, ("Session", "Data about the session – track, time left", typeof(PacketSessionData)) },
            { 2, ("Lap Data", "Data about all the lap times of cars in the session", typeof(PacketLapData)) },
            { 3, ("Event", "Various notable events that happen during a session", typeof(PacketEventData)) },
            { 4, ("Participants", "List of participants in the session, mostly relevant for multiplayer", typeof(PacketParticipantsData)) },
            { 5, ("Car Setups", "Packet detailing car setups for cars in the race", typeof(PacketCarSetupData)) },
            { 6, ("Car Telemetry", "Telemetry data for all cars", typeof(PacketCarTelemetryData)) },
            { 7, ("Car Status", "Status data for all cars such as damage", typeof(PacketCarStatusData)) },
            { 8, ("Final Classification", "Final classification confirmation at the end of a race", typeof(PacketFinalClassificationData)) },
            { 9, ("Lobby Information", "Information about players in a multiplayer lobby", typeof(PacketLobbyInfoData)) },
            { 10, ("Car Damage", "Damage status for all cars", typeof(PacketCarDamageData)) },
            { 11, ("Session History", "Lap and tyre data for session", typeof(PacketSessionHistoryData)) },
        };

        // Método que retorna o nome, descrição e tipo de estrutura para um ID de pacote específico
        public static (string Name, string Description, Type? StructureType) GetPacketInfo(int packetId)
        {
            if (PacketDictionary.ContainsKey(packetId))
            {
                return PacketDictionary[packetId];
            }
            else
            {
                return ("Unknown", "No description available", null);
            }
        }
    }
}
