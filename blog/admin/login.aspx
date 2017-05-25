<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title><%=StringHandling.String.login%>--后台管理</title>
        <LINK href="Site.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
 
 <DIV id=header>
<H1 class=blogtitle><A><%=StringHandling.String.login%></A> </H1>
<P class=desc><%= StringHandling.String.miaoshu %></P></DIV>
<DIV id=ddnav>
<DIV id=nav></DIV></DIV>
<DIV id=top></DIV>
<DIV id=main>
<DIV id=content>
<DIV class=entry>
    <div>
        <table style="width: 510px">
        <tr>
            <td>
                username:</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                password:</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="login" />
            </td>
        </tr>
    </table>
    </div>
    
</DIV>

</DIV>


</DIV>
<DIV id=footer></DIV>
<DIV id=footerbox>
<DIV class=footer><A href="stulife.qyun.net/">bruce</A>  © Copyright 2009</DIV></DIV>
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
     

    </form>
</body>
</html>
