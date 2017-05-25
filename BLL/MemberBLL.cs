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
    public class MemberBLL
    {
        private IMemberDAO memberDAO;
        public MemberBLL()
        {
            DAOFactory daoFactory = new DAOFactory();
            memberDAO = daoFactory.GetMemberDAO();
        }
        public Member ViewOneMember(string id)
        {
            return memberDAO.FindById(id);
        }
        public void CreateOneMember(Member entity)
        {
            memberDAO.MakePersistent(entity);
        }
        public void ModifyOneMember(Member entity)
        {
            memberDAO.UpDate(entity);
        }
        public void DisCardOneMember(Member entity)
        {
            memberDAO.MakeTransient(entity);
        }
        public IList<Member> ViewAllMember(string where, string orderBy)
        {
            Member Member = new Member();
            return memberDAO.GetAll(Member, where, orderBy);
        }
        public int ExecuteNonQuery(string sql)
        {
            return memberDAO.ExecuteNonQuery(sql);
        }
        public IList GetOnePage(int pageIndex, int pageSize, string where, string orderBy)
        {
            return memberDAO.GetPage(pageIndex, pageSize, where, orderBy);
        }
        public string GetPageNavigation(int pageIndex, int pageSize, string where, string urlFormat, int mode)
        {
            PaginationUtility pagination = new PaginationUtility();
            return pagination.GetPageSet(pageIndex, pageSize, "b_member", where, urlFormat, mode);

        }
        public Member GetByUserName(string userName)
        {
            return memberDAO.GetByUserName(userName);
        }
    }
}
