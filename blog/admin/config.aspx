<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="config.aspx.cs" Inherits="admin_config" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 600px">   
                   <tr>
                       <td style="width: 52px">
                           Logo:</td>
                <td style="width: 283px" >
                    <asp:TextBox ID="TextBox1" runat="server" Width="181px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 52px; height: 50px">
                    签名：</td>
                <td style="width: 283px; height: 50px;" >
                    <asp:TextBox ID="TextBox2" runat="server" Height="46px" TextMode="MultiLine" Width="319px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 52px; height: 57px">
                    关键字：</td>
                <td style="width: 283px; height: 57px;" >
                    <asp:TextBox ID="TextBox3" runat="server" Height="51px" TextMode="MultiLine" Width="322px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 52px">
                </td>
                <td style="width: 283px" >
                    </td>
            </tr>
            <tr>
                <td align="center" colspan="1" style="width: 52px">
                </td>
                <td align="center" colspan="1" >
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" CausesValidation="False" /></td>
            </tr>
        </table>
</asp:Content>

