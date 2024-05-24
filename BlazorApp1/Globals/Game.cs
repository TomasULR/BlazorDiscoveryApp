using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Globals
{
    public class Game
    {
        private static int numberOfTeams = Globals.Global.NumberOfTeams;
        public static int round = Globals.Global.Round;
        private static int counter = Globals.Global.Counter;
        private static List<TeamModel> teams = Globals.Global.Teams;

        [Parameter]
        public Models.TeamRound TeamRound { get; set; }

        private void prevRound()
        {
            Globals.Global.CurrentRound--;
        }

        public static void CreateTeams()
        {
            Globals.Global.CurrentRound = 0;
            counter = 0;
            Globals.Global.Teams.Clear();
            for (int i = 1; i <= numberOfTeams; i++)
            {
                counter++;
                TeamModel team = new TeamModel(round)
                {
                    TeamName = "Team " + counter,
                    TeamNumber = counter,
                };
                teams.Add(team);
            }
            update();
        }

        public static void update()
        {
            if (round > Globals.Global.CurrentRound)
            {
                Globals.Global.CurrentRound++;

            }

            foreach (var team in teams)
            {
                for (int i = 0; i < team.TeamRounds.Count; i++)
                {
                    if (i > 0)
                    {
                        if (team.TeamRounds[i].Presentation < team.TeamRounds[i - 1].Presentation)
                        {
                            team.TeamRounds[i].Presentation = team.TeamRounds[i - 1].Presentation;
                        }
                        if (team.TeamRounds[i].Idea < team.TeamRounds[i - 1].Idea)
                        {
                            team.TeamRounds[i].Idea = team.TeamRounds[i - 1].Idea;
                        }
                        if (team.TeamRounds[i].Prototype < team.TeamRounds[i - 1].Prototype)
                        {
                            team.TeamRounds[i].Prototype = team.TeamRounds[i - 1].Prototype;
                        }
                        if (team.TeamRounds[i].Tym < team.TeamRounds[i - 1].Tym)
                        {
                            team.TeamRounds[i].Tym = team.TeamRounds[i - 1].Tym;
                        }
                    }
                    else
                    {
                        if (team.TeamRounds[i].Total == 0)
                        {
                            team.TeamRounds[i].Idea = 0; // or an initial value
                            team.TeamRounds[i].Presentation = 0; // or an initial value
                            team.TeamRounds[i].Prototype = 0; // or an initial value
                            team.TeamRounds[i].Tym = 0; // or an initial value
                        }
                    }
                }
            }
            
        }
    }
}
