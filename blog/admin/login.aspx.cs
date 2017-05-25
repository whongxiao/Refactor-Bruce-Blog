using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

 
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Model;
using BLL;

public partial class admin_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // Response.Write(StringHandling.Security.Md5("51aspx"));

        MemberBLL adminBLL = new MemberBLL();
        Member admin = adminBLL.GetByUserName(StringHandling.String.SqlQueryEncode(TextBox1.Text.Trim()));

        if ((admin != null) && (admin.M_Password == StringHandling.Security.Md5(TextBox2.Text.Trim())))
        {
            LoginOK(admin);
        }
        else
        {
         StringHandling.JavaScript.Show(Page, "用户名或密码错误！");
        }
    }

    //登录成功
    private void LoginOK(Member admin)
    {
        Session["admin"] = admin.M_Name;
        Response.Redirect("adminblog.aspx");
    }
}
