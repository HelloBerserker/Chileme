<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>我的购物车</title>
	<link rel="stylesheet" href="css/wsdc.css"/>
	<link rel="stylesheet" href="css/font-awesome.min.css"/>
    <script src="js/jquery.js" language="javascript"></script>
	</head>
<body>


<ul class="navbar">
<div class="container">
	<li><a class="logo" href="main.aspx"><img title="返回首页" src="images/logo2.png"/></a></li>
	<li><a href="main.aspx"><i class="icon-food"></i>首页</a></li>
	<li><a href="myaccount.html">我的账户</a></li>
	<li><a href="#"><i class="icon-envelope-alt"></i>消息</a></li>
	<li> <form id="form1" runat="server"><asp:TextBox ID="TextBox1" runat="server" class="search" type="text" placeholder="搜索菜单" OnTextChanged="search"></asp:TextBox><span class="icon-search searchbtn"></span></form></li>
	<li><a href="cart.aspx" class="dropdown"><i class="icon-shopping-cart"></i>购物车			
				<div class="dropdown-text">
                    				
				</div></a></li>
				</div>	
</ul>
<div class="main">
			
<div class="success"><span class="icon-ok-circle"></span> 商品已成功加入购物车! <span class="sumprice icon-truck"></span><a class="bt-check" href="main.aspx"><i class="icon-reply"></i>返回继续购物</a>
		<a class="bt-check" href="确认订单.html">去结算 <i class="icon-chevron-right"> </i></a></div>
 <div class="pull-up">              
     <div style="margin:10px auto;width:800px;"><asp:DataList ID="cartlist" runat="server">
                     <ItemTemplate>	
	<div class="cart-col" id="<%# Eval("cID") %>">
		<img src="<%# Eval("mImage") %>"/><h2><%# Eval("mName") %></h2>
		<div class="tag"><i class="icon-tasks"></i> 数量: 1 </div><div class="tag"><i class="icon-tag"></i>价格:<%# Eval("mPrice") %></div>
		<ul class="edit-group"><li onclick="deletecart(<%# Eval("cID") %>)"><i class="icon-remove"></i>删除</li><li><i class="icon-heart-empty">移入收藏</i></li></ul>
	</div>
                          </ItemTemplate>
                    </asp:DataList>
                    </div>
</div>   
    </div> 

<script language="javascript" src="js/jquery.js"></script>
<script language="javascript">
    function deletecart(id) {
        $(function () {           
            $(".sumprice").load("Action.aspx?action=deletecart&id=" + id);
            id = "#" + id;
            $(id).fadeOut(1000);
                               })
    }
    $(function () {        
        $(".sumprice").load("Action.aspx?action=sumprice");
            $(".dropdown").hover(function () {
            $(".dropdown-text").html("<i class='icon-spinner icon-spin'></i>正在加载");
            $(".dropdown-text").load("Action.aspx?action=loadcart");
        });
    } 
    );

</script>
</body>
</html>
