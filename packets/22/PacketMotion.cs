using System;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Motion
{
    // Estrutura para dados de movimento do carro
    public struct CarMotionData
    {
        public float m_worldPositionX; // World space X position
        public float m_worldPositionY; // World space Y position
        public float m_worldPositionZ; // World space Z position
        public float m_worldVelocityX; // Velocity in world space X
        public float m_worldVelocityY; // Velocity in world space Y
        public float m_worldVelocityZ; // Velocity in world space Z
        public short m_worldForwardDirX; // World space forward X direction (normalized)
        public short m_worldForwardDirY; // World space forward Y direction (normalized)
        public short m_worldForwardDirZ; // World space forward Z direction (normalized)
        public short m_worldRightDirX; // World space right X direction (normalized)
        public short m_worldRightDirY; // World space right Y direction (normalized)
        public short m_worldRightDirZ; // World space right Z direction (normalized)
        public float m_gForceLateral; // Lateral G-Force component
        public float m_gForceLongitudinal; // Longitudinal G-Force component
        public float m_gForceVertical; // Vertical G-Force component
        public float m_yaw; // Yaw angle in radians
        public float m_pitch; // Pitch angle in radians
        public float m_roll; // Roll angle in radians
    }

    // Estrutura para os dados do pacote de movimento
    public struct PacketMotionData
    {
        public PacketHeader m_header; // Cabeçalho
        public CarMotionData[] m_carMotionData; // Dados para todos os carros na pista

        // Dados exclusivos para o carro do jogador
        public float[] m_suspensionPosition; // Posição da suspensão [RL, RR, FL, FR]
        public float[] m_suspensionVelocity; // Velocidade da suspensão [RL, RR, FL, FR]
        public float[] m_suspensionAcceleration; // Aceleração da suspensão [RL, RR, FL, FR]
        public float[] m_wheelSpeed; // Velocidade de cada roda
        public float[] m_wheelSlip; // Coeficiente de deslizamento para cada roda
        public float m_localVelocityX; // Velocidade na direção X no espaço local
        public float m_localVelocityY; // Velocidade na direção Y no espaço local
        public float m_localVelocityZ; // Velocidade na direção Z no espaço local
        public float m_angularVelocityX; // Velocidade angular no eixo X
        public float m_angularVelocityY; // Velocidade angular no eixo Y
        public float m_angularVelocityZ; // Velocidade angular no eixo Z
        public float m_angularAccelerationX; // Aceleração angular no eixo X
        public float m_angularAccelerationY; // Aceleração angular no eixo Y
        public float m_angularAccelerationZ; // Aceleração angular no eixo Z
        public float m_frontWheelsAngle; // Ângulo atual das rodas dianteiras em radianos
    }
}
