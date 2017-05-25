using System;
using System.Collections.Generic;
using System.Text;

namespace StringHandling
{
    /// <summary>
    /// 整数或数字相关字符串处理
    /// </summary>
    public class Integer
    {
        /// <summary>
        /// 判断传入的字符串是否是为整数
        /// </summary>
        /// <param name="strContent">待判断的字符串</param>
        /// <returns>判断结果</returns>
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
        /// 将传入的字符串转换为整数，如果不是则返回默认值
        /// </summary>
        /// <param name="strContent">待转换的字符串</param>
        /// <param name="defaultValue">转换失败的默认值</param>
        /// <returns>判断结果</returns>
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
