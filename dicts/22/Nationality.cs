using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f122.Nationality
{
    public class Nationality
    {
        private static readonly Dictionary<int, string> NationalityNames = new Dictionary<int, string>
        {
            { 1, "American" },
            { 2, "Argentinean" },
            { 3, "Australian" },
            { 4, "Austrian" },
            { 5, "Azerbaijani" },
            { 6, "Bahraini" },
            { 7, "Belgian" },
            { 8, "Bolivian" },
            { 9, "Brazilian" },
            { 10, "British" },
            { 11, "Bulgarian" },
            { 12, "Cameroonian" },
            { 13, "Canadian" },
            { 14, "Chilean" },
            { 15, "Chinese" },
            { 16, "Colombian" },
            { 17, "Costa Rican" },
            { 18, "Croatian" },
            { 19, "Cypriot" },
            { 20, "Czech" },
            { 21, "Danish" },
            { 22, "Dutch" },
            { 23, "Ecuadorian" },
            { 24, "English" },
            { 25, "Emirian" },
            { 26, "Estonian" },
            { 27, "Finnish" },
            { 28, "French" },
            { 29, "German" },
            { 30, "Ghanaian" },
            { 31, "Greek" },
            { 32, "Guatemalan" },
            { 33, "Honduran" },
            { 34, "Hong Konger" },
            { 35, "Hungarian" },
            { 36, "Icelander" },
            { 37, "Indian" },
            { 38, "Indonesian" },
            { 39, "Irish" },
            { 40, "Israeli" },
            { 41, "Italian" },
            { 42, "Jamaican" },
            { 43, "Japanese" },
            { 44, "Jordanian" },
            { 45, "Kuwaiti" },
            { 46, "Latvian" },
            { 47, "Lebanese" },
            { 48, "Lithuanian" },
            { 49, "Luxembourger" },
            { 50, "Malaysian" },
            { 51, "Maltese" },
            { 52, "Mexican" },
            { 53, "Monegasque" },
            { 54, "New Zealander" },
            { 55, "Nicaraguan" },
            { 56, "North Korean" },
            { 57, "Northern Irish" },
            { 58, "Norwegian" },
            { 59, "Omani" },
            { 60, "Pakistani" },
            { 61, "Panamanian" },
            { 62, "Paraguayan" },
            { 63, "Peruvian" },
            { 64, "Polish" },
            { 65, "Portuguese" },
            { 66, "Qatari" },
            { 67, "Romanian" },
            { 68, "Russian" },
            { 69, "Salvadoran" },
            { 70, "Saudi" },
            { 71, "Scottish" },
            { 72, "Serbian" },
            { 73, "Singaporean" },
            { 74, "Slovakian" },
            { 75, "Slovenian" },
            { 76, "South Korean" },
            { 77, "South African" },
            { 78, "Spanish" },
            { 79, "Swedish" },
            { 80, "Swiss" },
            { 81, "Thai" },
            { 82, "Turkish" },
            { 83, "Uruguayan" },
            { 84, "Ukrainian" },
            { 85, "Venezuelan" },
            { 86, "Welsh" },
            { 87, "Barbadian" },
            { 88, "Vietnamese" }
        };

        public static string GetNationalityName(int nationalityId)
        {
            if (NationalityNames.ContainsKey(nationalityId))
            {
                return NationalityNames[nationalityId];
            }
            else
            {
                return "Unknown Nationality";
            }
        }
    }
}
