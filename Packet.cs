using System.Runtime.InteropServices;
using TelemetryViewer.GeneratePDS;
using TelemetryViewer.Packets.f120.Header;
using TelemetryViewer.Packets.f120.Motion;
using TelemetryViewer.Packets.f120.Session;

namespace TelemetryViewer.Packets{

    public class Packet{

        public Packet(){

        }

    public static T DeserializePacket<T>(byte[] buffer) where T : struct
    {
        // Verificar se o buffer tem tamanho suficiente
        if (buffer.Length < Marshal.SizeOf<T>())
        {
            throw new ArgumentOutOfRangeException(nameof(buffer), "Buffer size is smaller than the expected size of the structure.");
        }

        return MemoryMarshal.Read<T>(buffer);
    }

    public static void WriteFile(object packet, Type pdsWriter)
    {
        if (packet == null)
            throw new ArgumentNullException(nameof(packet));

        if (pdsWriter == null)
            throw new ArgumentNullException(nameof(pdsWriter));

        // Verifica se a classe implementa ou herda de PDSExport<>
        var baseType = pdsWriter.BaseType;
        if (baseType == null || !baseType.IsGenericType || baseType.GetGenericTypeDefinition() != typeof(PDSExport<>))
        {
            throw new ArgumentException($"{pdsWriter.Name} não é um tipo válido para PDSExport.");
        }

        try
        {
            // Cria uma instância da classe fornecida
            var instance = Activator.CreateInstance(pdsWriter);

            // Obtém o método ExportToPds
            var headerMethod = pdsWriter.GetMethod("ExportPdsHeader");
            var exportMethod = pdsWriter.GetMethod("ExportToPds");
            if (exportMethod == null || headerMethod == null)
                throw new MissingMethodException($"{pdsWriter.Name} não possui um método ExportToPds.");

            // Invoca o método ExportToPds
            Console.WriteLine($"Writing {pdsWriter.Name} file...");
            headerMethod.Invoke(instance, new object[] {"C:/Users/Yan/Documents/TelemetryData/Data.pds"});
            var result = exportMethod.Invoke(instance, new object[] { packet, "C:/Users/Yan/Documents/TelemetryData/Data.pds" });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao invocar o método: {ex.Message}");
            throw;
        }
    }

    public static object DeserializePacketDynamic(byte[] buffer, Type packetType)
    {
        if (buffer == null)
        {
            throw new ArgumentNullException(nameof(buffer), "Buffer cannot be null.");
        }

        if (packetType == null)
        {
            throw new ArgumentNullException(nameof(packetType), "Packet type cannot be null.");
        }

        // Obter o tamanho esperado da estrutura
        var size = Marshal.SizeOf(packetType);

        // Verificar se o buffer tem tamanho suficiente
        if (buffer.Length < size)
        {
            throw new ArgumentOutOfRangeException(nameof(buffer), "Buffer size is smaller than the expected size of the structure.");
        }

        // Alocar memória para a estrutura
        var ptr = Marshal.AllocHGlobal(size);

        try
        {
            // Copiar os bytes do buffer para o ponteiro alocado
            Marshal.Copy(buffer, 0, ptr, size);

            // Deserializar o pacote e retornar
            return Marshal.PtrToStructure(ptr, packetType)!;
        }
        finally
        {
            // Garantir que a memória alocada seja liberada
            Marshal.FreeHGlobal(ptr);
        }
    }

        public static void PrintPacketHeader(PacketHeader header)
        {
            Console.WriteLine($"Packet Format: {header.m_packetFormat}");
            Console.WriteLine($"Game Major Version: {header.m_gameMajorVersion}");
            Console.WriteLine($"Game Minor Version: {header.m_gameMinorVersion}");
            Console.WriteLine($"Packet Version: {header.m_packetVersion}");
            Console.WriteLine($"Packet ID: {header.m_packetId}");
            Console.WriteLine($"Session UID: {header.m_sessionUID}");
            Console.WriteLine($"Session Time: {header.m_sessionTime}");
            Console.WriteLine($"Frame Identifier: {header.m_frameIdentifier}");
            Console.WriteLine($"Player Car Index: {header.m_playerCarIndex}");
            Console.WriteLine($"Secondary Player Car Index: {header.m_secondaryPlayerCarIndex}");
        }

        public static void PrintPacketDetails(object packet)
        {
            if (packet is PacketMotion motionData)
            {
                Console.WriteLine("Motion Packet Details:");
                // Exemplo: Print fields of motion data
                Console.WriteLine($"Motion Data: {motionData.m_frontWheelsAngle}, {motionData.m_wheelSpeed[0]}, {motionData.m_localVelocityX}");
                Console.WriteLine($"Car Motion Data: {motionData.m_carMotionData[0].m_gForceLateral}, {motionData.m_carMotionData[0].m_gForceLongitudinal}, {motionData.m_carMotionData[0].m_gForceVertical}");
            }
            else if (packet is PacketSession sessionData)
            {
                Console.WriteLine("Session Packet Details:");
                // Exemplo: Print fields of session data
                // Console.WriteLine($"Weather: {sessionData.m_weather}");
            }
        }
    }
}