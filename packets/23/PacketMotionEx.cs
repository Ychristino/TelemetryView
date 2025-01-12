using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.MotionEx
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketMotionExData
    {
        public PacketHeader m_header;               // Cabeçalho

        // Dados específicos do carro do jogador
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionPosition;        // Posições das suspensões (RL, RR, FL, FR)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionVelocity;        // Velocidade das suspensões (RL, RR, FL, FR)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionAcceleration;    // Aceleração das suspensões (RL, RR, FL, FR)

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelSpeed;                // Velocidade de cada roda

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelSlipRatio;            // Razão de deslizamento de cada roda

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelSlipAngle;            // Ângulo de deslizamento de cada roda

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelLatForce;             // Forças laterais para cada roda

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelLongForce;            // Forças longitudinais para cada roda

        public float m_heightOfCOGAboveGround;      // Altura do centro de gravidade em relação ao solo

        public float m_localVelocityX;              // Velocidade no espaço local – metros/s
        public float m_localVelocityY;              // Velocidade no espaço local
        public float m_localVelocityZ;              // Velocidade no espaço local

        public float m_angularVelocityX;            // Velocidade angular componente x – rad/s
        public float m_angularVelocityY;            // Velocidade angular componente y
        public float m_angularVelocityZ;            // Velocidade angular componente z

        public float m_angularAccelerationX;        // Aceleração angular componente x – rad/s²
        public float m_angularAccelerationY;        // Aceleração angular componente y
        public float m_angularAccelerationZ;        // Aceleração angular componente z

        public float m_frontWheelsAngle;            // Ângulo atual das rodas dianteiras em radianos

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelVertForce;            // Forças verticais para cada roda
    }
}
