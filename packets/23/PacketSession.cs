using System;
using System.Runtime.InteropServices;
using TelemetryViewer.Packets.f123.Header;

namespace TelemetryViewer.Packets.f123.Session
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MarshalZone
    {
        public float ZoneStart;  // Fraction (0..1) of way through the lap the marshal zone starts
        public sbyte ZoneFlag;   // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct WeatherForecastSample
    {
        public byte SessionType;                  // 0 = unknown, 1 = P1, 2 = P2, 3 = P3, 4 = Short P, 5 = Q1
                                                  // 6 = Q2, 7 = Q3, 8 = Short Q, 9 = OSQ, 10 = R, 11 = R2
                                                  // 12 = Time Trial
        public byte TimeOffset;                   // Time in minutes the forecast is for
        public byte Weather;                      // Weather - 0 = clear, 1 = light cloud, 2 = overcast
                                                  // 3 = light rain, 4 = heavy rain, 5 = storm
        public sbyte TrackTemperature;            // Track temp. in degrees Celsius
        public sbyte TrackTemperatureChange;      // Track temp. change – 0 = up, 1 = down, 2 = no change
        public sbyte AirTemperature;              // Air temp. in degrees Celsius
        public sbyte AirTemperatureChange;        // Air temp. change – 0 = up, 1 = down, 2 = no change
        public byte RainPercentage;               // Rain percentage (0-100)
    };

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketSessionData
    {
        public PacketHeader Header;               // Header

        public byte Weather;                      // Weather - 0 = clear, 1 = light cloud, 2 = overcast
                                                  // 3 = light rain, 4 = heavy rain, 5 = storm
        public sbyte TrackTemperature;            // Track temp. in degrees Celsius
        public sbyte AirTemperature;              // Air temp. in degrees Celsius
        public byte TotalLaps;                    // Total number of laps in this race
        public ushort TrackLength;                // Track length in metres
        public byte SessionType;                  // Session type
        public sbyte TrackId;                     // -1 for unknown
        public byte Formula;                      // Formula
        public ushort SessionTimeLeft;            // Time left in session in seconds
        public ushort SessionDuration;            // Session duration in seconds
        public byte PitSpeedLimit;                // Pit speed limit in kilometres per hour
        public byte GamePaused;                   // Whether the game is paused
        public byte IsSpectating;                 // Whether the player is spectating
        public byte SpectatorCarIndex;            // Index of the car being spectated
        public byte SliProNativeSupport;          // SLI Pro support, 0 = inactive, 1 = active
        public byte NumMarshalZones;              // Number of marshal zones
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        public MarshalZone[] MarshalZones;        // List of marshal zones – max 21
        public byte SafetyCarStatus;              // Safety car status
        public byte NetworkGame;                  // Network game status
        public byte NumWeatherForecastSamples;    // Number of weather samples
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
        public WeatherForecastSample[] WeatherForecastSamples; // Weather forecast samples
        public byte ForecastAccuracy;             // Forecast accuracy
        public byte AiDifficulty;                 // AI Difficulty rating
        public uint SeasonLinkIdentifier;         // Identifier for season
        public uint WeekendLinkIdentifier;        // Identifier for weekend
        public uint SessionLinkIdentifier;        // Identifier for session
        public byte PitStopWindowIdealLap;        // Ideal lap to pit
        public byte PitStopWindowLatestLap;       // Latest lap to pit
        public byte PitStopRejoinPosition;        // Predicted rejoin position
        public byte SteeringAssist;               // Steering assist
        public byte BrakingAssist;                // Braking assist
        public byte GearboxAssist;                // Gearbox assist
        public byte PitAssist;                    // Pit assist
        public byte PitReleaseAssist;             // Pit release assist
        public byte ErsAssist;                    // ERS assist
        public byte DrsAssist;                    // DRS assist
        public byte DynamicRacingLine;            // Dynamic racing line
        public byte DynamicRacingLineType;        // Dynamic racing line type
        public byte GameMode;                     // Game mode ID
        public byte RuleSet;                      // Rule set
        public uint TimeOfDay;                    // Time of day
        public byte SessionLength;                // Session length
        public byte SpeedUnitsLeadPlayer;         // Speed units (lead player)
        public byte TemperatureUnitsLeadPlayer;   // Temperature units (lead player)
        public byte SpeedUnitsSecondaryPlayer;    // Speed units (secondary player)
        public byte TemperatureUnitsSecondaryPlayer; // Temperature units (secondary player)
        public byte NumSafetyCarPeriods;          // Number of safety car periods
        public byte NumVirtualSafetyCarPeriods;   // Number of virtual safety car periods
        public byte NumRedFlagPeriods;            // Number of red flag periods
    };
}
