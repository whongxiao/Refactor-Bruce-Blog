using System;
using System.Collections.Generic;
using System.Text;

namespace StringHandling
{
    /// <summary>
    /// 字符串相关处理
    /// </summary>
    public class String
    {
        public static string login = System.Configuration.ConfigurationSettings.AppSettings["login"].ToString();
        public static string miaoshu = System.Configuration.ConfigurationSettings.AppSettings["miaoshu"].ToString();
        public static string keyword = System.Configuration.ConfigurationSettings.AppSettings["keyword"].ToString();

        public static string cutstring(string str, int i)
        {
            if (str.Length > i)
                str = str.Substring(0, i);
            return str;
        }

        /// <summary>
        /// 对查询字符串进行过滤
        /// </summary>
        /// <param name="strKeyWords">要被过滤的查询字符串</param>
        /// <returns>过滤后的字符串</returns>
        public static string SqlQueryEncode(string strKeyWords)
        {
            if (!System.String.IsNullOrEmpty(strKeyWords) && strKeyWords != "")
            {
                strKeyWords = strKeyWords.Replace("'", "");
                strKeyWords = strKeyWords.Replace("[", "[[]");
                strKeyWords = strKeyWords.Replace("_", "[_]");
                strKeyWords = strKeyWords.Replace("&", "[&]");
                strKeyWords = strKeyWords.Replace("#", "[#]");
                strKeyWords = strKeyWords.Replace("%", "[%]");
            }
            return strKeyWords;
        }

        /// <summary>
        /// 对输入框的特殊字串进行过滤，防止SQL注入
        /// </summary>
        /// <param name="strFromText">要被过滤的字符串</param>
        /// <returns>过滤后的字符串</returns>
        public static string SqlInsertEncode(string html)
        {
            if (!System.String.IsNullOrEmpty(html) && html != "")
            {
                System.Text.RegularExpressions.Regex regex1 =
                    new System.Text.RegularExpressions.Regex(@"<script[\s\S]+</script *>",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex2 =
                    new System.Text.RegularExpressions.Regex(@" href *= *[\s\S]*script *:",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex3 =
                    new System.Text.RegularExpressions.Regex(@" no[\s\S]*=",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex4 =
                    new System.Text.RegularExpressions.Regex(@"<iframe[\s\S]+</iframe *>",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex5 =
                    new System.Text.RegularExpressions.Regex(@"<frameset[\s\S]+</frameset *>",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex6 =
                            new System.Text.RegularExpressions.Regex(@"\<img[^\>]+\>",
                                System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex7 =
                    new System.Text.RegularExpressions.Regex(@"</p>",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex8 =
                    new System.Text.RegularExpressions.Regex(@"<p>",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                System.Text.RegularExpressions.Regex regex9 =
                    new System.Text.RegularExpressions.Regex(@"<[^>]*>",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                html = regex1.Replace(html, ""); //过滤<script></script>标记 
                html = regex2.Replace(html, ""); //过滤href=javascript: (<A>) 属性 
                html = regex3.Replace(html, " _disibledevent="); //过滤其它控件的on...事件 
                html = regex4.Replace(html, ""); //过滤iframe
                html = regex5.Replace(html, ""); //过滤frameset 
                html = regex6.Replace(html, ""); //过滤frameset
                html = regex7.Replace(html, ""); //过滤frameset
                html = regex8.Replace(html, ""); //过滤frameset
                html = regex9.Replace(html, "");
                html = html.Replace(" ", "");
                html = html.Replace("</strong>", "");
                html = html.Replace("<strong>", "");

                html = html.Replace("javascript", "java脚本");
                html = html.Replace("vbscript", "vb脚本");
                html = html.Replace("cookie", "小甜饼");
                html = html.Replace("document", "文档");

                html = html.Replace("!", "&#33;");
                html = html.Replace("@", "&#64;");
                html = html.Replace("$", "&#36;");
                html = html.Replace("*", "&#42;");
                html = html.Replace("(", "&#40;");
                html = html.Replace(")", "&#41;");
                html = html.Replace("-", "&#45;");
                html = html.Replace("+", "&#43;");
                html = html.Replace("=", "&#61;");
                html = html.Replace("|", "&#124;");
                html = html.Replace("\\", "&#92;");
                html = html.Replace("/", "&#47;");
                html = html.Replace(":", "&#58;");
                html = html.Replace("\"", "&#34;");
                html = html.Replace("'", "&#39;");
                html = html.Replace("<", "&#60;");
                html = html.Replace(" ", "&#32;");
                html = html.Replace(">", "&#62;");
                html = html.Replace(" ", "&#32;");
                html = html.Replace("<br/>", "\r\n");
            }

            return html;
        }

        /// <summary>
        /// 格式化从数据库中取出的字符串以显示到页面上
        /// </summary>
        /// <param name="strContent">从数据库中取出的字符串</param>
        /// <returns>可显示在页面上的字符串</returns>
        public static string HtmlShowEncode(string strContent)
        {
            if (!System.String.IsNullOrEmpty(strContent) && strContent != "")
            {
                strContent = strContent.Replace(" ", "&nbsp;");
                strContent = strContent.Replace("&#32;", "&nbsp;");
                strContent = strContent.Replace("\t", "&nbsp;&nbsp;");
                strContent = strContent.Replace("\r\n", "<br />");
                strContent = strContent.Replace("java脚本", "javascript");
                strContent = strContent.Replace("vb脚本", "vbscript");
                strContent = strContent.Replace("小甜饼", "cookie");
                strContent = strContent.Replace("文档", "document");

            }
            return strContent;
        }


        public static bool CheckBadQuery(string str)
        {
            // 整串字符对比方法
            string badword = ";|'|*|%| and |20%and20%| master |20%master20%|exec|insert|select|delete|count|chr|mid|truncate|char|declare|update";
            string[] badwordArry = badword.Split(new char[] { '|' });
            for (int i = 0; i < badwordArry.Length; i++)
            {
                string tempWord = badwordArry[i].Trim();
                if (str.IndexOf(tempWord) >= 1)
                    return false;
            }
            return true;
        }


    }
}
