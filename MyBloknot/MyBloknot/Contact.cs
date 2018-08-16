using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyBloknot
{
    class Contact
    {
        public string Name { get; set; }
        public string SirName { get; set; }
        public string[] Emails;
        public int emailquantity;
        public string[] PhoneNumbers;
        public int phonenumberquantity;


        public Contact() 
        {
            Emails = new string[1000];
            PhoneNumbers = new string[1000];
            emailquantity = 0;
            phonenumberquantity = 0;
        }

        //public Contact(string name , string sirname)
        //{
        //    Name = name;
        //    SirName = sirname;
        //    Emails = new string[1000];
        //    emailquantity = 0;
        //    PhoneNumbers = new string[1000];
        //    phonenumberquantity = 0;
        //}

    }
}
