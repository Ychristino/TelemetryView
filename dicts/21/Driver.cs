using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f121.Driver
{
    public class Driver
    {
        private static readonly Dictionary<int, string> DriverNames = new Dictionary<int, string>
        {
            { 0, "Carlos Sainz" },
            { 1, "Daniil Kvyat" },
            { 2, "Daniel Ricciardo" },
            { 3, "Fernando Alonso" },
            { 4, "Felipe Massa" },
            { 6, "Kimi Räikkönen" },
            { 7, "Lewis Hamilton" },
            { 9, "Max Verstappen" },
            { 10, "Nico Hulkenburg" },
            { 11, "Kevin Magnussen" },
            { 12, "Romain Grosjean" },
            { 13, "Sebastian Vettel" },
            { 14, "Sergio Perez" },
            { 15, "Valtteri Bottas" },
            { 17, "Esteban Ocon" },
            { 19, "Lance Stroll" },
            { 20, "Arron Barnes" },
            { 21, "Martin Giles" },
            { 22, "Alex Murray" },
            { 23, "Lucas Roth" },
            { 24, "Igor Correia" },
            { 25, "Sophie Levasseur" },
            { 26, "Jonas Schiffer" },
            { 27, "Alain Forest" },
            { 28, "Jay Letourneau" },
            { 29, "Esto Saari" },
            { 30, "Yasar Atiyeh" },
            { 31, "Callisto Calabresi" },
            { 32, "Naota Izum" },
            { 33, "Howard Clarke" },
            { 34, "Wilhelm Kaufmann" },
            { 35, "Marie Laursen" },
            { 36, "Flavio Nieves" },
            { 37, "Peter Belousov" },
            { 38, "Klimek Michalski" },
            { 39, "Santiago Moreno" },
            { 40, "Benjamin Coppens" },
            { 41, "Noah Visser" },
            { 42, "Gert Waldmuller" },
            { 43, "Julian Quesada" },
            { 44, "Daniel Jones" },
            { 45, "Artem Markelov" },
            { 46, "Tadasuke Makino" },
            { 47, "Sean Gelael" },
            { 48, "Nyck De Vries" },
            { 49, "Jack Aitken" },
            { 50, "George Russell" },
            { 51, "Maximilian Günther" },
            { 52, "Nirei Fukuzumi" },
            { 53, "Luca Ghiotto" },
            { 54, "Lando Norris" },
            { 55, "Sérgio Sette Câmara" },
            { 56, "Louis Delétraz" },
            { 57, "Antonio Fuoco" },
            { 58, "Charles Leclerc" },
            { 59, "Pierre Gasly" },
            { 62, "Alexander Albon" },
            { 63, "Nicholas Latifi" },
            { 64, "Dorian Boccolacci" },
            { 65, "Niko Kari" },
            { 66, "Roberto Merhi" },
            { 67, "Arjun Maini" },
            { 68, "Alessio Lorandi" },
            { 69, "Ruben Meijer" },
            { 70, "Rashid Nair" },
            { 71, "Jack Tremblay" },
            { 72, "Devon Butler" },
            { 73, "Lukas Weber" },
            { 74, "Antonio Giovinazzi" },
            { 75, "Robert Kubica" },
            { 76, "Alain Prost" },
            { 77, "Ayrton Senna" },
            { 78, "Nobuharu Matsushita" },
            { 79, "Nikita Mazepin" },
            { 80, "Guanyu Zhou" },
            { 81, "Mick Schumacher" },
            { 82, "Callum Ilott" },
            { 83, "Juan Manuel Correa" },
            { 84, "Jordan King" },
            { 85, "Mahaveer Raghunathan" },
            { 86, "Tatiana Calderón" },
            { 87, "Anthoine Hubert" },
            { 88, "Giuliano Alesi" },
            { 89, "Ralph Boschung" },
            { 90, "Michael Schumacher" },
            { 91, "Dan Ticktum" },
            { 92, "Marcus Armstrong" },
            { 93, "Christian Lundgaard" },
            { 94, "Yuki Tsunoda" },
            { 95, "Jehan Daruvala" },
            { 96, "Guilherme Samaia" },
            { 97, "Pedro Piquet" },
            { 98, "Felipe Drugovich" },
            { 99, "Robert Schwartzman" },
            { 100, "Roy Nissany" },
            { 101, "Marino Sato" },
            { 102, "Aidan Jackson" },
            { 109, "Jenson Button" },
            { 110, "David Coulthard" },
            { 111, "Nico Rosberg" }
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
