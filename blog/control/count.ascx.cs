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

public partial class contorl_count : System.Web.UI.UserControl
{
    protected string blog;
    protected string comment;

    protected void Page_Load(object sender, EventArgs e)
    {
        ContentBLL bll = new ContentBLL();
        blog = bll.ViewAllContent(null, null).Count.ToString();
        CommentBLL bll2 = new CommentBLL();
        comment=bll2.ViewAllComment(null,null).Count.ToString();
        //记数器
        int c = (int)Application["count"];
        int dc = (int)Application["day_count"];
        string count = c.ToString();//转换为字符串
        string day_count = dc.ToString();
        //根据字符串每位的值调用图片
        for (int i = 0; i < count.Length; ++i)
        {
            int n = count.Length;
            Image img = new Image();

            img.ImageUrl = "~\\count\\" + count[i] + ".gif";
            ph1.Controls.Add(img);
        }
        for (int i = 0; i < day_count.Length; ++i)
        {
            int n = day_count.Length;
            Image img = new Image();
            img.ImageUrl = "~\\count\\" + day_count[i] + ".gif";
            ph2.Controls.Add(img);
        }

    }
}
