using System;
using System.Collections.Generic;
using System.Text;

namespace StringHandling
{
    /// <summary>
    /// ��������������ַ�������
    /// </summary>
    public class Integer
    {
        /// <summary>
        /// �жϴ�����ַ����Ƿ���Ϊ����
        /// </summary>
        /// <param name="strContent">���жϵ��ַ���</param>
        /// <returns>�жϽ��</returns>
        public static bool IsInteger(string strContent)
        {
            bool IsInt = false;
            int result;

            if (!System.String.IsNullOrEmpty(strContent))
            {
                IsInt = int.TryParse(strContent, out result);
            }

            return IsInt;
        }

        /// <summary>
        /// ��������ַ���ת��Ϊ��������������򷵻�Ĭ��ֵ
        /// </summary>
        /// <param name="strContent">��ת�����ַ���</param>
        /// <param name="defaultValue">ת��ʧ�ܵ�Ĭ��ֵ</param>
        /// <returns>�жϽ��</returns>
        public static int GetInteger(string strContent, int defaultValue)
        {
            int result = defaultValue;

            if (!System.String.IsNullOrEmpty(strContent))
            {
                bool isInt = int.TryParse(strContent, out result);

                if (!isInt)
                {
                    result = defaultValue;
                }
            }

            return result;
        }
    }
}
