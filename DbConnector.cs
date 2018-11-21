using System;
using MySql.Data.MySqlClient;

public class Class1
{
    MySqlConnection conn;

    public string connect()
    {
        string conStr = "server=localhost;user=dbcli;database=demojustripedb;port=3306;password=dbcli123";
        conn - new MySqlConnection(connStr);
        try
        {
            conn.Open();
            //Perform database operation
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }

        return "Done";
    }

    public MySqlConnection getConn()
    {
        return conn;
    }
}
