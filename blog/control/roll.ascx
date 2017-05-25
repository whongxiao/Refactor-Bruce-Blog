<%@ Control Language="C#" AutoEventWireup="true" CodeFile="roll.ascx.cs" Inherits="contorl_roll" %>

<DIV class=content>
<DIV id=blogroll>
<asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>
      <UL class=xoxo>
  <LI><A 
  href='<%#Eval("L_Url") %>'target=_blank><%#Eval("L_Name") %></A>
      
</LI>
 </UL>
      
      </ItemTemplate>
      </asp:Repeater></DIV></DIV>