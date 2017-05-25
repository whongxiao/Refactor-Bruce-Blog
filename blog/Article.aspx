<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Article.aspx.cs" Inherits="Article" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
<DIV class=posts id=ctl00_cphBody_PostList1_posts>
<DIV class="post xfolkentry" id=post0>
<H1><A class=taggedlink >        <asp:Literal ID="Literal1" runat="server"></asp:Literal></A></H1><SPAN 
class=author>by <A>        <asp:Literal ID="Literal2" runat="server"></asp:Literal></A></SPAN> <SPAN 
class=pubDate>        <asp:Literal ID="Literal3" runat="server"></asp:Literal></SPAN> 
<DIV class=text>        <asp:Literal ID="Literal4" runat="server"></asp:Literal>
<DIV style="CLEAR: both"></DIV></DIV>
<DIV class=bottom>
<P class=tags>Tags:      <asp:Literal ID="Literal5" runat="server"></asp:Literal></P>
</DIV>
<DIV class=footer>
    分类：<A href='Category.aspx?cid=<%=cid%>'rel=bookmark> <asp:Literal ID="Literal6" runat="server"></asp:Literal></A> |
     <A rel=nofollow href='Article.aspx?id=<%=id%>#comment'>评论 (<% GetSortCount(id);%>)</A> |
 <a> <asp:Literal ID="Literal7" runat="server"></asp:Literal></a> 
</DIV></DIV>
</DIV>
<a name=comment></a>
   <div class=comment>
       <asp:Repeater ID="Repeater1" runat="server">
       <ItemTemplate>
       <div class=author><img src="images/icon_quote.gif"/><A><%#Eval("C_Author") %>发表于：<%#Eval("C_PostTime") %></A>IP:<%# Eval("C_PostIP") %> </div>

       <div class=content ><%#StringHandling.String.HtmlShowEncode(Eval("C_Content").ToString()) %></div></ItemTemplate>
       </asp:Repeater>
      <div id=commentMenu>发表评论
         
         
      <div> <asp:Label ID="Label1" runat="server"  CssClass=label Text="Label">用户：</asp:Label><asp:TextBox ID="TextBox1"  CssClass=input runat="server"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
              ErrorMessage="**"></asp:RequiredFieldValidator></div>
     <!-- <div><asp:Label ID="Label2" runat="server" CssClass=label Text="Label">密码：</asp:Label><asp:TextBox ID="TextBox2" CssClass=input runat="server" TextMode="Password"></asp:TextBox></div>-->
     <div>   <asp:Label ID="Label3" runat="server" CssClass=label  Text="Label">内容：</asp:Label><asp:TextBox ID="TextBox3" CssClass=input runat="server" TextMode="MultiLine" Height="73px"></asp:TextBox>   
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox3"
             ErrorMessage="**"></asp:RequiredFieldValidator></div>
     <div>   <asp:Button ID="Button1" CssClass=addcomment runat="server" Text="评论" OnClick="Button1_Click" />&nbsp;
     </div>
   </div> 
    </div>
</asp:Content>

