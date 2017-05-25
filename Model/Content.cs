using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Content
    {
        public Content()
        {
        }
        private string _id = Guid.NewGuid().ToString();
        //private string _cid = "";
        private Category _cid;
        private string _ctitle = "";
        private string _title = "";
        private string _intro = "";
        private string _author = "";
        private string _from="";
        private string _content="";
        private DateTime _time = DateTime.Now;
        private int _viewnums = 11;
        private int _isshow = 0;
        private int _istop = 0;
        private string _order = "0";
        private string _tag = "";

        //public virtual string L_ID
        public virtual string L_ID
        {
            get { return _id; }
            set { _id = value; }
        }
        //public virtual string L_CID
        public virtual Category L_CID
        {
            get { return _cid; }
            set { _cid = value; }
        }
        public virtual string L_CTitle
        {
            get { return _ctitle; }
            set { _ctitle = value; }
        }
        public virtual string L_Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public virtual string L_Intro
        {
            get { return _intro; }
            set { _intro = value; }
        }
        public virtual string L_Author
        {
            get { return _author; }
            set { _author = value; }
        }
        public virtual string L_From
        {
            get { return _from; }
            set { _from = value; }
        }
        public virtual string L_Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public virtual DateTime L_PostTime
        {
            get { return _time; }
            set { _time = value; }
        }
        public virtual int L_ViewNums
        {
            get { return _viewnums; }
            set { _viewnums = value; }
        }
        public virtual int L_IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }
        public virtual int L_IsTop
        {
            get { return _istop; }
            set { _istop = value; }
        }
        public virtual string L_comorder
        {
            get { return _order; }
            set { _order = value; }
        }
        public virtual string L_tag
        {
            get { return _tag; }
            set { _tag = value; }
        }
    }
}
