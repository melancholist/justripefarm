using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JustRipe_Farm
{
    public class LabourerHandler
    {
        public int addNewLabourer(MySqlConnection conn, Labourer labourer)
        {
            string sql = "INSERT INTO labourer (name, age, gender) "
                + "VALUES ('" + labourer.Name + "', " + labourer.Age
                + "  , '" + labourer.Gender + "')";
            MySqlCommand sqlComm = new MySqlCommand(sql, conn);

            return sqlComm.ExecuteNonQuery();
        }
    }
}
