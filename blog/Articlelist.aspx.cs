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
public partial class Articlelist : System.Web.UI.Page
{
    ContentBLL contbll = new ContentBLL();
    CommentBLL commentbll = new CommentBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        string id;
        if (Request.QueryString["type"].ToString() == "1")
            id = Request.QueryString["type"].ToString() + Request.QueryString["tag"].ToString();
        else
            id = Request.QueryString["type"].ToString() + Request.QueryString["year"].ToString();
        if (StringHandling.String.CheckBadQuery(id))
        {
            if (!IsPostBack)
            {
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
        string type = Request.QueryString["type"].ToString();
        string action;
        string where = "";
        switch (type)
        {
            case "1": action = Request.QueryString["tag"].ToString(); where = "L_Title like '%" + action + "%' or L_tag like '%" + action + "%'"; break;
            case "2": action = Request.QueryString["year"].ToString(); where = "L_PostTime like '%" + action + "%'"; break;
        }


        int pageIndex = StringHandling.Integer.GetInteger(Request.QueryString["Page"], 1);
        Repeater1.DataSource = contbll.GetOnePage(pageIndex, 10, where, "L_PostTime desc");
        Repeater1.DataBind();
        //pageset.Text = contbll.GetPageSet(pageIndex, 10, where, "Default.aspx?Page=$", 1);
        NHibernateUtility.PaginationUtility paginationUtility = new NHibernateUtility.PaginationUtility();
        pageset.Text = paginationUtility.GetPageSet(pageIndex, 10, "b_content", where, "Default.aspx?Page=$", 1);

    }
    protected string GetSortCount(string Id)
    {
        return commentbll.ViewAllComment("B_ID = '" + Id + "'", null).Count.ToString();
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
