<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="adminmember.aspx.cs" Inherits="admin_adminmember" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="添加会员" />
        <asp:Panel ID="Panel1" runat="server">
    <asp:Repeater id="Repeater1" runat="server">
    <HeaderTemplate> <table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;">   
            <tr><td width=240>member</td><td width=140>Email</td><td width=80>time </td><td width=40>staus </td>
                   <td  width=40></td>
                   <td width=40> </td>
            </tr>
        </table>          
    </HeaderTemplate>
           <ItemTemplate><table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;" >
     
            <tr ><td width=240> <%# Eval("M_Name")%>  </td>
                 <td  width=140> <%# Eval("M_Email")%>  </td>
                <td  width=80>  <%#Convert.ToDateTime( Eval("M_RegTime")).ToShortDateString()%> </td>
                <td  width=40>  <%#Eval("M_staus")%> </td>
               <td  width=40>  <asp:Button ID="update" runat="server" CommandName='<%# Eval("M_ID")%>' OnCommand="update_Click"  Text="修改" /></td>
               <td  width=40>  <asp:Button ID="delete" runat="server" CommandName='<%# Eval("M_ID")%>' OnCommand="delete_Click" Text="删除" /></td>
            </tr></table>  
          
                        </ItemTemplate>
                        </asp:Repeater>

       <asp:Literal ID="pageset"  runat="server" Mode="PassThrough"></asp:Literal>
          </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible=false>
        <table style="width: 600px">   
                   <tr>
                       <td style="width: 3px">
                    member:</td>
                <td >
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                       <td style="width: 93px">
                    password：</td>
                <td style="width: 388px" >
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label>不修改留空！</td>
            </tr>
            <tr>
                <td style="width: 3px">
                    sex：</td>
                <td >
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                        Width="48px">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 93px">
                    email：</td>
                <td style="width: 388px" >
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="格式不对！" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 3px; height: 42px;">
                    QQ：</td>
                <td style="height: 42px" >
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox4"
                        ErrorMessage="QQ不对！" ValidationExpression="[0-9]{5,9}"></asp:RegularExpressionValidator></td>
                <td style="width: 93px; height: 42px;">
                    homepage：</td>
                <td style="width: 388px; height: 42px;" >
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5"
                        ErrorMessage="格式不对！" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 3px">
                    staus：</td>
                <td >
                    <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                <td style="width: 93px">
                </td>
                <td style="width: 388px" >
                    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="1" style="width: 3px">
                </td>
                <td colspan="3" >
                    intro：</td>
            </tr>
            <tr>
                <td colspan="1" style="width: 3px; height: 72px">
                </td>
                <td colspan="3" style="height: 72px" >
                    <asp:TextBox ID="TextBox6" runat="server" Height="75px" TextMode="MultiLine" Width="279px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="1" style="width: 3px">
                </td>
                <td align="center" colspan="3" >
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" /></td>
            </tr>
        </table>
        </asp:Panel>
</asp:Content>

