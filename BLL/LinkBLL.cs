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
    public class LinkBLL
    {
        private ILinkDAO linkDAO;
        public LinkBLL()
        {
            DAOFactory daoFactory = new DAOFactory();
            linkDAO = daoFactory.GetLinkDAO();
        }
        public Link ViewOneLink(string id)
        {
            return linkDAO.FindById(id);
        }
        public void CreateOneLink(Link entity)
        {
            linkDAO.MakePersistent(entity);
        }
        public void ModifyOneLink(Link entity)
        {
            linkDAO.UpDate(entity);
        }
        public void DiscardOneLink(Link entity)
        {
            linkDAO.MakeTransient(entity);
        }
        public IList<Link> ShowAllLinks(string where, string orderBy)
        {
            Link entity = new Link();
            return linkDAO.GetAll(entity, where, orderBy);
        }
    }
}
