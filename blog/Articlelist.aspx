<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Articlelist.aspx.cs" Inherits="Articlelist" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphBody" Runat="Server">
    <asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
    
    
<DIV class=posts id=ctl00_cphBody_PostList1_posts>
<DIV class="post xfolkentry" id=post0>
<H1><A class=taggedlink  href='Article.aspx?id=<%#Eval("L_ID") %>'><%# StringHandling.String.cutstring( Eval("L_Title").ToString(),30)%> </A></H1><SPAN 
class=author>by <A 
><%# Eval("L_Author")%> </A></SPAN> <SPAN 
class=pubDate><%# Eval("L_PostTime")%> </SPAN> 
<DIV class=text><%# StringHandling.String.cutstring( Eval("L_Content").ToString(),200)%> 
<DIV style="CLEAR: both"></DIV></DIV>
<DIV class=bottom>
Tags: <%# tag( Eval("L_tag").ToString())%> 

</DIV>
<DIV class=footer>
    分类：<A href='Category.aspx?cid=<%#Eval("L_CID") %>'rel=bookmark><%# Eval("L_CTitle") %></A> | <A 
href='Article.aspx?id=<%#Eval("L_ID") %>#comment' rel=nofollow>评论 (<%# GetSortCount(Eval("L_ID").ToString())%>)</A> | <A >点击：（<%#Eval("L_ViewNums")%>）
</DIV></DIV>
</DIV>
    
    
    
    </ItemTemplate>
    </asp:Repeater>
   <DIV id=postPaging>
<DIV class=pagination id=pagebar> <asp:Literal ID="pageset" runat="server"></asp:Literal>
    
</DIV></div>
</asp:Content>

