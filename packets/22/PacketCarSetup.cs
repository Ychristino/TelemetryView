using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.CarSetup
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarSetupData
    {
        public byte m_frontWing; // Aero do wing frontal
        public byte m_rearWing; // Aero do wing traseiro
        public byte m_onThrottle; // Ajuste do diferencial com o acelerador (percentual)
        public byte m_offThrottle; // Ajuste do diferencial sem o acelerador (percentual)
        public float m_frontCamber; // Ângulo de camber dianteiro (geometria da suspensão)
        public float m_rearCamber; // Ângulo de camber traseiro (geometria da suspensão)
        public float m_frontToe; // Ângulo de toe dianteiro (geometria da suspensão)
        public float m_rearToe; // Ângulo de toe traseiro (geometria da suspensão)
        public byte m_frontSuspension; // Suspensão dianteira
        public byte m_rearSuspension; // Suspensão traseira
        public byte m_frontAntiRollBar; // Barra estabilizadora dianteira
        public byte m_rearAntiRollBar; // Barra estabilizadora traseira
        public byte m_frontSuspensionHeight; // Altura da suspensão dianteira
        public byte m_rearSuspensionHeight; // Altura da suspensão traseira
        public byte m_brakePressure; // Pressão dos freios (percentual)
        public byte m_brakeBias; // Viés de frenagem (percentual)
        public float m_rearLeftTyrePressure; // Pressão do pneu traseiro esquerdo (PSI)
        public float m_rearRightTyrePressure; // Pressão do pneu traseiro direito (PSI)
        public float m_frontLeftTyrePressure; // Pressão do pneu dianteiro esquerdo (PSI)
        public float m_frontRightTyrePressure; // Pressão do pneu dianteiro direito (PSI)
        public byte m_ballast; // Lastro
        public float m_fuelLoad; // Carga de combustível
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarSetupData
    {
        public PacketHeader m_header; // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarSetupData[] m_carSetups; // Configurações dos carros, até 22 carros
    };
}
