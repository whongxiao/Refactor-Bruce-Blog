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
    public class CategoryBLL
    {
        private ICategoryDAO categoryDAO;
        public CategoryBLL()
        {
            DAOFactory daoFactory = new DAOFactory();
            categoryDAO = daoFactory.GetCategoryDAO();
        }
        public Category ViewOneCategory(string id)
        {
            return categoryDAO.FindById(id);
        }
        public void CreateOneCategory(Category entity)
        {
            categoryDAO.MakePersistent(entity);
        }
        public void ModifyOneCategory(Category entity)
        {
            categoryDAO.UpDate(entity);
        }
        public void DisCardOneCategory(Category entity)
        {
            categoryDAO.MakeTransient(entity);
        }
        public IList<Category> ViewAllCategory(string where, string orderBy)
        {
            Category tempCategory = new Category();
            return categoryDAO.GetAll(tempCategory, where, orderBy);
        }
    }
}
