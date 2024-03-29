﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.Models;

namespace BaseballLeague.UI.Models
{
    public class PlayerToTradeVM
    {
        public Player player { get; set; }
        public Team team { get; set; }
        public List<SelectListItem> teams { get; set; }

        public void CreateTeamsList(List<Team> teamsList)
        {
            List<Team> listOfTeams = new List<Team>();
            listOfTeams = teamsList;

            teams = new List<SelectListItem>();

            foreach (Team team in listOfTeams)
            {
                SelectListItem newItem = new SelectListItem();

                newItem.Text = team.TeamName;
                newItem.Value = team.TeamID.ToString();

                teams.Add(newItem);
            }
        } 
    }
}