using BlazorApp1.Models;

namespace BlazorApp1.Globals
{
    public static class Global
    {
        public static List<TeamModel> Teams { get; set; } = new List<TeamModel>();

        public static int CurrentRound = 0;

        public static int NumberOfTeams;
        public static int Round = 5;
        public static int Counter = 0;
    }
}
