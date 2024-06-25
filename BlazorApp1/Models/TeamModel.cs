namespace BlazorApp1.Models
{
    public class TeamModel
    {
        // Parameterless constructor for deserialization
        public TeamModel()
        {
        }

        // Constructor with parameters for initializing
        public TeamModel(int rounds)
        {
            for (int i = 0; i < rounds; i++)
            {
                TeamRounds.Add(new TeamRound() { RoundNumber = i + 1 });
            }
        }

        public string Name { get; set; }
        public int Score { get; set; }
        public string TeamName { get; set; }
        public int TeamNumber { get; set; }
        public List<TeamRound> TeamRounds { get; set; } = new List<TeamRound>();
    }
}