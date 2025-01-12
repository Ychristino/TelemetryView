using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f121.CarDamage;

namespace TelemetryViewer.GeneratePDS.f121.CarDamage
{
    public class PDSCarDamage : PDSExport<PacketCarDamageData>
    {
        public override void ExportToPds(PacketCarDamageData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever a seção de dados de dano do carro
                writer.WriteLine("\n# Car Damage Data (F121)");
                writer.WriteLine("# Columns: Car Index, Tyres Wear (% FL, FR, RL, RR), Tyres Damage (% FL, FR, RL, RR), " +
                                    "Brakes Damage (% FL, FR, RL, RR), Front Left Wing Damage (%), Front Right Wing Damage (%), " +
                                    "Rear Wing Damage (%), Floor Damage (%), Diffuser Damage (%), Sidepod Damage (%), " +
                                    "DRS Fault, Gearbox Damage (%), Engine Damage (%), Engine MGU-H Wear (%), Engine ES Wear (%), " +
                                    "Engine CE Wear (%), Engine ICE Wear (%), Engine MGU-K Wear (%), Engine TC Wear (%)");

                // Iterar sobre os dados de danos de carros e escrever os dados
                for (int i = 0; i < packetData.m_carDamageData.Length; i++)
                {
                    var carDamage = packetData.m_carDamageData[i];

                    // Converte os arrays de danos dos pneus e dos freios em strings formatadas
                    string tyresWear = string.Join(", ", carDamage.m_tyresWear);
                    string tyresDamage = string.Join(", ", carDamage.m_tyresDamage);
                    string brakesDamage = string.Join(", ", carDamage.m_brakesDamage);

                    // Escrever os dados formatados para o arquivo
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}",
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
                        carDamage.m_gearBoxDamage,
                        carDamage.m_engineDamage,
                        carDamage.m_engineMGUHWear,
                        carDamage.m_engineESWear,
                        carDamage.m_engineCEWear,
                        carDamage.m_engineICEWear,
                        carDamage.m_engineMGUKWear,
                        carDamage.m_engineTCWear
                    ));
                }
            }

            Console.WriteLine($"PacketCarDamageData F121 Sucesso: {filePath}");
        }
    }
}
