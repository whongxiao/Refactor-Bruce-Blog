<%@ Application Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.OleDb" %>
<%@ Import Namespace="log4net" %>
<%@ Import Namespace="System.IO" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
       
        int count = 0;
        int day_count = 0;
        int year = 0;
        int month = 0;
        int day = 0;
        DateTime today = DateTime.Now;

        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/bruceblog.mdb");
        conn.Open();

        OleDbDataAdapter sda1 = new OleDbDataAdapter("select [count] from [webcount]",conn);
        DataSet ds = new DataSet();
        sda1.Fill(ds);

        
        //取总访问数
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            count = Convert.ToInt32(dr["count"].ToString());
        }
        ds.Clear();
        OleDbDataAdapter sda2 = new OleDbDataAdapter("select * from [day_count]", conn);
        sda2.Fill(ds);
        //取每天访问数
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            day_count = Convert.ToInt32(dr["day_count"].ToString());
            year = Convert.ToInt32(dr["year"].ToString());
            month = Convert.ToInt32(dr["month"].ToString());
            day = Convert.ToInt32(dr["day"].ToString());
        }
        //日期不同,则day_count为0
        if (today.Year != year || today.Month != month || today.Day != day)
            day_count = 0;

        Application["count"] = count;
        Application["day_count"] = day_count;


    }
    
    void Application_End(object sender, EventArgs e) 
    {
       

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Session.Timeout = 60; //设置Session的有效时间，可根据需要修改
        Application.Lock();
        Application["zzzonline"] = Convert.ToInt32(Application["zzzonline"]) + 1;
        int count = 0;
        int day_count = 0;
        int year = 0;
        int month = 0;
        int day = 0;
        DateTime today = DateTime.Now;
        year = today.Year;
        month = today.Month;
        day = today.Day;
        //访问次数都加１
        count = (int)Application["count"];
        day_count = (int)Application["day_count"];
        count++;
        day_count++;
        Application["count"] = count;
        Application["day_count"] = day_count;
        //更新数据库
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/bruceblog.mdb");
        conn.Open();
        OleDbCommand cmd1 = new OleDbCommand("update [webcount] set [count]='" + count + "'", conn);
        cmd1.ExecuteNonQuery();

        OleDbCommand cmd2 = new OleDbCommand("update [day_count] set [day_count]='" + day_count + "',[year]='" + year + "',[month]='" + month + "',[day]='" + day + "'", conn);
        cmd2.ExecuteNonQuery();
        Application.UnLock();//解锁
        Application.UnLock(); // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    { // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
        Application.Lock();
        Application["zzzonline"] = Convert.ToInt32(Application["zzzonline"]) - 1;
        Application.UnLock();//解锁

    }
       
</script>
