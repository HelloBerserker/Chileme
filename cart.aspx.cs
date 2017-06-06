using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        mysql sql = new mysql();
        string mID = Request.QueryString["mid"];
        string cID = sql.datetolongstring();
        if (Session["uid"] == null)
        {
            Response.Redirect("login.html");
        }
        int cUid = (int)Session["uid"];
        string cmdtext = "insert into cart(cID,cFood,cUid,ccount) values(" + cID + "," + mID + "," + cUid + ", 1)";
        int a = sql.cmdstring(cmdtext);
        string query = "select cID,mName,mID,mImage,mPrice,cCount from cart left join menu on(mID = cFood) where cuid="+cUid;
        this.cartlist.DataSource = sql.loaddata(query);
        this.cartlist.DataBind();
    }
    protected void search(object sender, EventArgs e)
    {
        Response.Redirect("search.aspx?search=" + this.TextBox1.Text);
    }
}