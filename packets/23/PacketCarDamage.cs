using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Damage
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct CarDamageData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_tyresWear;              // Desgaste dos pneus (percentual)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_tyresDamage;             // Dano dos pneus (percentual)
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_brakesDamage;            // Dano dos freios (percentual)
        
        public byte m_frontLeftWingDamage;       // Dano na asa dianteira esquerda (percentual)
        public byte m_frontRightWingDamage;      // Dano na asa dianteira direita (percentual)
        public byte m_rearWingDamage;            // Dano na asa traseira (percentual)
        public byte m_floorDamage;               // Dano no assoalho (percentual)
        public byte m_diffuserDamage;            // Dano no difusor (percentual)
        public byte m_sidepodDamage;             // Dano na lateral do carro (percentual)
        public byte m_drsFault;                  // Indicador de falha do DRS, 0 = OK, 1 = falha
        public byte m_ersFault;                  // Indicador de falha do ERS, 0 = OK, 1 = falha
        public byte m_gearBoxDamage;             // Dano na caixa de câmbio (percentual)
        public byte m_engineDamage;              // Dano no motor (percentual)
        public byte m_engineMGUHWear;            // Desgaste do motor MGU-H (percentual)
        public byte m_engineESWear;              // Desgaste do motor ES (percentual)
        public byte m_engineCEWear;              // Desgaste do motor CE (percentual)
        public byte m_engineICEWear;             // Desgaste do motor ICE (percentual)
        public byte m_engineMGUKWear;            // Desgaste do motor MGU-K (percentual)
        public byte m_engineTCWear;              // Desgaste do motor TC (percentual)
        public byte m_engineBlown;               // Motor quebrado, 0 = OK, 1 = falha
        public byte m_engineSeized;              // Motor travado, 0 = OK, 1 = falha
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarDamageData
    {
        public PacketHeader m_header;             // Cabeçalho
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarDamageData[] m_carDamageData;   // Dados de dano para todos os carros (até 22 carros)
    }
}
