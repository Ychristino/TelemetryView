using System;
using System.Globalization;
using System.IO;
using TelemetryViewer.Packets.f123.Damage; // Alterado para o namespace f123.Damage

namespace TelemetryViewer.GeneratePDS.f123.Damage
{
    public class PDSCarDamageData : PDSExport<PacketCarDamageData>
    {
        public override void ExportToPds(PacketCarDamageData packetData, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escrever o cabeçalho do arquivo CSV
                writer.WriteLine("\n# Car Damage Data (F123)"); // Atualizado para F123
                writer.WriteLine("# Columns: Car Index, Front Left Wing Damage, Front Right Wing Damage, " +
                                 "Rear Wing Damage, Floor Damage, Diffuser Damage, Sidepod Damage, DRS Fault, ERS Fault, " +
                                 "Gear Box Damage, Engine Damage, Engine MGU-H Wear, Engine ES Wear, Engine CE Wear, Engine ICE Wear, " +
                                 "Engine MGU-K Wear, Engine TC Wear, Engine Blown, Engine Seized, Tyre Wear (Front Left, Front Right, Rear Left, Rear Right), " +
                                 "Tyre Damage (Front Left, Front Right, Rear Left, Rear Right), Brake Damage (Front Left, Front Right, Rear Left, Rear Right)");

                // Escrever os dados de danos para cada carro
                for (int i = 0; i < packetData.m_carDamageData.Length; i++)
                {
                    CarDamageData carData = packetData.m_carDamageData[i];
                    writer.WriteLine(string.Format(CultureInfo.InvariantCulture,
                        "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, " +
                        "{20}, {21}, {22}, {23}",
                        i, // Índice do carro (assumindo que é a posição no array)
                        carData.m_frontLeftWingDamage,
                        carData.m_frontRightWingDamage,
                        carData.m_rearWingDamage,
                        carData.m_floorDamage,
                        carData.m_diffuserDamage,
                        carData.m_sidepodDamage,
                        carData.m_drsFault,
                        carData.m_ersFault,
                        carData.m_gearBoxDamage,
                        carData.m_engineDamage,
                        carData.m_engineMGUHWear,
                        carData.m_engineESWear,
                        carData.m_engineCEWear,
                        carData.m_engineICEWear,
                        carData.m_engineMGUKWear,
                        carData.m_engineTCWear,
                        carData.m_engineBlown,
                        carData.m_engineSeized,
                        string.Join(", ", carData.m_tyresWear), // Concatenando os valores de desgaste dos pneus
                        string.Join(", ", carData.m_tyresDamage), // Concatenando os valores de dano dos pneus
                        string.Join(", ", carData.m_brakesDamage)  // Concatenando os valores de dano nos freios
                    ));
                }
            }

            Console.WriteLine($"PacketCarDamageData F123 Sucesso: {filePath}");
        }
    }
}
