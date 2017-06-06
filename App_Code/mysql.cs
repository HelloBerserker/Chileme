using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// 这就是项目的模型层吧
/// </summary>
public class mysql
{
   public SqlConnection openconnection(){
        string conectionstring = "Persist Security Info=False;Integrated Security=true;Initial Catalog=WSDC;server=(local)";
        SqlConnection conn = new SqlConnection(conectionstring);
       if(conn.State!=ConnectionState.Open)
        conn.Open();
        return conn;
    }
       public DataTable loaddata(string query)
    {
        SqlDataAdapter ada = new SqlDataAdapter(query, openconnection());
        DataTable dt = new DataTable();
        ada.Fill(dt);
        return dt;
                   }
    public DataTable find(string result)
    {
        SqlDataAdapter ada = new SqlDataAdapter("select * from menu where mName like '%" + result + "%' or mPrice like '%" + result + "%'", openconnection());
        DataTable dt = new DataTable();
        ada.Fill(dt);
        return dt;
    }
    public string datetolongstring()
    {

        DateTime t;
        t = DateTime.Now;
        return (t.Millisecond + t.Minute * 1000 + t.Hour * 100000 + t.Day * 10000000 + t.Month * 1000000000 + t.Year * 100000000000).ToString();
    }
    public string datenow() {
        DateTime t;
        t = DateTime.Now;
        return t.Year + "-" + t.Month + "-" + t.Day + " " + t.Hour + ":" + t.Minute + ":" + t.Second;
    }
    public int cmdstring(string cmd) {
        try
        {
            SqlConnection conn = openconnection();
            SqlCommand sqlcmd = new SqlCommand();
            if (conn != null)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                sqlcmd.CommandText = cmd;
                sqlcmd.Connection = conn;
                return sqlcmd.ExecuteNonQuery();
            }
            else
            {
                return 0;
            }
        }
        catch (Exception)
        {
            return 0;
        }       
    }

} 