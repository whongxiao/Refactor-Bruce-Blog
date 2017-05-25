<%@ Page Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeFile="admincategory.aspx.cs" Inherits="admin_admincatory" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="添加类别" />
        <asp:Panel ID="Panel1" runat="server">
    <asp:Repeater id="Repeater1" runat="server">
    <HeaderTemplate> <table width= 580px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;">   
            <tr><td  width=380>标题</td><td width=80 >时间</td><td  width=40>排序 </td>
                   <td  width=40px></td>
                   <td width=40px> </td>
            </tr>
        </table>          
    </HeaderTemplate>
           <ItemTemplate><table width= 600px style="table-layout:fixed;word-break: break-all; word-wrap: break-word;">   
     
            <tr ><td width=380 > <%# Eval("C_Name")%>  </td>
              <td width=80> <%# Eval("C_Time")%>  </td>
                 <td width=40 > <%# Eval("C_Order")%>  </td>
          
               <td  width=40>  <asp:Button ID="update" runat="server" CommandName='<%# Eval("C_ID")%>' OnCommand="update_Click"  Text="修改" /></td>
               <td width=40>  <asp:Button ID="delete" runat="server" CommandName='<%# Eval("C_ID")%>' OnCommand="delete_Click" Text="删除" /></td>
            </tr></table>  
          
                        </ItemTemplate>
                        </asp:Repeater>

      
          </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Visible=false>
        <table style="width: 600px">
            <tr>
                <td >
                    标题：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="类别名不能为空！"></asp:RequiredFieldValidator></td>
                <td style="width: 388px" >
                    URL：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                    排序：<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="TextBox3"
                        ErrorMessage="数字！" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator></td>
                <td style="width: 388px" >
                    </td>
            </tr>
            <tr>
                <td colspan="2" >
                    介绍：</td>
            </tr>
            <tr>
                <td colspan="2" style="height: 88px" >
                    <asp:TextBox ID="TextBox4" runat="server" Height="93px" TextMode="MultiLine" Width="530px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2" >
                    &nbsp;<asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Button2_Click" /></td>
            </tr>
        </table>
        </asp:Panel>
</asp:Content>

