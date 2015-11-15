using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseballLeague.Models
{
   public class League
    {
        public string LeagueName { get; set; }
       public List<Team> Teams { get; set; }

       public League(string leagueName, List<Team> team)
       {
           this.LeagueName = leagueName;
           this.Teams = team;
       }
    }
}
