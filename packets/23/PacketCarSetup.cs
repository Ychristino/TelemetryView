using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.CarSetup
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarSetupData
    {
        public byte m_frontWing;               // Aero da asa dianteira
        public byte m_rearWing;                // Aero da asa traseira
        public byte m_onThrottle;              // Ajuste do diferencial na aceleração (porcentagem)
        public byte m_offThrottle;             // Ajuste do diferencial na desaceleração (porcentagem)
        public float m_frontCamber;            // Ângulo de câmber dianteiro (geometria da suspensão)
        public float m_rearCamber;             // Ângulo de câmber traseiro (geometria da suspensão)
        public float m_frontToe;               // Ângulo de ângulo de alinhamento dianteiro (geometria da suspensão)
        public float m_rearToe;                // Ângulo de alinhamento traseiro (geometria da suspensão)
        public byte m_frontSuspension;         // Suspensão dianteira
        public byte m_rearSuspension;          // Suspensão traseira
        public byte m_frontAntiRollBar;        // Barra estabilizadora dianteira
        public byte m_rearAntiRollBar;         // Barra estabilizadora traseira
        public byte m_frontSuspensionHeight;   // Altura da suspensão dianteira
        public byte m_rearSuspensionHeight;    // Altura da suspensão traseira
        public byte m_brakePressure;           // Pressão do freio (porcentagem)
        public byte m_brakeBias;               // Bias do freio (porcentagem)
        public float m_rearLeftTyrePressure;   // Pressão do pneu traseiro esquerdo (PSI)
        public float m_rearRightTyrePressure;  // Pressão do pneu traseiro direito (PSI)
        public float m_frontLeftTyrePressure;  // Pressão do pneu dianteiro esquerdo (PSI)
        public float m_frontRightTyrePressure; // Pressão do pneu dianteiro direito (PSI)
        public byte m_ballast;                 // Lastro
        public float m_fuelLoad;               // Carga de combustível
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarSetupData
    {
        public PacketHeader m_header;                  // Cabeçalho do pacote
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarSetupData[] m_carSetups;             // Configuração do carro para até 22 carros
    }
}
