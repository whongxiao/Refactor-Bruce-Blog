/*

* Copyright (C) 2017 Ȫ�����ܿƼ����Ϻ������޹�˾. All rights reserved.
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
using System.Collections;
using System.Text;
using NHibernate;

namespace NHibernateUtility
{
    public class PaginationUtility
    {
        public IList GetEntitesPage(int pageIndex, int pageSize, string table, string where, string orderBy)
        {
            string query = "From " + table;
            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " Where " + where;
            }
            if (!String.IsNullOrEmpty(orderBy) && orderBy != "")
            {
                query += " Order By " + orderBy;
            }

            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageSize < 1)
            {
                pageSize = 1;
            }

            IList lst;
            
            ISession session =NHibernateSessionHelper.GetCurrentSession();

            lst = session.CreateQuery(query).SetFirstResult(pageSize * (pageIndex - 1)).SetMaxResults(pageSize).List();

            //session.Close();

            return lst;
        }

        public string GetPageSet(int pageIndex, int pageSize, string tableName, string where, string urlFormat, int mode)
        {
            ISession session = NHibernateSessionHelper.GetCurrentSession();
            int recordCount = DirectRunUtility.GetRecordCount(session, tableName, where);
            //session.Close();
            return SplitPage.GetPageSet(pageIndex, pageSize, recordCount, urlFormat, mode);
        }

        public int ExecuteNonQuery(string sqlString)
        {
            ISession session = NHibernateSessionHelper.GetCurrentSession();
            int num = DirectRunUtility.ExecuteNonQuery(session, sqlString);
            //session.Close();
            return num;
        }

    }
}
