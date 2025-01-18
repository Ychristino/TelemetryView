using System;
using System.Collections.Generic;
using TelemetryViewer.GeneratePDS.f123.CarSetup;
using TelemetryViewer.GeneratePDS.f123.Classification;
using TelemetryViewer.GeneratePDS.f123.Damage;
using TelemetryViewer.GeneratePDS.f123.Event;
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

namespace TelemetryViewer.Dicts.f123.PacketInfo
{
    public class PacketInfo
    {
        // Dicionário que mapeia o ID do pacote para o nome, a descrição e o tipo de estrutura do pacote
        private static readonly Dictionary<int, (string Name, string Description, Type StructureType, Type PDSWrite)> PacketDictionary = new Dictionary<int, (string, string, Type, Type)>
        {
            { 0, ("Motion", "Contains all motion data for player’s car – only sent while player is in control", typeof(PacketMotion), typeof(PDSMotion)) },
            { 1, ("Session", "Data about the session – track, time left", typeof(PacketSession), typeof(PDSSession)) },
            { 2, ("Lap Data", "Data about all the lap times of cars in the session", typeof(PacketLap), typeof(PDSLap)) },
            { 3, ("Event", "Various notable events that happen during a session", typeof(PacketEvent), typeof(PDSEvent)) },
            { 4, ("Participants", "List of participants in the session, mostly relevant for multiplayer", typeof(PacketParticipants), typeof(PDSParticipants)) },
            { 5, ("Car Setups", "Packet detailing car setups for cars in the race", typeof(PacketCarSetup), typeof(PDSCarSetup)) },
            { 6, ("Car Telemetry", "Telemetry data for all cars", typeof(PacketCarTelemetry), typeof(PDSCarTelemetry)) },
            { 7, ("Car Status", "Status data for all cars such as damage", typeof(PacketCarStatus), typeof(PDSCarStatus)) },
            { 8, ("Final Classification", "Final classification confirmation at the end of a race", typeof(PacketFinalClassification), typeof(PDSFinalClassification)) },
            { 9, ("Lobby Information", "Information about players in a multiplayer lobby", typeof(PacketLobbyInfo), typeof(PDSLobby)) },
            { 10, ("Car Damage", "Damage status for all cars", typeof(PacketCarDamage), typeof(PDSCarDamage)) },
            { 11, ("Session History", "Lap and tyre data for session", typeof(PacketSessionHistory), typeof(PDSLapHistory)) },
            { 12, ("Tyre Sets", "Extended tyre set data", typeof(PacketTyreSets), typeof(PDSTyreSets)) },
            { 13, ("Motion Ex", "Extended motion data for player car", typeof(PacketMotionEx), typeof(PDSMotionEx)) }
        };

        // Método que retorna o nome, descrição e tipo de estrutura para um ID de pacote específico
        public static (string Name, string Description, Type StructureType, Type PDSWrite) GetPacketInfo(int packetId)
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
