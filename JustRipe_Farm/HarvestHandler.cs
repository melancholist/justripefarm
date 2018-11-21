using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace JustRipe_Farm
{
    public class HarvestHandler
    {
        public int addNewHarvest(MySqlConnection conn, Harvest harvest)
        {
            string sql = "INSERT INTO harvest (crops_type, harvest_time, harvest_method) "
                + " VALUES ('" + harvest.CropsType + "', '" + harvest.HarvestTime.ToString("yyyy-MM-dd HH:mm:ss")
                + "', '" + harvest.HarvestMethod + "' )";

            MySqlCommand sqlComm = new MySqlCommand(sql, conn);
            return sqlComm.ExecuteNonQuery();
        }
    }
}
