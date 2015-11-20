using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BaseballLeague.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        [Required(ErrorMessage = "You must enter a team name")]
        public string TeamName { get; set; }
        [Required(ErrorMessage = "You must enter a team manager.")]
        public string ManagerName { get; set; }
        public List<Player> Players { get; set; }

        public Team()
        {
            Players = new List<Player>();
        }

        //public Team(int teamID, string teamName, string managerName, List<Player> players)
        //{
        //    this.TeamID = teamID;
        //    this.TeamName = teamName;
        //    this.ManagerName = managerName;
        //    this.Players = players;
        //}
    }
}
