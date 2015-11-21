using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseballLeague.Data;
using BaseballLeague.Data.Config;
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
    }
}
