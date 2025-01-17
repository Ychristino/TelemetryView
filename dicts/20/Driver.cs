using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f120.Driver
{
    public class Driver
    {
        private static readonly Dictionary<int, string> DriverNames = new Dictionary<int, string>
        {
            { 0, "Carlos Sainz" },
            { 36, "Flavio Nieves" },
            { 68, "Alessio Lorandi" },
            { 1, "Daniil Kvyat" },
            { 37, "Peter Belousov" },
            { 69, "Ruben Meijer" },
            { 2, "Daniel Ricciardo" },
            { 38, "Klimek Michalski" },
            { 70, "Rashid Nair" },
            { 6, "Kimi Räikkönen" },
            { 39, "Santiago Moreno" },
            { 71, "Jack Tremblay" },
            { 7, "Lewis Hamilton" },
            { 40, "Benjamin Coppens" },
            { 74, "Antonio Giovinazzi" },
            { 9, "Max Verstappen" },
            { 41, "Noah Visser" },
            { 75, "Robert Kubica" },
            { 10, "Nico Hulkenberg" },
            { 42, "Gert Waldmuller" },
            { 78, "Nobuharu Matsushita" },
            { 11, "Kevin Magnussen" },
            { 43, "Julian Quesada" },
            { 79, "Nikita Mazepin" },
            { 12, "Romain Grosjean" },
            { 44, "Daniel Jones" },
            { 80, "Guanyu Zhou" },
            { 13, "Sebastian Vettel" },
            { 45, "Artem Markelov" },
            { 81, "Mick Schumacher" },
            { 14, "Sergio Perez" },
            { 46, "Tadasuke Makino" },
            { 82, "Callum Ilott" },
            { 15, "Valtteri Bottas" },
            { 47, "Sean Gelael" },
            { 83, "Juan Manuel Correa" },
            { 17, "Esteban Ocon" },
            { 48, "Nyck De Vries" },
            { 84, "Jordan King" },
            { 19, "Lance Stroll" },
            { 49, "Jack Aitken" },
            { 85, "Mahaveer Raghunathan" },
            { 20, "Arron Barnes" },
            { 50, "George Russell" },
            { 86, "Tatiana Calderón" },
            { 21, "Martin Giles" },
            { 51, "Maximilian Günther" },
            { 87, "Anthoine Hubert" },
            { 22, "Alex Murray" },
            { 52, "Nirei Fukuzumi" },
            { 88, "Giuliano Alesi" },
            { 23, "Lucas Roth" },
            { 53, "Luca Ghiotto" },
            { 89, "Ralph Boschung" },
            { 24, "Igor Correia" },
            { 54, "Lando Norris" },
            { 25, "Sophie Levasseur" },
            { 55, "Sérgio Sette Câmara" },
            { 26, "Jonas Schiffer" },
            { 56, "Louis Delétraz" },
            { 27, "Alain Forest" },
            { 57, "Antonio Fuoco" },
            { 28, "Jay Letourneau" },
            { 58, "Charles Leclerc" },
            { 29, "Esto Saari" },
            { 59, "Pierre Gasly" },
            { 30, "Yasar Atiyeh" },
            { 62, "Alexander Albon" },
            { 31, "Callisto Calabresi" },
            { 63, "Nicholas Latifi" },
            { 32, "Naota Izum" },
            { 64, "Dorian Boccolacci" },
            { 33, "Howard Clarke" },
            { 65, "Niko Kari" },
            { 34, "Wilhelm Kaufmann" },
            { 66, "Roberto Merhi" },
            { 35, "Marie Laursen" },
            { 67, "Arjun Maini" }
        };

        public static string GetDriverName(int driverId)
        {
            if (DriverNames.ContainsKey(driverId))
            {
                return DriverNames[driverId];
            }
            else
            {
                return "Unknown Driver";
            }
        }
    }
}
