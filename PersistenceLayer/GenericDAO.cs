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
using System.Text;
using NHibernate;
using NHibernateUtility;
using Model;
namespace PersistenceLayer
{
    public class GenericDAO<T,ID>:IGenericDAO<T,ID>
    {
        private ISession session;
        public ISession Session
        {
            get
            {
                if(session==null)
                {
                    session = NHibernateSessionHelper.GetCurrentSession();
                }
                return session;
            }
            set { session = value; }
        }
        T IGenericDAO<T, ID>.FindById(ID id)
        {
            return Session.Load<T>(id);
        }
        T IGenericDAO<T, ID>.FindByIdAndLock(ID id)
        {
            return Session.Load<T>(id, NHibernate.LockMode.Upgrade);
        }
        IList<T> IGenericDAO<T, ID>.FindAll()
        {
            string entityName = typeof(T).ToString();
            IQuery query = Session.CreateQuery("from " + entityName);
            return query.List<T>();
        }
        IList<T> IGenericDAO<T, ID>.GetAll(T entity, string where, string orderBy)
        {
            string entityName = entity.ToString();
            string sqlString = "from " + entityName;
            if (!String.IsNullOrEmpty(where) && where != "")
                sqlString += " where " + where;
            if (!String.IsNullOrEmpty(orderBy) && orderBy != "")
                sqlString += " order by " + orderBy;
            IQuery query = Session.CreateQuery(sqlString);
            return query.List<T>();
        }
        T IGenericDAO<T, ID>.MakePersistent(T entity)
        {
            Session.Save(entity);
            Session.Transaction.Commit();
            return entity;
        }
        T IGenericDAO<T, ID>.UpDate(T entity)
        {
            Session.Update(entity);
            Session.Transaction.Commit();
            return entity;
        }
        void IGenericDAO<T, ID>.MakeTransient(T entity)
        {
            Session.Delete(entity);
            Session.Transaction.Commit();
        }

    }
}
