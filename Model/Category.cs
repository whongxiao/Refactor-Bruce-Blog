using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Category
    {
        public Category()
        {
        }
        private string _id = Guid.NewGuid().ToString();
        private string _name = "";
        private string _order = "0";
        private string _intro = "";
        private string _url = "";
        private DateTime _time = DateTime.Now;

        public virtual string C_ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual string C_Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual string C_Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public virtual string C_Intro
        {
            get { return _intro; }
            set { _intro = value; }
        }
        public virtual string C_Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public virtual DateTime C_Time
        {
            get { return _time; }
            set { _time = value; }
        }
    }
}
