using System;
using System.Collections.Generic;
using System.Data;
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
        private SqlConnection _cn;


        public List<Team> GetAllTeams()
        {
            _cn = new SqlConnection(Settings.ConnectionString);

            return _cn.Query<Team>("GetAllTeams", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<Player> GetAllPlayersOnATeam(int teamID)
        {
            _cn = new SqlConnection(Settings.ConnectionString);

            var p = new DynamicParameters();
            p.Add("TeamID", teamID);

            return _cn.Query<Player>("GetAllPlayersOnATeam", p, commandType: CommandType.StoredProcedure).ToList();
        }

    }


}
