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

public partial class contorl_archive : System.Web.UI.UserControl
{
    ContentBLL bll = new ContentBLL();
    Model.Content content = new Model.Content();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            repeaterbind();
    }
    private void repeaterbind()
    {
        Repeater1.DataSource = bll.GetOnePage(1, 10, null, null);
        Repeater1.DataBind();
    
    }
}
