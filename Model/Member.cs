using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Member
    {
        public Member()
        {
        }
        private string _id = Guid.NewGuid().ToString();
        private string _name = "";
        private string _password = "";
        private int _sex = 0;
        private string _email = "";
        private string _qq = "";
        private string _homepage = "";
        private DateTime _time = DateTime.Now;
        private string _ip = "";
        private string _intro = "";
        private int _staus = 0;
        private string _type = "0";
        public virtual string M_ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public virtual string M_Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public virtual string M_Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public virtual int M_Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        public virtual string M_Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public virtual string M_QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        public virtual string M_HomePage
        {
            get { return _homepage; }
            set { _homepage = value; }
        }
        public virtual DateTime M_RegTime
        {
            get { return _time; }
            set { _time = value; }
        }
        public virtual string M_RegIP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public virtual string M_Intro
        {
            get { return _intro; }
            set { _intro = value; }
        }
        public virtual int M_staus
        {
            get { return _staus; }
            set { _staus = value; }
        }
        public virtual string M_type
        {
            get { return _type; }
            set { _type = value; }
        }
    }
}
