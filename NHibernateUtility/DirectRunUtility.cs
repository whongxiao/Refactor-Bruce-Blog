using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using NHibernate;
namespace NHibernateUtility
{
    class DirectRunUtility
    {
        /// <summary>
        /// ������Ӧ���еļ�¼��
        /// </summary>
        /// <param name="session">ISession����������IDbConnection</param>
        /// <param name="tableName">���ݿ������</param>
        /// <param name="where">��ѯ����</param>
        /// <returns>���������ļ�¼����</returns>
        public static int GetRecordCount(ISession session, string tableName, string where)
        {
            int recordCount = 0;
            string query = "Select Count(*) From [" + tableName + "]";
            if (!String.IsNullOrEmpty(where) && where != "")
            {
                query += " Where " + where;
            }

            using (session)
            {
                IDbConnection conn = session.Connection;
                OleDbCommand cmd = new OleDbCommand();
                session.Transaction.Enlist(cmd);
                cmd.Connection = (OleDbConnection)conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;

                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    recordCount = Convert.ToInt32(dr[0]);
                }
            }

            return recordCount;
        }

        /// <summary>
        /// ִ��һ������Ҫ����ֵ�� SqlCommand ����
        /// </summary>
        /// <param name="session">ISession����������IDbConnection</param>
        /// <param name="tableName">���ݿ������</param>
        /// <returns>������Ӱ��ļ�¼����</returns>
        public static int ExecuteNonQuery(ISession session, string cmdText)
        {
            using (session)
            {
                IDbConnection conn = session.Connection;
                OleDbCommand cmd = new OleDbCommand();
                session.Transaction.Enlist(cmd);
                cmd.Connection = (OleDbConnection)conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = cmdText;

                int val = cmd.ExecuteNonQuery();
                return val;
            }
        }
    }
}
