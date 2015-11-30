using System;
using System.Collections.Generic;
using System.Data;

using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseballLeague.Data;
using BaseballLeague.Data.Config;
using BaseballLeague.Models;
using NUnit.Framework;

namespace BaseballLeague.Tests
{
    [TestFixture]

   public  class BaseballLeagueTests
    {
        [Test]
        public void GetAllTeams_ShouldReturnCountOfTeams()
        {
            //Arrange
            int expected = 0;
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Count(*) From Teams";
                cmd.Connection = cn;
                //Act
                cn.Open();
                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }
            //Assert
            BaseballLeagueRepo bblRepo = new BaseballLeagueRepo();
            Assert.AreEqual(expected, bblRepo.GetAllTeams().Count);
        }

        [Test]
        public void AddNewTeam_ShouldReturnNextHigherTeamID()
        {
            //Arrange
            
            int expected = 0;
            int newTeamID = 0;
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Open();
                expected = RetrieveLastTeam(cn) + 1;

                BaseballLeagueRepo bblRepo = new BaseballLeagueRepo();
                bblRepo.CreateATeam("TestTeam", "JD Gurney", 1);
                newTeamID = RetrieveLastTeam(cn);
            }
   
            //Assert
            Assert.AreEqual(expected, newTeamID);
        }

        [Test]
        public void GetTeam_RetrieveLastTeam()
        {
            int id = 0;
            Team team = null;
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Open();

                id = RetrieveLastTeam(cn);

                BaseballLeagueRepo bblRepo = new BaseballLeagueRepo();
                team = bblRepo.RetrieveATeam(id);
            }

            Assert.NotNull(team);

        }

        [Test]
        public void GetPlayer_RetrieveLastPlayer()
        {
            int id = 0;
            Player player = null;
            using (SqlConnection cn = new SqlConnection(Settings.ConnectionString))
            {
                cn.Open();

                id = RetrieveLastPlayer(cn);

                BaseballLeagueRepo bblRepo = new BaseballLeagueRepo();
                player = bblRepo.RetrieveAPlayer(id);
            }

            Assert.NotNull(player);

        }



        private int RetrieveLastTeam(SqlConnection cn)
        {
            SqlCommand  cmd = new SqlCommand();
            cmd.CommandText = "Select Max(TeamID) From Teams";
            cmd.Connection = cn;

            int id = int.Parse(cmd.ExecuteScalar().ToString());
            return id;
        }

        private int RetrieveLastPlayer(SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select Max(PlayerID) From Players";
            cmd.Connection = cn;

            int id = int.Parse(cmd.ExecuteScalar().ToString());
            return id;
        }
    }
}
