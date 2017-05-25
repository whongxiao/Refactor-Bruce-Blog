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

public partial class admin_adminlogin : System.Web.UI.Page
{
    ContentBLL contbll = new ContentBLL();
    Model.Content cont = new Model.Content();
    CategoryBLL catebll = new CategoryBLL();
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
                if(member.M_Name==null)
                    StringHandling.JavaScript.ShowAndRedirect(Page, "请登陆！", "login.aspx");
                else
                repeaterbind();
            }

    }

    protected void repeaterbind()
    {
        DropDownList1.DataSource = catebll.ViewAllCategory(null, "C_Time");
        DropDownList1.DataTextField = "C_Name";
        DropDownList1.DataValueField = "C_ID";
        DropDownList1.DataBind();
        DropDownList2.DataSource = catebll.ViewAllCategory(null, "C_Time");
        DropDownList2.DataTextField = "C_Name";
        DropDownList2.DataValueField = "C_ID";
        DropDownList2.DataBind();
        int pageIndex = StringHandling.Integer.GetInteger(Request.QueryString["Page"], 1);
        Repeater1.DataSource = contbll.GetOnePage(pageIndex, 10, null, "L_PostTime desc");
        Repeater1.DataBind();
        pageset.Text = contbll.GetPageNavigation(pageIndex, 10, null, "adminblog.aspx?Page=$", 0);
    }

    protected void update_Click(object sender, CommandEventArgs e)
    {
        //cont = contbll.ViewOneContent(Convert.ToInt32(e.CommandName));
        cont = contbll.ViewOneContent(e.CommandName);
        TextBox1.Text = cont.L_Title;
        TextBox2.Text = cont.L_Author;
        TextBox3.Text = cont.L_From;
        TextBox4.Text = cont.L_comorder.ToString();
        TextBox5.Text = cont.L_tag;
        FCKeditor1.Value = cont.L_Content;
        CheckBox1.Checked = cont.L_IsShow == 0 ? false : true;
        CheckBox2.Checked = cont.L_IsTop == 0 ? false : true;
        DropDownList1.SelectedValue = cont.L_CID.C_ID.ToString();
        Button1.Text = "修改";
        id = cont.L_ID.ToString();
        Panel2.Visible = true;
        Panel1.Visible = false;
        Button3.Visible = false;

    }

    protected void delete_Click(object sender, CommandEventArgs e)
    {
        CommentBLL commbll = new CommentBLL();
        Model.Content content;
        ContentBLL contentBLL = new ContentBLL();
        //content = contentBLL.ViewOneContent(Convert.ToInt32(e.CommandName));
        content = contentBLL.ViewOneContent(e.CommandName);
        contbll.DisCardOneContent(content);
        //commbll.ExecuteNonQuery("delete from b_comment where B_ID=" + Convert.ToInt32(e.CommandName));
        commbll.ExecuteNonQuery("delete from b_comment where B_ID='" + e.CommandName+"'");
        StringHandling.JavaScript.Show(this.Page, "删除成功！");
        repeaterbind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            cont.L_Title = TextBox1.Text.Trim();
            cont.L_Author = TextBox2.Text.Trim();
            cont.L_From = TextBox3.Text.Trim();
            cont.L_comorder = TextBox4.Text.Trim();
            cont.L_tag = TextBox5.Text.Trim();
            cont.L_IsShow = CheckBox1.Checked == true ? 1 : 0;
            cont.L_IsTop = CheckBox2.Checked == true ? 1 : 0;
            cont.L_Content= FCKeditor1.Value;
            Model.Category category;
            CategoryBLL categoryBLL = new CategoryBLL();
            //category = categoryBLL.ViewOneCategory(Convert.ToInt32(DropDownList1.SelectedValue));
            category = categoryBLL.ViewOneCategory(DropDownList1.SelectedValue);
            cont.L_CID = category;
            cont.L_CTitle = DropDownList1.SelectedItem.Text;
            if (Button1.Text == "提交")
                contbll.CreateOneContent(cont);
            else
            {
                cont.L_ID = id;
                contbll.ModifyOneContent(cont);
            }
            StringHandling.JavaScript.Show(this.Page, Button1.Text + "成功!!");
            Button1.Text = "提交";
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
        TextBox5.Text = "";
        FCKeditor1.Value = "";
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        int pageIndex = StringHandling.Integer.GetInteger(Request.QueryString["Page"], 1);
        Repeater1.DataSource = contbll.GetOnePage(pageIndex, 10, "L_CID='"+DropDownList2.SelectedValue+"'", "L_PostTime desc");
        Repeater1.DataBind();
        pageset.Text = contbll.GetPageNavigation(pageIndex, 10, "L_CID='" + DropDownList2.SelectedValue + "'", "adminblog.aspx?Page=$", 0);
    }
}
