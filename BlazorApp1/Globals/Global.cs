using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using BlazorApp1.Models;

namespace BlazorApp1.Globals
{
    public static class Global
    {
        public static List<TeamModel> Teams { get; set; } = new List<TeamModel>();
        public static int CurrentRound { get; set; } = 0;
        public static int NumberOfTeams { get; set; }
        public static int Round { get; set; } = 5;
        public static int Counter { get; set; } = 0;
        public static bool ShowSidebar { get; set; } = false;

        public static string SerializeToJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var globalState = new
            {
                Teams,
                CurrentRound,
                NumberOfTeams,
                Round,
                Counter
            };

            return JsonSerializer.Serialize(globalState, options);
        }

        public static void DeserializeFromJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            var globalState = JsonSerializer.Deserialize<GlobalState>(json, options);

            if (globalState != null)
            {
                Teams = globalState.Teams ?? new List<TeamModel>();
                CurrentRound = globalState.CurrentRound;
                NumberOfTeams = globalState.NumberOfTeams;
                Round = globalState.Round;
                Counter = globalState.Counter;
            }
        }

        private class GlobalState
        {
            public List<TeamModel> Teams { get; set; }
            public int CurrentRound { get; set; }
            public int NumberOfTeams { get; set; }
            public int Round { get; set; }
            public int Counter { get; set; }
        }

        // Method to save JSON to a file
        public static void SaveToFile(string filePath)
        {
            string json = SerializeToJson();
            File.WriteAllText(filePath, json);
        }

        // Method to load JSON from a file
        public static void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                DeserializeFromJson(json);
            }
            else
            {
                throw new FileNotFoundException($"The file {filePath} does not exist.");
            }
        }
    }
}
