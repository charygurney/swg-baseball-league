using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BaseballLeague.Tests
{
    [TestFixture]
    public class BaseballLeagueTests
    {
        public void GetTeams_CheckCount()
        {
            int expected = 0;
            using (SqlConnection cn = new SqlConnection())
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select count(*) from teams";
                cmd.Connection = cn;

                cn.Open();

                expected = int.Parse(cmd.ExecuteScalar().ToString());
            }

            Ba
        }
    }
}
