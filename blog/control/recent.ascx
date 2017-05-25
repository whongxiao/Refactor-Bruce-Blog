<%@ Control Language="C#" AutoEventWireup="true" CodeFile="recent.ascx.cs" Inherits="contorl_recent" %>
<DIV class=content><UL class=recentPosts id=recentPosts> 
<asp:Repeater ID="Repeater1" runat="server">
<ItemTemplate>

 <LI><A  href='Article.aspx?id=<%#Eval("L_ID") %>'><%# StringHandling.String.cutstring( Eval("L_Title").ToString(),18) %></A> </LI> 


</ItemTemplate>
     </asp:Repeater>  </UL></DIV>