using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About : Page
{   
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(datetolongstring());
           }
    public string datetolongstring()
    {

        DateTime t;        
        t = DateTime.Now;
        return t.ToString();
       
    }
}