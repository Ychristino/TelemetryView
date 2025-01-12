using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Telemetry
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarTelemetryData
    {
        public ushort m_speed;                           // Velocidade do carro em quilômetros por hora
        public float m_throttle;                         // Quantidade de acelerador aplicada (0.0 a 1.0)
        public float m_steer;                            // Direção da direção (-1.0 (volante completamente à esquerda) a 1.0 (volante completamente à direita))
        public float m_brake;                           // Quantidade de freio aplicada (0.0 a 1.0)
        public byte m_clutch;                           // Quantidade de embreagem aplicada (0 a 100)
        public sbyte m_gear;                            // Marcha selecionada (1-8, N=0, R=-1)
        public ushort m_engineRPM;                      // RPM do motor
        public byte m_drs;                              // 0 = off, 1 = on
        public byte m_revLightsPercent;                 // Indicador de luzes de RPM (percentual)
        public ushort m_revLightsBitValue;              // Luzes de RPM (bit 0 = LED mais à esquerda, bit 14 = LED mais à direita)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public ushort[] m_brakesTemperature;            // Temperatura dos freios (Celsius)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresSurfaceTemperature;       // Temperatura da superfície dos pneus (Celsius)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresInnerTemperature;         // Temperatura interna dos pneus (Celsius)
        
        public ushort m_engineTemperature;             // Temperatura do motor (Celsius)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_tyresPressure;                // Pressão dos pneus (PSI)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_surfaceType;                   // Tipo de superfície de direção
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarTelemetryData
    {
        public PacketHeader m_header;                                // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarTelemetryData[] m_carTelemetryData;                // Dados de telemetria para até 22 carros

        public byte m_mfdPanelIndex;                                  // Índice do painel MFD aberto - 255 = MFD fechado
        public byte m_mfdPanelIndexSecondaryPlayer;                   // Índice do painel MFD para o jogador secundário
        public sbyte m_suggestedGear;                                  // Marcha sugerida para o jogador (1-8), 0 se nenhuma marcha sugerida
    }
}
