using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f122.Damage;

namespace TelemetryViewer.GeneratePDS.f122.Damage
{
    public class PDSCarDamage : PDSExport<PacketCarDamage>
    {
        public override void ExportPdsHeader(string filePath){
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Damage Data (F122)");
                writer.WriteLine("# Columns: Car Index, Tyres Wear RL, Tyres Wear RR, Tyres Wear FL, Tyres Wear FR, " +
                                 "Tyres Damage RL, Tyres Damage RR, Tyres Damage FL, Tyres Damage FR, " +
                                 "Brakes Damage RL, Brakes Damage RR, Brakes Damage FL, Brakes Damage FR, Front Left Wing Damage, Front Right Wing Damage, Rear Wing Damage, " +
                                 "Floor Damage, Diffuser Damage, Sidepod Damage, DRS Fault, ERS Fault, Gearbox Damage, Engine Damage, Engine MGU-H Wear, Engine ES Wear, " +
                                 " Engine CE Wear, Engine ICE Wear, Engine MGU-K Wear, Engine TC Wear, Engine Blown, Engine Seized");
            }
        }

        public override void ExportToPds(PacketCarDamage packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                // Iterar sobre os dados de danos de todos os carros e exportar para o CSV
                for (int i = 0; i < packetData.m_carDamageData.Length; i++)
                {
                    var carDamage = packetData.m_carDamageData[i];

                    // Converter os dados de desgaste e danos dos pneus, freios, etc. para strings
                    string tyresWear = string.Join(", ", carDamage.m_tyresWear);
                    string tyresDamage = string.Join(", ", carDamage.m_tyresDamage);
                    string brakesDamage = string.Join(", ", carDamage.m_brakesDamage);

                    // Escrever os dados formatados para cada carro
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}",
                        i, // Índice do carro
                        tyresWear,
                        tyresDamage,
                        brakesDamage,
                        carDamage.m_frontLeftWingDamage,
                        carDamage.m_frontRightWingDamage,
                        carDamage.m_rearWingDamage,
                        carDamage.m_floorDamage,
                        carDamage.m_diffuserDamage,
                        carDamage.m_sidepodDamage,
                        carDamage.m_drsFault,
                        carDamage.m_ersFault,
                        carDamage.m_gearBoxDamage,
                        carDamage.m_engineDamage,
                        carDamage.m_engineMGUHWear,
                        carDamage.m_engineESWear,
                        carDamage.m_engineCEWear,
                        carDamage.m_engineICEWear,
                        carDamage.m_engineMGUKWear,
                        carDamage.m_engineTCWear,
                        carDamage.m_engineBlown,
                        carDamage.m_engineSeized));
                }
            }

            Console.WriteLine($"PacketCarDamageData F122 Sucesso: {filePath}");
        }
    }
}
