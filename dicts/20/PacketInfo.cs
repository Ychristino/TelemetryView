using System;
using System.Collections.Generic;
using TelemetryViewer.Packets.f120.CarSetup;
using TelemetryViewer.Packets.f120.CarStatus;
using TelemetryViewer.Packets.f120.CarTelemetry;
using TelemetryViewer.Packets.f120.Event;
using TelemetryViewer.Packets.f120.FinalClassification;
using TelemetryViewer.Packets.f120.Lap;
using TelemetryViewer.Packets.f120.LobbyInfo;
using TelemetryViewer.Packets.f120.Motion;
using TelemetryViewer.Packets.f120.Participant;
using TelemetryViewer.Packets.f120.Session;

namespace TelemetryViewer.Dicts.f120.PacketInfo
{
    public class PacketInfo
    {
        // Dicionário que mapeia o ID do pacote para o nome, a descrição e o tipo de estrutura do pacote
        private static readonly Dictionary<int, (string Name, string Description, Type StructureType)> PacketDictionary = new Dictionary<int, (string, string, Type)>
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
            { 9, ("Lobby Information", "Information about players in a multiplayer lobby", typeof(PacketLobbyInfoData)) }
        };

        // Método para buscar o nome, descrição e tipo de estrutura do pacote pelo PacketId
        public static (string Name, string Description, Type StructureType) GetPacketInfo(int packetId)
        {
            if (PacketDictionary.TryGetValue(packetId, out var packetInfo))
            {
                Console.WriteLine($"Packet Name: {packetInfo.Name}");
                Console.WriteLine($"Packet Value: {packetId}");
                Console.WriteLine($"Description: {packetInfo.Description}");
                Console.WriteLine($"Structure Type: {packetInfo.StructureType.Name}");
                return packetInfo;
            }
            else
            {
                Console.WriteLine("Unknown Packet ID.");
                // Retorna uma tupla vazia ou valores padrão em caso de falha
                return default;
            }
        }
    }
}
