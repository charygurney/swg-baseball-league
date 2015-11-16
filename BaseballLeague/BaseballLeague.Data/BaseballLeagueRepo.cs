using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Data.Config;
using BaseballLeague.Models;
using Dapper;

namespace BaseballLeague.Data
{
    public class BaseballLeagueRepo
    {
        private SqlConnection _cn = new SqlConnection(Settings.ConnectionString);


        public List<Team> GetAllTeams()
        {
            return _cn.Query<Team>("Select * From Teams").ToList();
        }

        public List<Player> GetAllPlayersOnATeam(int id)
        {
            var p = new DynamicParameters();
            p.Add("TeamID", id);

            return _cn.Query<Player>("Select * From Teams t on Players p inner join t.TeamID = p.TeamID where t.TeamID = @TeamID", p).ToList();
        }

    }


}
