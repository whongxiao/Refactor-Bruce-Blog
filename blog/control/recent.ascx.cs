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


public partial class contorl_recent : System.Web.UI.UserControl
{
    BLL.ContentBLL bll = new BLL.ContentBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Repeater1.DataSource = bll.GetOnePage(1, 15, null, "L_comorder desc");
            Repeater1.DataBind();

        }

    }
}
