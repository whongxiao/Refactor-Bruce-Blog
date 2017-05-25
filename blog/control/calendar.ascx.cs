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
using System.Threading;
using System.Drawing;
using System.Globalization;
using System.ComponentModel;
using System.Data.OleDb;
using Model;
using BLL;

public partial class contorl_calendar : System.Web.UI.UserControl
{
    private int[] arrCurrentDays, arrPreDays, arrNextDays; //三个变量分别是当前月，前一月，和下一个月 
    private int intCurrentMonth, intPreMonth, intNextMonth; //三个整型数组存放相对月份写有blog的日期 


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int[] getArrayDay(int intYear, int intMonth)
    {
        int i = 0;
        int[] intArray = new int[31];
        string mySelectQuery = "select L_PostTime from b_content where year(L_PostTime)=" + intYear + "and month(L_PostTime)=" + intMonth;
        OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/bruceblog.mdb");
        OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
        myConnection.Open();
        OleDbDataReader myReader;
        myReader = myCommand.ExecuteReader();
        while (myReader.Read())
        {
            if (i == 0)
            {
                intArray[i] = myReader.GetDateTime(0).Day;
                i++;
            }
            else if (myReader.GetDateTime(0).Day != intArray[i - 1])
            {
                intArray[i] = myReader.GetDateTime(0).Day;
                i++;
            }
        }
        myReader.Close();
        myConnection.Close();

        return intArray;
    }



    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        //该控件在创建每一天时发生。   
        CalendarDay d = ((DayRenderEventArgs)e).Day;
        TableCell c = ((DayRenderEventArgs)e).Cell;
        // 初始化当前月有Blog的日期数组 
        if (intPreMonth == 0)
        {
            intPreMonth = d.Date.Month; // 注意：日历控件初始化时我们得到的第一个月并不是当前月，而是前一个月的月份 
            //Response.Write(d.Date.Month.ToString());
            intCurrentMonth = intPreMonth + 1;
            if (intCurrentMonth > 12)
                intCurrentMonth = 1;
            intNextMonth = intCurrentMonth + 1;
            if (intNextMonth > 12)
                intNextMonth = 1;
            arrPreDays = getArrayDay(d.Date.Year, intPreMonth); //得到前一个月有blog的日期数组 
            arrCurrentDays = getArrayDay(d.Date.Year, intCurrentMonth);//得到当月有blog的日期数组 
            arrNextDays = getArrayDay(d.Date.Year, intNextMonth);//得到下个月有blog的日期数组 
        }

        int j = 0;


        if (d.Date.Month.Equals(intPreMonth))
        {
            while (!arrPreDays[j].Equals(0))
            {
                if (d.Date.Day.Equals(arrPreDays[j]))
                {
                    c.Controls.Clear();
                    c.Controls.Add(new LiteralControl("<a href='Articlelist.aspx?type=2&year=" + d.Date.Year + "-" +
                     d.Date.Month + "-" + d.Date.Day + "'>" + d.Date.Day + "</a>"));
                }
                j++;
            }
        }
        else if (d.Date.Month.Equals(intCurrentMonth))
        {
            while (!arrCurrentDays[j].Equals(0))
            {
                if (d.Date.Day.Equals(arrCurrentDays[j]))
                {
                    c.Controls.Clear();
                    c.Controls.Add(new LiteralControl("<a href='Articlelist.aspx?type=2&year=" + d.Date.Year + "-" +
                     d.Date.Month + "-" + d.Date.Day + "' title='" + d.Date.Year + '/' + d.Date.Month + '/' + d.Date.Day + "'>" + d.Date.Day + "</a>"));
                }
                j++;
            }
        }
        else if (d.Date.Month.Equals(intNextMonth))
        {
            while (!arrNextDays[j].Equals(0))
            {
                if (d.Date.Day.Equals(arrNextDays[j]))
                {
                    c.Controls.Clear();
                    c.Controls.Add(new LiteralControl("<a href='Articlelist.aspx?type=2&year=" + d.Date.Year + "-" +
                     d.Date.Month + "-" + d.Date.Day + "'>" + d.Date.Day + "</a>"));
                }
                j++;
            }
        }


    }
    protected void Calendar1_PreRender(object sender, EventArgs e)
    {
        Thread threadCurrent = Thread.CurrentThread;
        CultureInfo ciNew = (CultureInfo)threadCurrent.CurrentCulture.Clone();
        ciNew.DateTimeFormat.DayNames = new string[] { "日", "一", "二", "三", "四", "五", "六" };
        ciNew.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Sunday;

        threadCurrent.CurrentCulture = ciNew;


    }


}
