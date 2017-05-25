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
using StringHandling;

public partial class _Default : System.Web.UI.Page
{
    ContentBLL contbll = new ContentBLL();
    CommentBLL commentbll = new CommentBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            repeaterbind();
    }
    protected void repeaterbind()
    {
        int pageIndex = StringHandling.Integer.GetInteger(Request.QueryString["Page"], 1);
        Repeater1.DataSource = contbll.GetOnePage(pageIndex, 10, null, "L_PostTime desc");
        Repeater1.DataBind();
        //pageset.Text = contbll.GetPageSet(pageIndex, 10, null, "Default.aspx?Page=$", 1);
        NHibernateUtility.PaginationUtility paginationUtility = new NHibernateUtility.PaginationUtility();
        pageset.Text = paginationUtility.GetPageSet(pageIndex, 10, "b_content", null, "Default.aspx?Page=$", 1);

    }
    protected string GetSortCount(string Id)
    {
        return commentbll.ViewAllComment("B_ID='" + Id+"'", null).Count.ToString();
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
