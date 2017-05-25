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
using System.Net;
using Model;
using BLL;
public partial class Article : System.Web.UI.Page
{
    ContentBLL contbll = new ContentBLL();
    Model.Content content = new Model.Content();
    CommentBLL commentbll = new CommentBLL();
    protected string cid, id;

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Request.QueryString["id"].ToString();
        if (StringHandling.String.CheckBadQuery(id))
        {
            if (!IsPostBack)
            {
                //content = contbll.ViewOneContent(Convert.ToInt32(id));
                content = contbll.ViewOneContent(id);
                Literal1.Text = content.L_Title;
                Literal2.Text = content.L_Author;
                Literal3.Text = content.L_PostTime.ToString();
                Literal4.Text = content.L_Content;
                Literal5.Text = tag(content.L_tag);
                Literal6.Text = content.L_CTitle;
                cid = content.L_CID.C_ID.ToString();
                content.L_ViewNums = content.L_ViewNums + 1;
                Literal7.Text = "点击：(" + content.L_ViewNums.ToString() + ")";
                contbll.CreateOneContent(content);
                repeaterbind();
            }
        }
        else
        {
            StringHandling.JavaScript.ShowAndRedirect(Page, "参数错误！！", "default.aspx");
        }

    }
    protected void repeaterbind()
    {
        Repeater1.DataSource = commentbll.ViewAllComment("B_ID='" + Request.QueryString["id"].ToString() + "'", "C_ID desc");
        Repeater1.DataBind();
    }
    protected void GetSortCount(string ID)
    {
        Response.Write(commentbll.ViewAllComment("B_ID = '" + ID + "'", null).Count.ToString());

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Comment comment = new Comment();
            comment.B_Title = Literal1.Text;
            comment.C_Author = StringHandling.String.SqlInsertEncode(TextBox1.Text);
            comment.C_Content = StringHandling.String.SqlInsertEncode(TextBox3.Text);
            //comment.B_ID = Request.QueryString["id"].ToString();
            Model.Content content;
            ContentBLL contentBLL = new ContentBLL();
            //content = contentBLL.ViewOneContent(Convert.ToInt32(Request.QueryString["id"].ToString()));
            content = contentBLL.ViewOneContent(Request.QueryString["id"].ToString());
            comment.B_ID = content;
            comment.C_PostIP = Page.Request.UserHostAddress;
            commentbll.CreateOneComment(comment);
            repeaterbind();
        }
    }
    protected string tag(string tag)
    {
        string temp = "";
        string[] array = tag.Split('|');
        foreach (string i in array)
        {
            temp += "&nbsp;&nbsp;<A rel=tag href='Articlelist.aspx?type=1&tag=" + i.ToString() + "'>" + i.ToString() + "</A>";
        }
        return temp;



    }
}
