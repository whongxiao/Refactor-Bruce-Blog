using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NHibernate;
using NHibernate.Context;
using NHibernateUtility;
/// <summary>
/// NHibernateBindCurrentSession 的摘要说明
/// </summary>
public class NHibernateBindCurrentSession:IHttpModule
{
    public void Init(HttpApplication context)
    {
        context.BeginRequest += new EventHandler(Application_BeginRequest);
        context.EndRequest += new EventHandler(Application_EndRequest);
    }
    public void Dispose()
    {
    }
    private void Application_BeginRequest(object sender, EventArgs e)
    {
        log4net.Config.XmlConfigurator.Configure();
        //ISession session = NHibernateSessionHelper.OpenSession("Model");
        ISession session = NHibernateSessionHelper.GetCurrentSession();
        // CurrentSessionContext.Bind(session);
    }
    private void Application_EndRequest(object sender,EventArgs e)
    {
        ISession session = CurrentSessionContext.Unbind(NHibernateSessionHelper.SessionFactory);
        if(session!=null)
            try
            {
                if(session.IsOpen==true)
                    if(session.IsConnected==true&&session.Transaction.IsActive==true)
                    session.Transaction.Commit();
            }
            catch (Exception ex)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                if (session.IsOpen == true)
                    session.Close();
            }
    }
 
}
