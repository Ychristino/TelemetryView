using System;
using System.Collections.Generic;

namespace TelemetryViewer.Dicts.f123.Ruleset
{
    public class Ruleset
    {
        private static readonly Dictionary<int, string> RulesetNames = new Dictionary<int, string>
        {
            { 0, "Practice & Qualifying" },
            { 1, "Race" },
            { 2, "Time Trial" },
            { 4, "Time Attack" },
            { 6, "Checkpoint Challenge" },
            { 8, "Autocross" },
            { 9, "Drift" },
            { 10, "Average Speed Zone" },
            { 11, "Rival Duel" }
        };

        public static string GetRulesetName(int rulesetId)
        {
            if (RulesetNames.ContainsKey(rulesetId))
            {
                return RulesetNames[rulesetId];
            }
            else
            {
                return "Unknown Ruleset";
            }
        }
    }
}
