using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        //public int TradeAPlayerFromRepo(int id, int newTeamID)
        //{
            
        //    int newJerseyNumber = _bblrepo.JerseyNumbersOnATeam(id, newTeamID);
        //    List<Player> players = _bblrepo.GetAllPlayersOnATeam(newTeamID);
        //    Response response = new Response();
        //    foreach (var player in players)
        //    {
        //        if (newJerseyNumber == player.JerseyNumber)
        //        {
        //            response.Success = false;
        //            response.Message = "This jersey number is already assighned to a player!";
                    
        //        }
        //        else
        //        {
        //            response.Success = true;
        //            return newJerseyNumber;
        //        }
        //    }

        //    _bblrepo.TradeAPlayer(id, newTeamID, newJerseyNumber);

            
        //}

    }
}
