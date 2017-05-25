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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Model;
using NHibernateUtility;
using NHibernate;
namespace PersistenceLayer
{
    public class ContentDAO : GenericDAO<Content, string>, IContentDAO
    {
        IList IContentDAO.GetPage(int pageIndex, int pageSize, string where, string orderBy)
        {
            PaginationUtility pagination = new PaginationUtility();
            return pagination.GetEntitesPage(pageIndex, pageSize, "Model.Content", where, orderBy);
        }
        int IContentDAO.ExecuteNonQuery(string sql)
        {
            PaginationUtility pagination = new PaginationUtility();
            return pagination.ExecuteNonQuery(sql);
        }
        IList<Comment> IContentDAO.ReadAllComment(Comment comment, string where, string orderBy)
        {
            string entityName = "Model.Content";
            string sqlString = "from " + entityName;
            if (!String.IsNullOrEmpty(where) && where != "")
                sqlString += " where " + where;
            if (!String.IsNullOrEmpty(orderBy) && orderBy != "")
                sqlString += " order by " + orderBy;
            IQuery query = Session.CreateQuery(sqlString);
            return query.List<Comment>();
        }
    }
}
