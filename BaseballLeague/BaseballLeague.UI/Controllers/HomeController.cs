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
    }
}