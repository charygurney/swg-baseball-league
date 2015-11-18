using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaseballLeague.BLL;
using BaseballLeague.Models;

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
            _team.TeamName = _team.Players[0].TeamName;

            return View(_team);
        }

        public ActionResult DeleteAPlayer(int id)
        {
            _ops = new BaseballLeagueOps();

            _ops.DeleteAPlayerFromRepo(id);

            return RedirectToAction("GetAllTeams");
        }
    }
}