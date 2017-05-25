using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Link
    {
        public Link()
        {
        }
        private string _id = Guid.NewGuid().ToString();
        private string _name = "";
        private string _url = "";
        private string _image = "";
        private string _order = "0";
        private int _isshow = 0;

        public virtual string L_ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual string L_Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual string L_Url
        {
            get { return _url; }
            set { _url = value; }
        }
        public virtual string L_Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public virtual string L_Order
        {
            get { return _order; }
            set { _order = value; }
        }
        public virtual int L_IsShow
        {
            get { return _isshow; }
            set { _isshow = value; }
        }
    }
}
