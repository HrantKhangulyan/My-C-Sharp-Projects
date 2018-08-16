using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyBloknot
{
    class Bloknot
    {
        public Contact[] contacts;
        public int contactquanity;

        public Bloknot()
        {
            contacts = new Contact[1000000];
            contactquanity = 0;
        }

        public void Add(User u , Contact c , string Case , string input , int which)
        {
            switch (Case)
            {
                case ("addcontact"):
                    u.bloknot.contacts[u.bloknot.contactquanity] = c;
                    u.bloknot.contactquanity++;
                    break;
                case ("addemail"):
                    if(u.bloknot.contacts[which - 1].Emails == null)
                    {
                        u.bloknot.contacts[which - 1].Emails = new string[1000];
                    }
                    u.bloknot.contacts[which -1].Emails[u.bloknot.contacts[which-1].emailquantity] = input;
                    u.bloknot.contacts[which -1].emailquantity++;
                    break;
                case ("addphonenumber"):
                    if (u.bloknot.contacts[which - 1].PhoneNumbers == null)
                    {
                        u.bloknot.contacts[which - 1].PhoneNumbers = new string[1000];
                    }
                    u.bloknot.contacts[which-1].PhoneNumbers[u.bloknot.contacts[which-1].phonenumberquantity] = input;
                    u.bloknot.contacts[which-1].phonenumberquantity++;
                    break;
            }
        }

        public void RemoveContact(User u, int contactnumber)
        {   
            for (int i = contactnumber - 1; i < u.bloknot.contactquanity - 1; i++)
            {
                u.bloknot.contacts[i] = u.bloknot.contacts[i + 1];
            }
            u.bloknot.contacts[u.bloknot.contactquanity - 1] = null;
            u.bloknot.contactquanity--;                       
        }

        public void RemoveParticularInfo(User u , int contactnumber, int whattoremove , int number)
        {                
            switch (whattoremove)
            {
                case (1):
                    u.bloknot.contacts[contactnumber - 1].Name = "";
                    break;
                case (2):
                    u.bloknot.contacts[contactnumber - 1].SirName = "";
                    break;
                case (3):
                    for (int i = number - 1; i < u.bloknot.contacts[contactnumber-1].emailquantity - 1; i++)
                    {
                        u.bloknot.contacts[contactnumber - 1].Emails[i] = u.bloknot.contacts[contactnumber - 1].Emails[i + 1];
                    }
                    u.bloknot.contacts[contactnumber - 1].Emails[u.bloknot.contacts[contactnumber - 1].emailquantity - 1] = null;
                    u.bloknot.contacts[contactnumber - 1].emailquantity--;
                    break;
                case (4):
                    for (int i = number - 1; i < u.bloknot.contacts[contactnumber - 1].phonenumberquantity - 1; i++)
                    {
                        u.bloknot.contacts[contactnumber - 1].PhoneNumbers[i] = u.bloknot.contacts[contactnumber - 1].PhoneNumbers[i + 1];
                    }
                    u.bloknot.contacts[contactnumber - 1].PhoneNumbers[u.bloknot.contacts[contactnumber - 1].phonenumberquantity - 1] = null;
                    u.bloknot.contacts[contactnumber - 1].phonenumberquantity--;
                    break;
            }            
        }

        public void RemoveAllEmails(User u , int contactnumber)
        {
            u.bloknot.contacts[contactnumber -1].Emails = null;
            u.bloknot.contacts[contactnumber -1].emailquantity = 0;
        }

        public void RemoveAllPhoneNumbers(User u, int contactnumber)
        {
            u.bloknot.contacts[contactnumber - 1].PhoneNumbers = null;
            u.bloknot.contacts[contactnumber - 1].phonenumberquantity = 0;
        }

        public void EditContact(User u , int contactnumber, int whattochange, int number, string input)
        {               
            switch (whattochange)
            {                        
                case (1):
                    u.bloknot.contacts[contactnumber - 1].Name = input;
                    break;
                case (2):
                    u.bloknot.contacts[contactnumber - 1].SirName = input;
                    break;
                case (3):
                    u.bloknot.contacts[contactnumber - 1].Emails[number - 1] = input;
                    break;
                case (4):
                    u.bloknot.contacts[contactnumber - 1].PhoneNumbers[number - 1] = input;
                    break;
            }
        }
    }
}
