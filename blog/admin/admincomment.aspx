<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admincomment.aspx.cs" Inherits="admin_admincomment" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<asp:Panel ID="Panel1" runat="server">
    <asp:Repeater id="Repeater1" runat="server">
    <HeaderTemplate> <table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;">   
            <tr><td width=340>文章标题</td><td width=70>用户</td><td width=80>时间</td>
                   <td  width=40></td>
                   <td width=40> </td>
            </tr>
        </table>          
    </HeaderTemplate>
           <ItemTemplate><table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;" >
     
            <tr ><td width=340> <%# Eval("B_Title")%>  </td>
                 <td  width=70>  <%# Eval("C_Author")%>  </td>
                 <td  width=80> <%# Convert.ToDateTime( Eval("C_PostTime")).ToShortDateString()%>  </td>
                
               <td  width=40>  <asp:Button ID="update" runat="server" CommandName='<%# Eval("C_ID")%>' OnCommand="update_Click"  Text="查看" /></td>
               <td  width=40>  <asp:Button ID="delete" runat="server" CommandName='<%# Eval("C_ID")%>' OnCommand="delete_Click" Text="删除" /></td>
            </tr></table>  
          
                        </ItemTemplate>
                        </asp:Repeater>

      
          <asp:Literal ID="pageset"  runat="server" Mode="PassThrough"></asp:Literal></asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible=false>
        <table style="width: 600px">   
                   <tr>
                <td >
                    标题：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td style="width: 388px" >
                    用户：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    时间：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td style="width: 388px" >
                    IP：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" >
                    评论内容：</td>
            </tr>
            <tr>
                <td colspan="2" >
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click" />
                    </td>
            </tr>
        </table>
        </asp:Panel>
</asp:Content>

