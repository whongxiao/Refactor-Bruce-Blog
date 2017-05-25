<%@ Control Language="C#" AutoEventWireup="true" CodeFile="archive.ascx.cs" Inherits="contorl_archive" %>
<DIV class=content>
  
   <asp:Repeater ID="Repeater1" runat="server">
   <ItemTemplate>
   
  <UL class=open>
    <LI><A href=""><%# Convert.ToDateTime( Eval("L_PostTime")).Year %> 年<%# Convert.ToDateTime( Eval("L_PostTime")).Month%>月(0)</A>
    </LI></UL>
 </ItemTemplate> </asp:Repeater></DIV> 