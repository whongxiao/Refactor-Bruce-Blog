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
using BLL;
using Model;

public partial class admin_admincomment : System.Web.UI.Page
{
    CommentBLL commbll = new CommentBLL();
    Comment comm = new  Comment();
    MemberBLL membll = new MemberBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            if (Session["admin"] == null)
                StringHandling.JavaScript.ShowAndRedirect(Page, "请登陆！", "login.aspx");
            else
            {
                Member member = membll.GetByUserName(Session["admin"].ToString());
                if (member.M_Name == null)
                    StringHandling.JavaScript.ShowAndRedirect(Page, "请登陆！", "login.aspx");
                else
                    repeaterbind();
            }

    }

    protected void repeaterbind()
    {
        int pageIndex = StringHandling.Integer.GetInteger(Request.QueryString["Page"], 1);
        Repeater1.DataSource = commbll.GetOnePage(pageIndex, 10, null, "C_PostTime desc");
        Repeater1.DataBind();
        pageset.Text = commbll.GetPageNavigation(pageIndex, 10, null, "admincomment.aspx?Page=$", 0);
    }

    protected void update_Click(object sender, CommandEventArgs e)
    {
        //comm = commbll.ViewOneComment(Convert.ToInt32(e.CommandName));
        comm = commbll.ViewOneComment(e.CommandName);
        TextBox1.Text = comm.B_Title;
        TextBox2.Text = comm.C_Author;
        TextBox3.Text = comm.C_PostTime.ToString();
        TextBox4.Text = comm.C_PostIP;
        Literal1.Text= comm.C_Content;
        Panel2.Visible = true;
        Panel1.Visible = false;

    }

    protected void delete_Click(object sender, CommandEventArgs e)
    {
        Model.Comment comment;
        CommentBLL commentBLL = new CommentBLL();
        //comment = commentBLL.ViewOneComment(Convert.ToInt32(e.CommandName));
        comment = commentBLL.ViewOneComment(e.CommandName);
        commbll.DisCardOneComment(comment);
        repeaterbind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = true;
    }
}
