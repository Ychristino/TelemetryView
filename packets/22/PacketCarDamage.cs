using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f122.Header;

namespace TelemetryViewer.Packets.f122.Damage
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarDamageData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_tyresWear;        // Desgaste dos pneus (porcentagem)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresDamage;      // Danos nos pneus (porcentagem)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_brakesDamage;     // Danos nos freios (porcentagem)
        
        public byte m_frontLeftWingDamage; // Danos na asa dianteira esquerda (porcentagem)
        public byte m_frontRightWingDamage; // Danos na asa dianteira direita (porcentagem)
        public byte m_rearWingDamage;      // Danos na asa traseira (porcentagem)
        public byte m_floorDamage;         // Danos no piso (porcentagem)
        public byte m_diffuserDamage;      // Danos no difusor (porcentagem)
        public byte m_sidepodDamage;       // Danos no sidepod (porcentagem)
        
        public byte m_drsFault;           // Indicador de falha no DRS, 0 = OK, 1 = falha
        public byte m_ersFault;           // Indicador de falha no ERS, 0 = OK, 1 = falha
        
        public byte m_gearBoxDamage;      // Danos na caixa de câmbio (porcentagem)
        public byte m_engineDamage;       // Danos no motor (porcentagem)
        
        public byte m_engineMGUHWear;     // Desgaste do motor MGU-H (porcentagem)
        public byte m_engineESWear;       // Desgaste do motor ES (porcentagem)
        public byte m_engineCEWear;       // Desgaste do motor CE (porcentagem)
        public byte m_engineICEWear;      // Desgaste do motor ICE (porcentagem)
        public byte m_engineMGUKWear;     // Desgaste do motor MGU-K (porcentagem)
        public byte m_engineTCWear;       // Desgaste do motor TC (porcentagem)
        
        public byte m_engineBlown;        // Motor explodido, 0 = OK, 1 = falha
        public byte m_engineSeized;       // Motor travado, 0 = OK, 1 = falha
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarDamage
    {
        public PacketHeader m_header;         // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarDamageData[] m_carDamageData; // Dados de danos para até 22 carros
    }
}
