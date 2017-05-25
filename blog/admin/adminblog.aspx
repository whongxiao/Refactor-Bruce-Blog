<%@ Page Language="C#"  ValidateRequest="false" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="adminblog.aspx.cs" Inherits="admin_adminlogin" Title="Untitled Page" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="添加文章" />

        <asp:Panel ID="Panel1" runat="server">    类别：<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>
    <asp:Repeater id="Repeater1" runat="server">
    <HeaderTemplate> <table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;">   
            <tr><td width=380>标题</td><td width=80>时间</td><td width=40>击量 </td>
                   <td  width=40></td>
                   <td width=40> </td>
            </tr>
        </table>          
    </HeaderTemplate>
           <ItemTemplate><table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;" >
     
            <tr ><td width="380">[<%# Eval("L_CTitle")%> ] <%# Eval("L_Title")%>  </td>
                 <td  width="80"> <%# Convert.ToDateTime( Eval("L_PostTime")).ToShortDateString()%>  </td>
                <td  width="40">  <%# Eval("L_ViewNums")%>  </td>
               <td  width="40">  <asp:Button ID="update" runat="server" CommandName='<%# Eval("L_ID")%>' OnCommand="update_Click"  Text="修改" /></td>
               <td  width="40">  <asp:Button ID="delete" runat="server" CommandName='<%# Eval("L_ID")%>' OnCommand="delete_Click" Text="删除" /></td>
            </tr></table>  
          
                        </ItemTemplate>
                        </asp:Repeater>

      
          <asp:Literal ID="pageset"  runat="server" Mode="PassThrough"></asp:Literal></asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
        <table style="width: 600px">   
                   <tr>
                <td style="width: 283px" >
                    类别:<asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList></td>
                <td style="width: 388px" >
                    标题：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="标题不能为空！"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 283px" >
                    作者：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td style="width: 388px" >
                    来自：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 283px" >
                    排序：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox4"
                        ErrorMessage="必须为数字！" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                </td>
                <td style="width: 388px" >
                    标签：<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 283px" >
                    是否显示：<asp:CheckBox ID="CheckBox1" runat="server" /></td>
                <td style="width: 388px" >
                    是否置顶：<asp:CheckBox ID="CheckBox2" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2" >
                    内容：<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FCKeditor1"
                        ErrorMessage="内容不能为空！"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" >
                    <fckeditorv2:fckeditor id="FCKeditor1" runat="server" BasePath="FCKeditor/"  Width=600px></fckeditorv2:fckeditor>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" CausesValidation="False" /></td>
            </tr>
        </table>
        </asp:Panel>
</asp:Content>

