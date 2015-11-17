using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public string ManagerName { get; set; }
        public List<Player> Players { get; set; }

        //public Team(int teamID, string teamName, string managerName, List<Player> players)
        //{
        //    this.TeamID = teamID;
        //    this.TeamName = teamName;
        //    this.ManagerName = managerName;
        //    this.Players = players;
        //}
    }
}
