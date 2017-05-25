<%@ Control Language="C#" AutoEventWireup="true" CodeFile="comment.ascx.cs" Inherits="contorl_comment" %>
<DIV class=content >
<UL class=recentComments>
 <asp:Repeater
      ID="Repeater1" runat="server">
      <ItemTemplate>
      <li>
       <A class=postTitle><%# StringHandling.String.cutstring( Eval("B_Title").ToString(),18) %></A> 
 <BR><A href='Article.aspx?id=<%#((Model.Comment)Container.DataItem).B_ID.L_ID %>#comment'><%#StringHandling.String.HtmlShowEncode(Eval("C_Author").ToString())%> &nbsp;写道:&nbsp;<%# StringHandling.String.cutstring( StringHandling.String.HtmlShowEncode( Eval("C_Content").ToString()),18) %></A> 
      </li>
      </ItemTemplate>
  </asp:Repeater>
   
</UL>
</DIV>