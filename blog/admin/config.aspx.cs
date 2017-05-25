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

public partial class admin_config : System.Web.UI.Page
{
    BLL.MemberBLL membll = new BLL.MemberBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            if (Session["admin"] == null)
                StringHandling.JavaScript.ShowAndRedirect(Page, "请登陆！", "login.aspx");
            else
            {
               Model.Member member = membll.GetByUserName(Session["admin"].ToString());
                if (member.M_Name == null)
                    StringHandling.JavaScript.ShowAndRedirect(Page, "请登陆！", "login.aspx");
                else
                    readxml();
            }

    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("../") + "web.config");
        // 不是Tables[0]
        ds.Tables[3].Rows[0][1] =TextBox1.Text;
        ds.Tables[3].Rows[1][1] =TextBox2.Text;
        ds.Tables[3].Rows[2][1] =TextBox3.Text;
        ds.AcceptChanges();
        ds.WriteXml(Server.MapPath("../") + "web.config");
        ds.Clear();
        ds.Dispose();
        StringHandling.JavaScript.Show(Page, "修改成功");
        readxml();
    }

    void readxml()
    {
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("../") + "web.config");
        TextBox1.Text = ds.Tables[3].Rows[0][1].ToString();
        TextBox2.Text = ds.Tables[3].Rows[1][1].ToString();
        TextBox3.Text = ds.Tables[3].Rows[2][1].ToString();
        //ds.AcceptChanges();
        //ds.WriteXml(Server.MapPath("../") + "web.config");
        ds.Clear();
        ds.Dispose();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
}
