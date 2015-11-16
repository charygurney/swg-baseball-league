﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int YearsPlayed { get; set; }
        public decimal? BattingAvg { get; set; }
        public decimal? EarnedRunAvg { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }

        public Player(string firstName, string lastName, int jerseyNumber, int yearsPlayed, decimal battingAvg, decimal earnedRunAvg, string position, string teamName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.JerseyNumber = jerseyNumber;
            this.YearsPlayed = yearsPlayed;
            this.BattingAvg = battingAvg;
            this.EarnedRunAvg = earnedRunAvg;
            this.Position = position;
            this.TeamName = teamName;
        }
    }
}