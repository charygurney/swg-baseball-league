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

        public BaseballLeagueRepo()
        {
            _cn = new SqlConnection(Settings.ConnectionString);
        }

        public List<Team> GetAllTeams()
        {
            return _cn.Query<Team>("GetAllTeams", commandType: CommandType.StoredProcedure).ToList();
        }

        public List<Player> GetAllPlayersOnATeam(int teamID)
        {
            var p = new DynamicParameters();
            p.Add("TeamID", teamID);

            return _cn.Query<Player>("GetAllPlayersOnATeam", p, commandType: CommandType.StoredProcedure).ToList();
        }

        // Create a team

        public int Team(string teamName, string managerName, int leagueId)
        {
            var p = new DynamicParameters();
            p.Add("TeamName", teamName);
            p.Add("ManagerName", managerName);
            p.Add("LeagueID", leagueId);
            p.Add("TeamID", dbType: DbType.Int32, direction: ParameterDirection.Output);

            _cn.Execute("CreateTeam", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("TeamID");
        }

        // Create a player

        // Retrieve a team

        // Retrieve a player

        // Update a team

        // Update a player

        // Delete a team

        // Delete a player

        public void DeleteAPlayer(int id)
        {
            var p = new DynamicParameters();
            p.Add("PlayerID", id);

            _cn.Execute("DeletePlayer", p, commandType: CommandType.StoredProcedure);
        }

        // Trade a player (delete old team ID, create new team ID in its place)

    }


}
