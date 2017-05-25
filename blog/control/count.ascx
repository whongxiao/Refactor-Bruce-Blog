<%@ Control Language="C#" AutoEventWireup="true" CodeFile="count.ascx.cs" Inherits="contorl_count" %>
<DIV class=content><UL>
<li><A>日志: <%=blog %>篇 </A></li>
<li><A>评论<%=comment %>:个 </A> </li>
<li><A>在线 <%=Application["zzzonline"]%>人</A></li>
<li><A>站长:bruce</A></li>
<li><A>建站时间2009-03-04</A></li>

 <li ><a> 您是第<asp:Label ID="Label1" runat="server" Text="Label"><%=Application["count"] %></asp:Label>位访问者<br />
        您是今天第<asp:Label ID="Label2" runat="server" Text="Label"><%=Application["day_count"] %></asp:Label>位访问者<br />
        现在时间<asp:Label ID="Label3" runat="server" Text="Label"><%=DateTime.Now %></asp:Label><br />
        <br />
        您是第<asp:PlaceHolder ID="ph1" runat="server"></asp:PlaceHolder>
        位访问者<br />
        您是今天第<asp:PlaceHolder ID="ph2" runat="server"></asp:PlaceHolder>
        位访问者</a></li>
        
</UL>



</DIV>