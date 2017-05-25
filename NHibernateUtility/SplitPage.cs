using System;
using System.Text;

namespace NHibernateUtility
{
    public static class SplitPage
    {
        /// <summary>
        /// ��ȡ������ʾ��ҳ������ַ���
        /// </summary>
        /// <param name="pageIndex">��ǰҳ</param>
        /// <param name="pageSize">ÿҳ��</param>
        /// <param name="recordCount">��¼����</param>
        /// <param name="urlFormat">urlFormat ��ʾҳ���ַ������ ��$�� �����滻��ҳ��</param>
        /// <param name="mode">��ҳ��ʽ</param>
        /// <returns>���� string ���ͣ���ʾ��ҳ���</returns>
        public static string GetPageSet(int pageIndex, int pageSize, int recordCount, string urlFormat, int mode)
        {
            string pageSet;
            switch (mode)
            {
                case 0:
                    pageSet = GetPageSet0(pageIndex, pageSize, recordCount, urlFormat);
                    break;
                case 1:
                    pageSet = GetPageSet1(pageIndex, pageSize, recordCount, urlFormat);
                    break;
                default:
                    pageSet = GetPageSet0(pageIndex, pageSize, recordCount, urlFormat);
                    break;
            }
            return pageSet;
        }

        private static string GetPageSet0(int pageIndex, int pageSize, int recordCount, string urlFormat)
        {
            int pageCount;
            pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;
            if (pageCount <= 1)
            {
                return "";
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }

            string[] urlFormatAry = urlFormat.Split('$');

            StringBuilder pageSet = new StringBuilder(800);
            pageSet.Append("��" + recordCount + "�� | ");
            pageSet.Append("ÿҳ" + pageSize + "�� | ");
            pageSet.Append("��Ϊ" + pageIndex + "/" + pageCount + "ҳ | ");
            if (pageIndex <= 1)
            {
                pageSet.Append("��ҳ | ��ҳ | ");
            }
            else
            {
                pageSet.Append("<a href=\"" + urlFormatAry[0] + "1" + urlFormatAry[1] + "\">��ҳ</a> | ");
                pageSet.Append("<a href=\"" + urlFormatAry[0] + (pageIndex - 1).ToString() + urlFormatAry[1] + "\">��ҳ</a> | ");
            }
            if (pageIndex >= pageCount)
            {
                pageSet.Append("��ҳ | βҳ | ");
            }
            else
            {
                pageSet.Append("<a href=\"" + urlFormatAry[0] + (pageIndex + 1).ToString() + urlFormatAry[1] + "\">��ҳ</a> | ");
                pageSet.Append("<a href=\"" + urlFormatAry[0] + pageCount.ToString() + urlFormatAry[1] + "\">βҳ</a> | ");
            }
            pageSet.Append("ת�� <input id=\"Paging_PageIndex_Text\" name=\"Paging_PageIndex_Text\" type=\"text\" value=\"" + pageIndex + "\" maxlength=\"10\" size=\"3\" /> ҳ ");
            pageSet.Append("<input id=\"Paging_PageIndex_Button\" name=\"Paging_PageIndex_Button\" type=\"button\" value=\"GO\" onclick=\"javascript: document.location.href = '" + urlFormatAry[0] + "' + document.getElementById('Paging_PageIndex_Text').value + '" + urlFormatAry[1] + "';\" />");

            return pageSet.ToString();
        }

        private static string GetPageSet1(int pageIndex, int pageSize, int recordCount, string urlFormat)
        {
            int pageCount, groupNum, pageNum, startPageNum, endPageNum;
            pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;
            if (pageCount <= 1)
            {
                return "";
            }
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
            }
            groupNum = 8;
            pageNum = pageIndex % groupNum == 0 ? pageIndex / groupNum : pageIndex / groupNum + 1;
            startPageNum = pageNum * groupNum - (groupNum - 1);
            endPageNum = pageNum * groupNum;
            if (pageCount < endPageNum)
            {
                endPageNum = pageCount;
            }

            string[] urlFormatAry = urlFormat.Split('$');
            StringBuilder pageSet = new StringBuilder(800);

            pageSet.Append("<ul id=\"pageSet\">");

            //����ͷ
            if (startPageNum > groupNum)
            {
                pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex - groupNum).ToString() + urlFormatAry[1] + "\">&lt;&lt;</a></li>");
            }
            if (pageIndex > 1)
            {
                pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex - 1).ToString() + urlFormatAry[1] + "\">&lt;</a></li>");
            }
            //�м�����
            for (int i = startPageNum; i <= endPageNum; i++)
            {
                if (pageIndex == i)
                {
                    pageSet.Append("<li ><a >" + i + "</a></li>");
                }
                else
                {
                    pageSet.Append("<li><a href=\"" + urlFormatAry[0] + i.ToString() + urlFormatAry[1] + "\">" + i + "</a></li>");
                }
            }
            //�Ҳ��ͷ
            if (pageIndex < pageCount)
            {
                pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex + 1).ToString() + urlFormatAry[1] + "\">&gt;</a></li>");
            }
            if (endPageNum < pageCount)
            {
                pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex + groupNum).ToString() + urlFormatAry[1] + "\">&gt;&gt;</a></li>");
            }

            pageSet.Append("</ul>");

            return pageSet.ToString();
        }
    }
}
