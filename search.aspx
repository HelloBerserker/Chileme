<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>主页</title>
	<link rel="stylesheet" href="css/wsdc.css"/>
	<link rel="stylesheet" href="css/font-awesome.min.css"/>    
	</head>
<body>


<ul class="navbar">
<div class="container">
	<li><a class="logo" href="#"><img src="images/logo2.png"/></a></li>
	<li><a href="main.aspx"><i class="icon-food">首页</i></a></li>
	<li><a href="myaccount.html">我的账户</a></li>
	<li><a href="#"><i class="icon-envelope-alt"></i>消息</a></li>
	<li> <form id="form1" runat="server"><asp:TextBox ID="TextBox1" runat="server" class="search" type="text" placeholder="搜索菜单" OnTextChanged="mysearch"></asp:TextBox><span class="icon-search searchbtn"></span></form></li>
	<li><a href="#" class="dropdown"><i class="icon-shopping-cart"></i>购物车			
				<div class="dropdown-text">
					购物车里空空如也
				</div></a></li>
				</div>	
</ul>
<div class="main">
    <div class="sort">
        <a class="active" href="javascript:void(0);">已找到以下结果</a>        
    </div>
    <br>
    <asp:DataList ID="productlist" runat="server" ShowFooter="False" ShowHeader="False" DataKeyField="mID" RepeatColumns="4" RepeatDirection="Horizontal">
                <ItemTemplate>
            <div class="list-card">           
            <a class="cbp-vm-image" href="#"><img title="<%# Eval("mName") %>，点击图片添加购物车" src="<%# Eval("mImage") %>"></a>
							<h3 id="name" class="cbp-vm-title"><%# Eval("mName") %></h3>
							<div class="cbp-vm-price"><%# Eval("mPrice") %>/份</div>
							<div class="cbp-vm-details">
								<%# Eval("mInfo") %>
							</div>
							<a class="cbp-vm-icon cbp-vm-add" href="cart.aspx?mId=<%# Eval("mId") %>"><i class="icon-plus">加入购物车</i></a>
            </div>
        </ItemTemplate>                   
    </asp:DataList>
</div>
        <script language="javascript" src="js/jquery.js"></script>
<script language="javascript">
    $(function () {
        $(".dropdown").hover(function () {
            $(".dropdown-text").html("<i class='icon-spinner icon-spin'></i>正在加载");
            $(".dropdown-text").load("Action.aspx?action=loadcart");
        });
    });
</script>    
</body>
</html>
