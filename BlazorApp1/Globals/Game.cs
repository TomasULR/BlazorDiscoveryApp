﻿using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Globals
{
    public class Game
    {
        private static int numberOfTeams = Global.NumberOfTeams;
        public static int round = Global.Round;
        private static int counter = Global.Counter;
        private static List<TeamModel> teams = Global.Teams;

        [Parameter]
        public Models.TeamRound TeamRound { get; set; }

        public static void PrevRound()
        {
            if (Global.CurrentRound > 1)
            {
                Global.CurrentRound--;

            }


        }

        public static void CreateTeams()
        {
            Global.CurrentRound = 0;
            counter = 0;
            Global.Teams.Clear();
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
            Update();
        }

        public static void Update()
        {
            if (round > Global.CurrentRound)
            {
                Global.CurrentRound++;

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
