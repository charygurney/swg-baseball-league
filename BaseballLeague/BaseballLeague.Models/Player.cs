using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Player
    {
        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }
        public int YearsPlayed { get; set; }
        public decimal? BattingAverage { get; set; }
        public decimal? EarnedRunAvg { get; set; }
        public string PositionName { get; set; }
        public string TeamName { get; set; }

        public Player(int playerID, string firstName, string lastName, int jerseyNumber, int yearsPlayed, decimal battingAverage, decimal earnedRunAvg, string positionName, string teamName)
        {
            this.PlayerID = playerID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.JerseyNumber = jerseyNumber;
            this.YearsPlayed = yearsPlayed;
            this.BattingAverage = battingAverage;
            this.EarnedRunAvg = earnedRunAvg;
            this.PositionName = positionName;
            this.TeamName = teamName;
        }
    }
}
