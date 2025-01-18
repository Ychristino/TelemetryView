using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.CarTelemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarTelemetryData
    {
        public ushort m_speed; // Velocidade do carro em quilômetros por hora
        public float m_throttle; // Quantidade de aceleração aplicada (0.0 a 1.0)
        public float m_steer; // Direção (-1.0 = total à esquerda, 1.0 = total à direita)
        public float m_brake; // Quantidade de frenagem aplicada (0.0 a 1.0)
        public byte m_clutch; // Quantidade de embreagem aplicada (0 a 100)
        public sbyte m_gear; // Marcha selecionada (1-8, N=0, R=-1)
        public ushort m_engineRPM; // RPM do motor
        public byte m_drs; // 0 = desligado, 1 = ativado
        public byte m_revLightsPercent; // Percentual de luzes de giro (indicador de RPM)
        public ushort m_revLightsBitValue; // Luzes de giro (bit 0 = LED mais à esquerda, bit 14 = LED mais à direita)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] m_brakesTemperature; // Temperatura dos freios (Celsius)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresSurfaceTemperature; // Temperatura da superfície dos pneus (Celsius)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresInnerTemperature; // Temperatura interna dos pneus (Celsius)
        public ushort m_engineTemperature; // Temperatura do motor (Celsius)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_tyresPressure; // Pressão dos pneus (PSI)
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_surfaceType; // Tipo de superfície de direção (veja os apêndices)
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarTelemetry
    {
        public PacketHeader m_header; // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarTelemetryData[] m_carTelemetryData; // Telemetria dos carros, até 22 carros
        public byte m_mfdPanelIndex; // Índice do painel MFD aberto - 255 = MFD fechado
        // Jogador único, corrida – 0 = Configuração do carro, 1 = Box
        // 2 = Danos, 3 = Motor, 4 = Temperaturas
        // Pode variar dependendo do modo de jogo
        public byte m_mfdPanelIndexSecondaryPlayer; // Veja acima
        public sbyte m_suggestedGear; // Marcha sugerida para o jogador (1-8)
        // 0 se nenhuma marcha sugerida
    };
}
