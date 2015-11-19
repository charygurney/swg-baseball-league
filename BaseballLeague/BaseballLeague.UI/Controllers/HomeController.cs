using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.BLL;
using BaseballLeague.Models;
using BaseballLeague.UI.Models;

namespace BaseballLeague.UI.Controllers
{
    public class HomeController : Controller
    {
        private League _league;
        private Team _team;
        private BaseballLeagueOps _ops;

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllTeams()
        {
            _league = new League();
            _ops = new BaseballLeagueOps();

            _league.Teams = _ops.GetTeamsFromRepo();

            return View(_league);
        }

        public ActionResult ViewTeam(int id)
        {
            _team = new Team();
            _ops = new BaseballLeagueOps();


            _ops.GetTeamsFromRepo();
            _team.Players = _ops.GetPlayersOnTeamFromRepo(id);
            _team.TeamName = _ops.RetrieveATeamFromRepo(id).TeamName;

            return View(_team);
        }

        public ActionResult DeleteAPlayer(int id)
        {
            _ops = new BaseballLeagueOps();

            _ops.DeleteAPlayerFromRepo(id);

            return RedirectToAction("GetAllTeams");
        }

        public ActionResult TradeAPlayer(int id, int teamID)
        {
            _ops = new BaseballLeagueOps();
            PlayerToTradeVM playerToTradeVM = new PlayerToTradeVM();
            playerToTradeVM.player = _ops.RetrieveAPlayerFromRepo(id);
            playerToTradeVM.team = _ops.RetrieveATeamFromRepo(teamID);
            playerToTradeVM.CreateTeamsList(_ops.GetTeamsFromRepo());

            return View(playerToTradeVM);
        }

        [HttpPost]
        public ActionResult TradeAPlayerPost(PlayerToTradeVM playerToTradeVM)
        {
            _ops = new BaseballLeagueOps();

            _ops.TradeAPlayerFromRepo(playerToTradeVM.player.PlayerID, playerToTradeVM.team.TeamID);

            return RedirectToAction("GetAllTeams");
        }

        public ActionResult CreateATeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateATeamPost(Team team)
        {
            _ops = new BaseballLeagueOps();

            _ops.CreateATeamFromRepo(team.TeamName, team.ManagerName);

            return RedirectToAction("GetAllTeams");
        }
    }
}