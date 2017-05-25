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

public partial class contorl_category : System.Web.UI.UserControl
{
    CategoryBLL categorybll = new CategoryBLL();
    Category category = new Category();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            repeaterbind();
    }
    protected void repeaterbind()
    {
        Repeater1.DataSource = categorybll.ViewAllCategory(null, " C_Order desc");
        Repeater1.DataBind();
    }
    protected string GetSortCount(string cid)
    {
        ContentBLL contentbll = new ContentBLL();
        return contentbll.ViewAllContent("L_CID = '" + cid+"'", null).Count.ToString();
    }

}
