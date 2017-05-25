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

public partial class contorl_roll : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            repeaterbind();
    }
    void repeaterbind()
    {     LinkBLL bll=new LinkBLL ();
          Repeater1.DataSource = bll.ShowAllLinks("L_IsShow=1","L_Order desc");
          Repeater1.DataBind();
    }
}
