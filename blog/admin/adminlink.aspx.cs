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

public partial class admin_adminlink : System.Web.UI.Page
{
    LinkBLL linkbll = new LinkBLL();
    Link link = new Link();
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
        Repeater1.DataSource = linkbll.ShowAllLinks(null, " L_ID desc");
        Repeater1.DataBind();
    }

    protected void update_Click(object sender, CommandEventArgs e)
    {
        //link = linkbll.ViewOneLink(Convert.ToInt32(e.CommandName));
        link = linkbll.ViewOneLink(e.CommandName);
        TextBox1.Text = link.L_Name;
        TextBox2.Text = link.L_Url;
        TextBox3.Text = link.L_Order.ToString();
        CheckBox1.Checked=link.L_IsShow==0 ? false : true;
        Label2.Text = link.L_Image;
        Button1.Text = "修改";
        id = link.L_ID.ToString();
        Panel2.Visible = true;
        Panel1.Visible = false;
        Button3.Visible = false;
    }

    protected void delete_Click(object sender, CommandEventArgs e)
    {
        Link link;
        LinkBLL linkBLL = new LinkBLL();
        //link = linkBLL.ViewOneLink(Convert.ToInt32(e.CommandName));
        link = linkBLL.ViewOneLink(e.CommandName);
        linkbll.DiscardOneLink(link);
        repeaterbind();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            link.L_Name = TextBox1.Text.Trim();
            link.L_Url = TextBox2.Text.Trim();
            link.L_Order =TextBox3.Text.Trim();
            link.L_IsShow = CheckBox1.Checked == true ? 1 : 0;
            link.L_Image = Label2.Text;
            if (Button1.Text == "提交")
            {
                linkbll.CreateOneLink(link);
            }
            else
            {
                link.L_ID = id;
                linkbll.ModifyOneLink(link);
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
        Label2.Text = "";
        Label1.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        bool fileok = false;
        string path=Server.MapPath("~/images/");
        if (FileUpload1.HasFile)
        {
            string fileextension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            string[] allowedExtension ={ ".gif", ".png", ".bmp", ".jpg" };
            for (int i = 0; i < allowedExtension.Length; i++)
            {
                if (fileextension == allowedExtension[i])
                { fileok = true; }
            }
        }
        if (fileok)
        {
            try
            {
                FileUpload1.SaveAs(path + FileUpload1.FileName);
                Label1.Text = "图片上传成功！";
                Label2.Text = path + FileUpload1.FileName;
            }
            catch 
            {
                Label1.Text = "图片上传不成功！";
            }
        }
        else
        { Label1.Text = "只能上传图片文件！"; }

    }
}
