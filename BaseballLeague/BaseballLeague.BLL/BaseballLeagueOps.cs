using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Data;
using BaseballLeague.Models;

namespace BaseballLeague.BLL
{
    public class BaseballLeagueOps
    {
        private BaseballLeagueRepo _bblrepo;

        public BaseballLeagueOps()
        {
            _bblrepo = new BaseballLeagueRepo();
        }

        public List<Team> GetTeamsFromRepo()
        {
            return _bblrepo.GetAllTeams();
        }

        public List<Player> GetPlayersOnTeamFromRepo(int teamID)
        {
            return _bblrepo.GetAllPlayersOnATeam(teamID);
        }

        public void DeleteAPlayerFromRepo(int id)
        {
            _bblrepo.DeleteAPlayer(id);
        }

    }
}
