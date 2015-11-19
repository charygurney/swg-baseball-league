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

        public Team RetrieveATeamFromRepo(int teamID)
        {
            return _bblrepo.RetrieveATeam(teamID);
        }

        public Player RetrieveAPlayerFromRepo(int playerID)
        {
            return _bblrepo.RetrieveAPlayer(playerID);
        }

        public void DeleteAPlayerFromRepo(int id)
        {
            _bblrepo.DeleteAPlayer(id);
        }

        public void TradeAPlayerFromRepo(int id, int newTeamID)
        {
            
            int newJerseyNumber = _bblrepo.JerseyNumbersOnATeam(id, newTeamID);

            _bblrepo.TradeAPlayer(id, newTeamID, newJerseyNumber);
        }

    }
}
