<%@ Control Language="C#" AutoEventWireup="true" CodeFile="category.ascx.cs" Inherits="contorl_category" %>
<DIV class=content>
<UL id=categorylist>
    <asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
  <LI><A 
  title="<%# Eval("C_Name")%> " href='Category.aspx?cid=<%# Eval("C_ID")%>'><%# Eval("C_Name")%> 
  (<%# GetSortCount(Eval("C_ID").ToString())%>)</A>
  </LI>
  </ItemTemplate>
    </asp:Repeater>
  </UL></DIV>
  

  

