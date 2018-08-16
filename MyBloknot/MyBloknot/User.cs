using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyBloknot
{
    class User
    {
        public string UserName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PathToContacts { get; set; }
        public string PathToPersonalData { get; set; }
        public Bloknot bloknot;

        public User(string name)
        {
            UserName = name;
            bloknot = new Bloknot();
            PathToContacts = @"C:\\Users\Lenovo\Desktop\BloknotFiles\UserContacts\" + UserName + " `s Contacts.txt";
            PathToPersonalData = @"C:\\Users\Lenovo\Desktop\BloknotFiles\UserPersonalData\" + UserName + " `s Data.txt"; ;
        }
    }
}
