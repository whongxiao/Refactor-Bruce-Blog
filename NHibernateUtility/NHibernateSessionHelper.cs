/*

* Copyright (C) 2017 泉沧智能科技（上海）有限公司. All rights reserved.
*
* Licensed under the Apache License, Version 2.0 (the "License"); 
* you may not use this file except in compliance with the License. 
* You may obtain a copy of the License at
*
*	http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, 
* software distributed under the License is distributed on an "AS IS" BASIS, 
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
* See the License for the specific language governing permissions and 
* limitations under the License.
*/

using System;
using System.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Web;
using NHibernate.Context;
namespace NHibernateUtility
{
    public class NHibernateSessionHelper
    {
        //private static ISessionFactory sessions;
        public static readonly ISessionFactory SessionFactory;
        //private static Configuration cfg;
        //private static readonly object padlock = new object();
        static NHibernateSessionHelper()
        {
            try
            {
                Configuration cfg = new Configuration();
                //sessions = cfg.Configure().BuildSessionFactory();
                SessionFactory = cfg.Configure().BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw new Exception("NHibernate SessionFactory initialization failed.", ex);
            }
        }

        public static ISession GetCurrentSession()
        {
            ISession session=null;
            //session = sessions.GetCurrentSession();
            try
            {
                session = SessionFactory.GetCurrentSession();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (session == null)
                {
                    session = SessionFactory.OpenSession();
                    CurrentSessionContext.Bind(session);
                    session.BeginTransaction();
                }
            }
            
            if (session.IsOpen==false)
            {
                session = CurrentSessionContext.Unbind(NHibernateSessionHelper.SessionFactory);
                //session = sessions.OpenSession();
                session = SessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
                session.BeginTransaction();
            }
            return session;
        }
    }
}
