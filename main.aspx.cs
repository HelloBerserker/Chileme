using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        string query = "select * from menu";
        mysql sql = new mysql();
        this.productlist.DataSource = sql.loaddata(query);
        this.productlist.DataBind();       
    }
    protected void search(object sender, EventArgs e)
    {
        Response.Redirect("search.aspx?search=" + this.TextBox1.Text);
    }
}