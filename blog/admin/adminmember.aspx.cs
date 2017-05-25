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

public partial class admin_adminmember : System.Web.UI.Page
{
    MemberBLL membll = new MemberBLL();
    Member mem = new Member();
    static string id;
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
        Repeater1.DataSource = membll.GetOnePage(pageIndex, 10, null, "M_RegTime desc");
        Repeater1.DataBind();
        pageset.Text = membll.GetPageNavigation(pageIndex, 10, null, "adminmember.aspx?Page=$", 0);
    }

    protected void update_Click(object sender, CommandEventArgs e)
    {
        if (IsValid)
        {
            //mem = membll.ViewOneMember(Convert.ToInt32(e.CommandName));
            mem = membll.ViewOneMember(e.CommandName);
            TextBox1.Text = mem.M_Name;
            Label2.Text = mem.M_Password;
            if (mem.M_Sex == 0)
            {
                RadioButtonList1.Items[0].Selected = true;
            }
            else
            {
                RadioButtonList1.Items[1].Selected = true;
            }
            TextBox3.Text = mem.M_Email;
            TextBox4.Text = mem.M_QQ;
            Label1.Text = mem.M_RegIP;
            CheckBox1.Checked = mem.M_staus == 0 ? false : true;
            TextBox5.Text = mem.M_HomePage;
            TextBox6.Text = mem.M_Intro;
            Button1.Text = "修改";
            id = mem.M_ID.ToString();
            Panel2.Visible = true;
            Panel1.Visible = false;
            Button3.Visible = false;
        }

    }

    protected void delete_Click(object sender, CommandEventArgs e)
    {
        Model.Member member;
        MemberBLL memberBLL = new MemberBLL();
        //member = memberBLL.ViewOneMember(Convert.ToInt32(e.CommandName));
        member = memberBLL.ViewOneMember(e.CommandName);
        membll.DisCardOneMember(member);
        repeaterbind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        mem.M_Name= TextBox1.Text.Trim();
        if (TextBox2.Text.Trim() == "")
            if (Button1.Text == "提交")
            {
               StringHandling.JavaScript.Show(this.Page, "密码不能为空！");
               return;
            }
            else
                mem.M_Password = Label2.Text;
        else
            mem.M_Password =StringHandling.Security.Md5(TextBox2.Text.Trim());
        mem.M_Email = TextBox3.Text.Trim();
        mem.M_QQ = TextBox4.Text.Trim();
        mem.M_HomePage= TextBox5.Text.Trim();
        mem.M_Intro = TextBox6.Text.Trim();
        mem.M_RegIP = Label1.Text;
        mem.M_Sex =Convert.ToInt32( RadioButtonList1.SelectedValue);
        mem.M_staus = CheckBox1.Checked == true ? 1 : 0;
        if (Button1.Text == "提交")
            membll.CreateOneMember(mem);
        else
        {
            mem.M_ID = id;
            membll.ModifyOneMember(mem);
            Button1.Text = "提交";
        }
        clear();
        repeaterbind();
        Panel2.Visible = false;
        Panel1.Visible = true;
        Button3.Visible = true;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        Button3.Visible = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void clear()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        Label1.Text = "";
        Label2.Text = "";
    }
}
