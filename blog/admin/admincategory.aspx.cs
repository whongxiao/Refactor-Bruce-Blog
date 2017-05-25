using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using BLL;
using Model;
using System.Collections.Generic;

public partial class admin_admincatory : System.Web.UI.Page
{
    CategoryBLL categorybll = new CategoryBLL();
    Category category = new Category();
    MemberBLL membll = new MemberBLL();
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
        Repeater1.DataSource = categorybll.ViewAllCategory(null, " C_Time desc");
        Repeater1.DataBind();
    }

    protected void update_Click(object sender, CommandEventArgs e)
    {
        //category = categorybll.ViewOneCategory(Convert.ToInt32(e.CommandName));
        category = categorybll.ViewOneCategory(e.CommandName);
        TextBox1.Text = category.C_Name;
        TextBox2.Text = category.C_Url;
        TextBox3.Text = category.C_Order.ToString();
        TextBox4.Text = category.C_Intro;
        Button1.Text = "修改";
        id = category.C_ID.ToString();
        Panel2.Visible = true;
        Panel1.Visible = false;
        Button3.Visible = false;

    }

    protected void delete_Click(object sender, CommandEventArgs e)
    {
        ContentBLL bll = new ContentBLL();
        Model.Content content = new Model.Content();
        //IList<Model.Content> list = bll.ViewAllContent("L_CID=" + Convert.ToInt32(e.CommandName), null);
        IList<Model.Content> list = bll.ViewAllContent("L_CID='" + e.CommandName+"'", null);
        if (list.Count>0)
           StringHandling.JavaScript.Show(this.Page, "请删除该栏目下的文章！");
        else
        {
            Model.Category category;
            CategoryBLL cateBLL = new CategoryBLL();
            //category = cateBLL.ViewOneCategory(Convert.ToInt32(e.CommandName));
            category = cateBLL.ViewOneCategory(e.CommandName);
            categorybll.DisCardOneCategory(category);
           repeaterbind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            category.C_Name = TextBox1.Text.Trim();
            category.C_Url = TextBox2.Text.Trim();
            category.C_Order = TextBox3.Text.Trim();
            category.C_Intro = TextBox4.Text.Trim();
            if (Button1.Text == "提交")
                categorybll.CreateOneCategory(category);
            else
            {
                //category.C_ID =Convert.ToInt32(id);
                category.C_ID = id;
                categorybll.ModifyOneCategory(category);
                Button1.Text = "提交";
            }
            clear();
            repeaterbind();
            Panel2.Visible = false;
            Panel1.Visible = true;
            Button3.Visible = true;
        }
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
    }
}
