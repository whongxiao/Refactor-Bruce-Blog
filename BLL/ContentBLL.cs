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
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Model;
using PersistenceLayer;
using NHibernateUtility;
namespace BLL
{
    public class ContentBLL
    {
        private IContentDAO contentDAO;
        public ContentBLL()
        {
            DAOFactory daoFactory = new DAOFactory();
            contentDAO = daoFactory.GetContentDAO();
        }
        public Content ViewOneContent(string id)
        {
            return contentDAO.FindById(id);
        }
        public void CreateOneContent(Content entity)
        {
            contentDAO.MakePersistent(entity);
        }
        public void ModifyOneContent(Content entity)
        {
            contentDAO.UpDate(entity);
        }
        public void DisCardOneContent(Content entity)
        {
            contentDAO.MakeTransient(entity);
        }
        public IList<Comment> ViewAllComment(string where, string orderBy)
        {
            Comment comment = new Comment();
            return contentDAO.ReadAllComment(comment, where, orderBy);
        }
        public IList<Content> ViewAllContent(string where, string orderBy)
        {
            Content content = new Content();
            return contentDAO.GetAll(content, where, orderBy);
        }
        public int ExecuteNonQuery(string sql)
        {
            return contentDAO.ExecuteNonQuery(sql);
        }
        public IList GetOnePage(int pageIndex, int pageSize, string where, string orderBy)
        {
            return contentDAO.GetPage(pageIndex, pageSize, where, orderBy);
        }
        public string GetPageNavigation(int pageIndex, int pageSize, string where, string urlFormat, int mode)
        {
            PaginationUtility pagination = new PaginationUtility();
            return pagination.GetPageSet(pageIndex, pageSize, "b_content", where, urlFormat, mode);

        }
    }
}
