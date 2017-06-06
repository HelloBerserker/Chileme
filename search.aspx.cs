using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string searchtxt =Request.QueryString["search"];
        mysql sql = new mysql();
        this.productlist.DataSource = sql.find(searchtxt);
        this.productlist.DataBind();  
    }
    protected void mysearch(object sender, EventArgs e)
    {
        Response.Redirect("search.aspx?search=" + this.TextBox1.Text);
    }
}