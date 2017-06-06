using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Action : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
            mysql ms = new mysql();
        int cuid=0;
        if (Session["uid"] != null)
            cuid = (int)Session["uid"];
        switch (Request.QueryString["action"]) {
            case "loadcart":
                {
                    StringBuilder s = new StringBuilder();
                    int sumprice=0;
                    int sumcount=0;
                    string sumstring;
                    string query = "select mName,mID,mImage,mPrice,cCount from cart left join menu on(mID = cFood) where cuid="+cuid;
                    SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sumcount = sumcount + Int32.Parse(dr["cCount"].ToString());
                        sumprice = sumprice + Int32.Parse(dr["mPrice"].ToString());
                        s.AppendFormat("<li><img src='{0}'><p>{1}</p>￥{2}</li>", dr["mImage"].ToString(), dr["mName"].ToString(), dr["mPrice"].ToString());
                    }//<li><img src='{0}'><p>{1}</p><i>{2}</i></li>
                    Response.Write("购物车的商品:");
                    Response.Write("<ul class='cart'>");
                    Response.Write(s);                   
                    Response.Write("</ul>");
                    sumstring = "购物车共" + sumcount + "件商品，共" + sumprice + "元";
                    Response.Write(sumstring);
                    if(Request.QueryString["check"]==null)
                    Response.Write("<a href='cart.aspx'><div class='button'>前往购物车</div></a>");
                    //else Response.Write("<div class='button' id='submit'>提交订单</div>");
                    dr.Close();
                };
                               break;
            case "loadorders": 
                { 
                    StringBuilder s = new StringBuilder();
                    StringBuilder cart = new StringBuilder();
                    int sumprice=0;
                    int sumcount=0;
                    string ono="hello";
                    string sumstring="";
                    string query = "SELECT ono,cid,cfood,mName,mImage,mPrice,cCount,cuid,omemo,oAddress,odate FROM orders left join menu on cFood=mid where cuid="+cuid+"order by oid desc";
                    SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        if (ono != dr["ono"].ToString())//
                        {
                            sumstring = "订单共" + sumcount + "件商品，共" + sumprice + "元";
                            s.Replace("*", sumstring);
                            sumprice = 0;
                            sumcount = 0;
                            s.Replace("#", cart.ToString());                            
                            cart.Clear();
                            ono=dr["ono"].ToString();
                            s.AppendFormat("<div class='orders-details'><div class='order-no'>{0}</div><div class='order-date'>{1}</div><div class='order-food'>*<ul class='cart'>#</ul></div><div class='order-address'><i title='{2}' class='icon-user'></i></div><div class='order-memo'>{3}</div></div>",dr["ono"].ToString(),dr["odate"].ToString(),dr["oaddress"].ToString(),dr["omemo"].ToString());
                            cart.AppendFormat("<li><img src='{0}'><p>{1}</p>￥{2}</li>", dr["mImage"].ToString(), dr["mName"].ToString(), dr["mPrice"].ToString());
                            sumcount = sumcount + Int32.Parse(dr["cCount"].ToString());
                            sumprice = sumprice + Int32.Parse(dr["mPrice"].ToString());
                        }
                        else if (ono == dr["ono"].ToString())
                        {
                            sumcount = sumcount + Int32.Parse(dr["cCount"].ToString());
                            sumprice = sumprice + Int32.Parse(dr["mPrice"].ToString());
                            cart.AppendFormat("<li><img src='{0}'><p>{1}</p>￥{2}</li>", dr["mImage"].ToString(), dr["mName"].ToString(), dr["mPrice"].ToString());
                        }                        
                    }
                    sumstring = "订单共" + sumcount + "件商品，共" + sumprice + "元";
                    s.Replace("#", cart.ToString());
                    s.Replace("*", sumstring);
                    Response.Write(s);
            }
                break;
            case "deletecart":
                {                    
                    string id = Request.QueryString["id"];
                    string query = "delete from cart where cid='"+id+"' and cuid="+cuid;
                    SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                    cmd.ExecuteNonQuery();
                    query = "select sum(mPrice) from cart left join menu on(mID = cFood) where cuid=" + cuid;
                    cmd.CommandText = query;
                    string price = cmd.ExecuteScalar().ToString();
                    query = "select sum(cCount) from cart left join menu on(mID = cFood) where cuid=" + cuid;
                    cmd.CommandText = query;
                    string count = cmd.ExecuteScalar().ToString();
                    Response.Write("共" + count + "件商品," + "总价为￥" + price);
                }
                break;
            case "sumprice":
                {
                    string query = "select sum(mPrice) from cart left join menu on(mID = cFood) where cuid=" + cuid;
                    SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                    string price = cmd.ExecuteScalar().ToString();
                    query = "select sum(cCount) from cart left join menu on(mID = cFood) where cuid=" + cuid;
                    cmd = new SqlCommand(query, ms.openconnection());
                    string count = cmd.ExecuteScalar().ToString();                   
                    Response.Write("共"+count+"件商品,"+"总价为￥"+price);
                }
                break;
            case "loadaddress":
                {
                    string address="";
                    string query = "select uid,uphone,address,uname from uaddress where uid=" + cuid + "order by aid desc";
                    SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        address = address + "<option>" + dr["address"] +" <br> "+dr["uname"] + dr["uphone"] + "</opiton>";
                    }
                    Response.Write(address);
                    dr.Close();
                }
                break;
            case "addaddress": 
                {
                    string address = Request.QueryString["address"];
                    string phone = Request.QueryString["phone"];
                    string name = Request.QueryString["name"];
                    string query = "insert into uAddress (uid,uphone,address,uName) values ("+cuid+",'"+phone+"','"+address+"','"+name+"')";
                    SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                    Response.Write(cmd.ExecuteNonQuery());
            }
            break;
            case "signup":
            {               
                string phone = Request.QueryString["phone"];
                string mail = Request.QueryString["mail"];
                string pwd = Request.QueryString["pwd"];
                string name = Request.QueryString["name"];
                string query = "insert into us(uname,uphone,umail,upassword) values ('" + name + "','" + phone + "','" + mail + "','" + pwd + "')";
                SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                Response.Write(cmd.ExecuteNonQuery());
            }
            break;
            case "login":
            {
                string phone = Request.QueryString["phone"];                
                string pwd = Request.QueryString["pwd"];               
                string query = "select uid from us where uphone='"+phone+"' and upassword='"+pwd+"'";
                SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                if (cmd.ExecuteScalar() != null)
                {
                    Session["uid"] = cmd.ExecuteScalar();
                    Response.Write("登陆成功");
                }
                else Response.Write("账号或密码错误");
            }
            break;
            case "deleteaddress":
            {
                string id = Request.QueryString["aid"];
                string query = "delete from uaddress where aid=" + id + " and uid=" + cuid;
                SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                Response.Write(cmd.ExecuteNonQuery());
            }
            break;
            case "editaddress":
            {
                StringBuilder sb = new StringBuilder();// string address="";               
                string query = "select uphone,aid,address,uname from uaddress where uid=" + cuid + "order by aid desc";
                SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sb.AppendFormat("<div id='{3}' class='address-col'><div class='remove' onclick='deleteaddress({3})'><i class='icon-trash'></i></div><div class='dizhi'>收货地址：<p>{0}</p></div><br><div class='contact'>收货人：<p>{1}</p></div><div class='phone'>联系电话：<p>{2}</p></div></div>", dr["address"], dr["uname"], dr["uphone"], dr["aid"]).ToString();
                }
                Response.Write(sb);
                dr.Close();
            }
            break;
            case "submit": {
                string address = Request.QueryString["address"];
                string memo= Request.QueryString["memo"];
                string oNo = ms.datetolongstring();
                string odate = ms.datenow();
                string query = "insert into orders(cFood,cCount,cUid) select cFood,cCount,cUid from cart";
                SqlCommand cmd = new SqlCommand(query, ms.openconnection());
                cmd.ExecuteNonQuery();
                query = "update orders set oNo='" + oNo + "',oDate='" + odate + "',omemo='" + memo + "',oaddress='" + address + "' where oNo is null";
                cmd.CommandText = query;
                Response.Write(cmd.ExecuteNonQuery());
                query = "delete from cart";               
                cmd.CommandText = query;
                Response.Write(cmd.ExecuteNonQuery());
            }
            break;
        }        
    }
}