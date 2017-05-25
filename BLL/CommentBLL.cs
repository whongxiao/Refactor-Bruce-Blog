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
    public class CommentBLL
    {
        private ICommentDAO commentDAO;
        public CommentBLL()
        {
            DAOFactory daoFactory = new DAOFactory();
            commentDAO = daoFactory.GetCommemtDAO();
        }
        public Comment ViewOneComment(string id)
        {
            return commentDAO.FindById(id);
        }
        public void CreateOneComment(Comment entity)
        {
            commentDAO.MakePersistent(entity);
        }
        public void ModifyOneComment(Comment entity)
        {
            commentDAO.UpDate(entity);
        }
        public void DisCardOneComment(Comment entity)
        {
            commentDAO.MakeTransient(entity);
        }
        public IList<Comment> ViewAllComment(string where, string orderBy)
        {
            Comment comment = new Comment();
            return commentDAO.GetAll(comment, where, orderBy);
        }
        public int ExecuteNonQuery(string sql)
        {
            return commentDAO.ExecuteNonQuery(sql);
        }
        public IList GetOnePage(int pageIndex, int pageSize, string where, string orderBy)
        {
            return commentDAO.GetPage(pageIndex, pageSize, where, orderBy);
        }
        public string GetPageNavigation(int pageIndex, int pageSize, string where, string urlFormat, int mode)
        {
            PaginationUtility pagination = new PaginationUtility();
            return pagination.GetPageSet(pageIndex, pageSize, "b_comment", where, urlFormat, mode);

        }
    }
}
