<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="adminlink.aspx.cs" Inherits="admin_adminlink" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="add link" />
        <asp:Panel ID="Panel1" runat="server">
    <asp:Repeater id="Repeater1" runat="server">
    <HeaderTemplate> <table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;">   
            <tr><td width=200>name</td><td width=220>url</td><td width=40>order </td><td width=40>ishow</td>
                   <td  width=40></td>
                   <td width=40> </td>
            </tr>
        </table>          
    </HeaderTemplate>
           <ItemTemplate><table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;" >
     
            <tr ><td width=200> <%# Eval("L_Name")%>  </td>
                 <td  width=220> <%# Eval("L_Url")%>  </td>
                <td  width=40>  <%# Eval("L_Order")%>  </td>
                 <td  width=40>  <%# Eval("L_IsShow").ToString() == "0" ? "否" : "是"%>  </td>
               <td  width=40>  <asp:Button ID="update" runat="server" CommandName='<%# Eval("L_ID")%>' OnCommand="update_Click"  Text="修改" /></td>
               <td  width=40>  <asp:Button ID="delete" runat="server" CommandName='<%# Eval("L_ID")%>' OnCommand="delete_Click" Text="删除" /></td>
            </tr></table>  
          
                        </ItemTemplate>
                        </asp:Repeater>

      
          <asp:Literal ID="pageset"  runat="server" Mode="PassThrough"></asp:Literal></asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible=false>
        <table style="width: 600px">   
                   <tr>
                <td >
                    标题：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="不能为空！"></asp:RequiredFieldValidator></td>
                <td style="width: 388px" >
                    url:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    排序：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="数字！" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator></td>
                <td style="width: 388px" >
                    是否显示：<asp:CheckBox ID="CheckBox1" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    logo:<asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" /></td>
            </tr>
        </table>
        </asp:Panel>
</asp:Content>

