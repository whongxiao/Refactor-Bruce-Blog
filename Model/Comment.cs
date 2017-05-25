using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Comment
    {
        public Comment()
        {
        }
        private string _id = Guid.NewGuid().ToString();
        //private string _bid = "";
        private Content _bid;//2009/12/13 replaced 1 row above by whx利用many-to-one关联来实现
        private string _btitle = "";
        private string _mid = "";
        private string _content = "";
        private string _author = "";
        private DateTime _date = DateTime.Now;
        private string _ip = "";

        public virtual string C_ID
        {
            get { return _id; }
            set { _id = value; }
        }

        //public virtual string B_ID
        public virtual Content B_ID
        {
            get { return _bid; }
            set { _bid = value; }
        }

        public virtual string B_Title
        {
            get { return _btitle; }
            set { _btitle = value; }
        }

        public virtual string M_ID
        {
            get { return _mid; }
            set { _mid = value; }
        }

        public virtual string C_Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public virtual string C_Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public virtual DateTime C_PostTime
        {
            get { return _date; }
            set { _date = value; }
        }

        public virtual string C_PostIP
        {
            get { return _ip; }
            set { _ip = value; }
        }
    }
}
