using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {		
        string query = "select * from menu";
        mysql sql =new mysql();
        this.gv2.DataSource =sql.loaddata(query);		
        this.gv2.DataBind();
        Response.Write(sql.datenow());
    }    
    protected void TextBox1_TextChanged(object sender, EventArgs e)//少废话，放码过来，talk is cheap，show me the code
    {
        mysql sql = new mysql();
        string searchtxt = this.TextBox1.Text.Trim();
        this.gv2.DataSource =sql.find(searchtxt);
        this.gv2.DataBind(); 
    }
    protected void delete_Click(object sender, EventArgs e)
    {
        mysql sql = new mysql();
        string cmdtext = "delete from menu where mID=12";
        int a=sql.cmdstring(cmdtext);
        if (a == 0)
            Response.Write("请求失败");
    }
}