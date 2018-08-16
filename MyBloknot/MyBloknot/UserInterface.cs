using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace MyBloknot
{
    class UserInterface
    {
        private User[] users;
        private int userquantity;

        public UserInterface()
        {
            userquantity = 0;
            users = new User[10000];
        } //ctor

        public void GetUsers()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Lenovo\Desktop\BloknotFiles\UserPersonalData");
            string datapath = @"C:\Users\Lenovo\Desktop\BloknotFiles\UserPersonalData\";
            userquantity = di.GetFiles().Length;
            if (userquantity == 0) return;
            for (int i = 0; i < userquantity; i++)
            {
                users[i] = new User(File.ReadLines(datapath + di.GetFiles()[i].Name).Skip(0).Take(1).First());
                users[i].Login = File.ReadLines(datapath + di.GetFiles()[i].Name).Skip(1).Take(1).First();
                users[i].Password = File.ReadLines(datapath + di.GetFiles()[i].Name).Skip(2).Take(1).First();
                int currentusercontactquantity = File.ReadAllLines(users[i].PathToContacts).Length;
                users[i].bloknot.contactquanity = currentusercontactquantity;
                for (int j = 0; j < currentusercontactquantity; j++)
                {
                    string data = File.ReadLines(users[i].PathToContacts).Skip(j).Take(1).First();
                    string[] parts = data.Split(',');
                    string getname = parts[0];
                    string getsirname = parts[1];
                    string[] getemails = parts[2].Split(';');
                    string[] getphone = parts[3].Split(';');
                    users[i].bloknot.contacts[j] = new Contact();
                    users[i].bloknot.contacts[j].Name = getname;
                    users[i].bloknot.contacts[j].SirName = getsirname;
                    for (int k = 0; k < getemails.Length; k++)
                    {
                        users[i].bloknot.contacts[j].Emails[k] = getemails[k];
                    }
                    users[i].bloknot.contacts[j].emailquantity = getemails.Length;
                    for (int k = 0; k < getphone.Length; k++)
                    {
                        users[i].bloknot.contacts[j].PhoneNumbers[k] = getphone[k];
                    }
                    users[i].bloknot.contacts[j].phonenumberquantity = getphone.Length;
                }
            }
        }

        public void UserVerification()
        {
            int a = 12121;
            while (a != -1)
            {
                if (userquantity == 0)
                {
                    Console.Clear();
                    Console.WriteLine("No users are created , press enter to create a user");
                    Console.ReadLine();
                    AddUser();
                }
                a = 111;
                Console.Clear();
                Console.WriteLine("Type 1 to choose a user !\nType 2 to add a user\nType 3 to exit");
                string op = Console.ReadLine();

                switch (op)
                {
                    case ("1"):
                        Console.Clear();
                        for (int i = 0; i < userquantity; i++)
                        {
                            Console.WriteLine($"User {i + 1} - {users[i].UserName}");
                        }
                        string usernuber = Console.ReadLine();
                        int unumber = int.Parse(usernuber);
                        User u;
                        Console.Write("Enter your login : ");
                        string login = Console.ReadLine();
                        Console.Write("Enter your password : ");
                        string password = Console.ReadLine();
                        while ((login != users[unumber - 1].Login) || (password != users[unumber - 1].Password))
                        {
                            Console.WriteLine("Incorrect login or password , Try again");
                            Console.Write("Enter your login : ");
                            login = Console.ReadLine();
                            Console.Write("Enter your password : ");
                            password = Console.ReadLine();
                        }
                        Console.WriteLine("Login and password are correct ! press enter to continue");
                        Console.ReadLine();
                        u = users[unumber - 1];
                        a = AskWhatToDo(u);
                        break;

                    case ("2"):
                        AddUser();
                        break;
                    case ("3"):
                        Console.WriteLine("Bye :)");
                        Console.ReadLine();
                        return;
                }
            }
        }

        public int AskWhatToDo(User u)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type 1 to view your contacts!");
                Console.WriteLine("Type 2 to add");
                Console.WriteLine("Type 3 to remove");
                Console.WriteLine("Type 4 to edit a contact !");
                Console.WriteLine("Type 5 to switch user !");
                Console.WriteLine("Type 6 to delete this account !");
                Console.WriteLine("Type 7 to exit");
                
                string a = Console.ReadLine();
                int a1 = int.Parse(a);
                while(a1 < 1 || a1 > 7)
                {
                    Console.WriteLine("Enter number between 1 and 7 !");
                    string again = Console.ReadLine();
                    a1 = int.Parse(again);
                }
                                
                switch (a1)
                {
                    case (1):
                        Console.Clear();
                        ViewContacts(u);
                        Console.WriteLine("\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    case (2):
                        Console.Clear();
                        Console.WriteLine("Type 1 to add a new contact\nType 2 to add an e-mail to an existing contact\nType 3 to add a phonennumber to an existing contact");
                        string option1 = Console.ReadLine();
                        switch (option1)
                        {
                            case ("1"):
                                Contact c = new Contact();
                                Console.Clear();
                                Console.Write("Enter the name : ");
                                string name = Console.ReadLine();
                                c.Name = name;

                                Console.Write("Enter the sirname : ");
                                string sirname = Console.ReadLine();
                                c.SirName = sirname;
                                Console.Write("Enter e-mails ... (type x if there is no other e-mail)\n");
                                while (true)
                                {
                                    Console.Write($"E-mail {c.emailquantity + 1} - ");
                                    string emails = Console.ReadLine();
                                    if (emails == "x") break;
                                    c.Emails[c.emailquantity] = emails;
                                    c.emailquantity++;
                                }
                                Console.Write("Enter phonenumbers ... (type x if there is no other phonenumber)\n");
                                while (true)
                                {
                                    Console.Write($"PhoneNumber {c.phonenumberquantity + 1} - ");
                                    string phonenumbers = Console.ReadLine();
                                    if (phonenumbers == "x") break;
                                    c.PhoneNumbers[c.phonenumberquantity] = phonenumbers;
                                    c.phonenumberquantity++;
                                }
                                Console.Clear();
                                Console.Write("New Contact aded ! Press enter to continue");
                                Console.ReadLine();
                                u.bloknot.Add( u, c , "addcontact" , "" , -1);
                                WriteInDoc(u);
                                break; 
                            case ("2"):
                                if (u.bloknot.contactquanity != 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("These are your contacts , for which one would you like to add e-mail ?");
                                    ViewContacts(u);
                                    string asd = Console.ReadLine();
                                    int currentcontactnumber = int.Parse(asd);
                                    while(currentcontactnumber < 1 || currentcontactnumber > u.bloknot.contactquanity)
                                    {
                                        Console.WriteLine("Wrong number ! enter correct number");
                                        string asd1 = Console.ReadLine();
                                        currentcontactnumber = int.Parse(asd1);
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Type the new e-mail !");
                                    string newemail = Console.ReadLine();
                                    u.bloknot.Add(u , u.bloknot.contacts[currentcontactnumber - 1], "addemail", newemail , currentcontactnumber);
                                    Console.WriteLine("E-mail is added !");
                                    WriteInDoc(u);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You dont have any contacts :( ");
                                    Console.ReadLine();
                                }
                                break;
                            case ("3"):
                                if (u.bloknot.contactquanity != 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("These are your contacts , for which one would you like to add a phonenumber ?");
                                    ViewContacts(u);
                                    string asd = Console.ReadLine();
                                    int currentcontactnumber = int.Parse(asd);
                                    while (currentcontactnumber < 1 || currentcontactnumber > u.bloknot.contactquanity)
                                    {
                                        Console.WriteLine("Wrong number ! enter correct number");
                                        string asd1 = Console.ReadLine();
                                        currentcontactnumber = int.Parse(asd1);
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Type the new phonenumber !");
                                    string newphonenumber = Console.ReadLine();
                                    u.bloknot.Add(u , u.bloknot.contacts[currentcontactnumber - 1], "addphonenumber", newphonenumber, currentcontactnumber);
                                    Console.WriteLine("Phonenumber is added !");
                                    WriteInDoc(u);
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You dont have any contacts :( ");
                                    Console.ReadLine();
                                }
                                break;
                        }                        
                        break;
                    case (3):
                        if (u.bloknot.contactquanity != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Type 1 to remove whole contact\nType 2 to remove a particular info of a contact");
                            string aa = Console.ReadLine();
                            int aaa = int.Parse(aa);
                            while(aaa != 1 && aaa != 2)
                            {
                                Console.WriteLine("Enter correct number !");
                                string aa1 = Console.ReadLine();
                                aaa = int.Parse(aa1);
                            }
                            switch (aaa)
                            {
                                case (1):
                                    Console.Clear();
                                    Console.WriteLine("These are your contacts .. Which one would you like to remove ? ");
                                    ViewContacts(u);
                                    string ar = Console.ReadLine();
                                    int currentcontactnumber = int.Parse(ar);
                                    while(currentcontactnumber < 1 || currentcontactnumber > u.bloknot.contactquanity)
                                    {
                                        Console.WriteLine("Enter correct number");
                                        string ar2 = Console.ReadLine();
                                        currentcontactnumber = int.Parse(ar2);
                                    }
                                    u.bloknot.RemoveContact( u , currentcontactnumber);
                                    WriteInDoc(u);
                                    Console.Clear();
                                    Console.WriteLine($"Contact {currentcontactnumber} is removed ! Press enter to continue");
                                    Console.ReadLine();
                                    break;
                                case (2):
                                    Console.Clear();
                                    Console.WriteLine("These are your contacts .. whose info would you like to remove  ? ");
                                    ViewContacts(u);
                                    string ac = Console.ReadLine();
                                    currentcontactnumber = int.Parse(ac);
                                    while (currentcontactnumber < 1 || currentcontactnumber > u.bloknot.contactquanity)
                                    {
                                        Console.WriteLine("Enter correct number");
                                        string ar22 = Console.ReadLine();
                                        currentcontactnumber = int.Parse(ar22);
                                    }
                                    int b1 = 2222;
                                    while (b1 != 5)
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Type 1 to remove name!\nType 2 to remove sirname!\nType 3 to remove e-mail!\nType 4 to remove phonenumber!\nType 5 to save !");
                                        string b = Console.ReadLine();
                                        b1 = int.Parse(b);
                                        switch (b1)
                                        {
                                            case (1):
                                                u.bloknot.RemoveParticularInfo(u,currentcontactnumber, b1,888);
                                                WriteInDoc(u);
                                                Console.WriteLine("The name is Removed !");
                                                Console.ReadLine();
                                                break;
                                            case (2):
                                                u.bloknot.RemoveParticularInfo(u,currentcontactnumber, b1,888);
                                                WriteInDoc(u);
                                                Console.WriteLine("The sirname is Removed !");
                                                Console.ReadLine();
                                                break;
                                            case (3):
                                                if (u.bloknot.contacts[currentcontactnumber - 1].emailquantity != 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Type 1 to remove all e-mails\nType 2 to remove a single e-mail");
                                                    string opt = Console.ReadLine();
                                                    switch (opt)
                                                    {
                                                        case ("1"):
                                                            u.bloknot.RemoveAllEmails(u,currentcontactnumber);
                                                            WriteInDoc(u);
                                                            Console.Clear();
                                                            Console.WriteLine("All e-mails are removed !");
                                                            Console.ReadLine();
                                                            break;
                                                        case ("2"):
                                                            Console.WriteLine("Which e-mail would you like to remove ?\n");
                                                            for (int i = 0; i < u.bloknot.contacts[currentcontactnumber - 1].emailquantity; i++)
                                                            {
                                                                Console.WriteLine($"E-mail {i + 1} - {u.bloknot.contacts[currentcontactnumber - 1].Emails[i]}");
                                                            }
                                                            string emailnumber1 = Console.ReadLine();
                                                            int emailnumber = int.Parse(emailnumber1);
                                                            u.bloknot.RemoveParticularInfo(u,currentcontactnumber, b1, emailnumber);
                                                            WriteInDoc(u);
                                                            Console.WriteLine("e-mail removed !");
                                                            Console.ReadLine();
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Current contact doesnt have e-mails :(");
                                                    Console.ReadLine();                                                    
                                                }
                                                break;
                                            case (4):
                                                if (u.bloknot.contacts[currentcontactnumber - 1].phonenumberquantity != 0)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Type 1 to remove all phonenumbers\nType 2 to remove a single phonenumber");
                                                    string opt = Console.ReadLine();
                                                    switch (opt)
                                                    {
                                                        case ("1"):
                                                            u.bloknot.RemoveAllPhoneNumbers(u,currentcontactnumber);
                                                            WriteInDoc(u);
                                                            Console.Clear();
                                                            Console.WriteLine("All phonenumbers are removed !");
                                                            Console.ReadLine();
                                                            break;
                                                        case ("2"):
                                                            Console.WriteLine("Which phonenumber would you like to remove ?\n");
                                                            for (int i = 0; i < u.bloknot.contacts[currentcontactnumber - 1].phonenumberquantity; i++)
                                                            {
                                                                Console.WriteLine($"Phonenumber {i + 1} - {u.bloknot.contacts[currentcontactnumber - 1].PhoneNumbers[i]}");
                                                            }
                                                            string ph1 = Console.ReadLine();
                                                            int phonnumbernumber = int.Parse(ph1);
                                                            u.bloknot.RemoveParticularInfo(u,currentcontactnumber, b1, phonnumbernumber);
                                                            WriteInDoc(u);
                                                            Console.WriteLine("Phonenumber is removed !");
                                                            Console.ReadLine();
                                                            break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Current contact doesnt have phonenumbers :(");
                                                    Console.ReadLine();
                                                }
                                                break;
                                            case (5):
                                                Console.WriteLine("Contact saved ! Press enter to continue");
                                                Console.ReadLine();
                                                break;
                                        }
                                        
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You have no contacts ! Press enter to continue");
                            Console.ReadLine();
                        }
                        break;

                    case (4):
                        if(u.bloknot.contactquanity != 0)
                        {
                            Console.Clear();
                            Console.WriteLine("These are your contacts .. Which one would you like to edit ? \n");
                            ViewContacts(u);
                            string f = Console.ReadLine();
                            int currentcontactnumber = int.Parse(f);
                            while (currentcontactnumber < 1 || currentcontactnumber > u.bloknot.contactquanity)
                            {
                                Console.WriteLine("Enter correct number");
                                string f2 = Console.ReadLine();
                                currentcontactnumber = int.Parse(f2);
                            }
                            int op = 12312;
                            while (op != 5)
                            {
                                Console.Clear();
                                Console.WriteLine("Type 1 to change Name\nType 2 to change sirname\nType 3 to change E-mails\nType 4 to change phonenumber\nType 5 to save");
                                string option = Console.ReadLine();
                                op = int.Parse(option);
                                while (op < 1 || op > 5)
                                {
                                    Console.WriteLine("Enter correct number");
                                    string opt = Console.ReadLine();
                                    op = int.Parse(opt);
                                }
                                switch (op)
                                {
                                    case (1):
                                        Console.Clear();
                                        Console.Write("Type the new name : ");
                                        string newname = Console.ReadLine();
                                        u.bloknot.EditContact(u,currentcontactnumber, op,777, newname);
                                        WriteInDoc(u);
                                        Console.WriteLine("The name is changed ! ");
                                        Console.ReadLine();
                                        break;

                                    case (2):
                                        Console.Clear();
                                        Console.Write("Type the new sirname : ");
                                        string newsirname = Console.ReadLine();
                                        u.bloknot.EditContact(u,currentcontactnumber, op, 777, newsirname);
                                        WriteInDoc(u);
                                        Console.WriteLine("The sirname is changed ! ");
                                        Console.ReadLine();
                                        break;
                                    case (3):
                                        if (u.bloknot.contacts[currentcontactnumber - 1].emailquantity != 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Which e-mail would you like to edit ? \n");
                                            for (int i = 0; i < u.bloknot.contacts[currentcontactnumber - 1].emailquantity; i++)
                                            {
                                                Console.WriteLine($"E-mail {i + 1} - {u.bloknot.contacts[currentcontactnumber - 1].Emails[i]}");
                                            }
                                            string em = Console.ReadLine();
                                            int emailnumber = int.Parse(em);
                                            Console.Clear();
                                            Console.WriteLine("Type the new e-mail");
                                            string newemail = Console.ReadLine();
                                            u.bloknot.EditContact(u,currentcontactnumber, 3, emailnumber, newemail);
                                            WriteInDoc(u);
                                            Console.WriteLine("E-mail is changed !");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Chosen contact doesnt have e-mails :(");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case (4):
                                        if (u.bloknot.contacts[currentcontactnumber - 1].phonenumberquantity != 0)
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Which phonenumber would you like to edit ? \n");
                                            for (int i = 0; i < u.bloknot.contacts[currentcontactnumber - 1].phonenumberquantity; i++)
                                            {
                                                Console.WriteLine($"Phonenumber {i + 1} - {u.bloknot.contacts[currentcontactnumber - 1].PhoneNumbers[i]}");
                                            }
                                            string em = Console.ReadLine();
                                            int phonenumbernumber = int.Parse(em);
                                            Console.Clear();
                                            Console.WriteLine("Type the new phonenumber");
                                            string newnumber = Console.ReadLine();
                                            u.bloknot.EditContact(u,currentcontactnumber, 4 , phonenumbernumber, newnumber);
                                            WriteInDoc(u);
                                            Console.WriteLine("Phonenumber is changed !");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Chosen contact doesnt have phonenumbers :( ");
                                            Console.ReadLine();
                                        }
                                        break;
                                    case (5):
                                        Console.Clear();
                                        Console.WriteLine("The contact is saved !");
                                        Console.ReadLine();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You have no contacts ! Press enter to continue");
                            Console.ReadLine();
                        }
                        break;
                    case (5):
                        UserVerification();
                        break;
                    case (6):
                        Console.Clear();
                        Console.WriteLine("Are you shure you want to DELETE this account ?\nType d to delete\nType c to cancel");
                        string ans = Console.ReadLine();
                        DeleteUser(u, ans);
                        return 0;
                    case (7):
                        Console.Clear();
                        Console.WriteLine($"Bye :) ");
                        return -1;
                }
            }
        }

        public void Start()
        {
            GetUsers();            
            try
            {
                UserVerification();
            }
            catch (FormatException)
            {
                Console.WriteLine("You should have entered something reasonable ,, bye !!");
            }
            //catch (Exception e)
            //{
            //    Console.WriteLine("Something bad happened :(");
            //    Console.WriteLine($"{e.Message}\n\n");
            //    Console.WriteLine(e.StackTrace);
            //}
        }

        public void ViewContacts(User u)
        {
            if(u.bloknot.contactquanity == 0)
            {
                Console.WriteLine("You don`t have any contacts :( ");
                return;
            }
            for (int i = 0; i < u.bloknot.contactquanity; i++)
            {
                Console.WriteLine($"Contact {i + 1} : Name    - {u.bloknot.contacts[i].Name}");
                Console.WriteLine($"            Sirname - {u.bloknot.contacts[i].SirName}");
                Console.WriteLine($"            E-mails `");
                for (int j = 0; j < u.bloknot.contacts[i].emailquantity; j++)
                {
                    Console.WriteLine($"                      {j + 1} - {u.bloknot.contacts[i].Emails[j]}");
                }
                Console.WriteLine($"            PhoeNumbers `");
                for (int j = 0; j < u.bloknot.contacts[i].phonenumberquantity; j++)
                {
                    Console.WriteLine($"                      {j + 1} - {u.bloknot.contacts[i].PhoneNumbers[j]}");
                }
            }
        }

        public void WriteInDoc(User u)
        {
            using(StreamWriter sw = new StreamWriter(u.PathToContacts))
            {
                //sw.AutoFlush = true;
                for (int i = 0; i < u.bloknot.contactquanity; i++)
                {
                    sw.Write(u.bloknot.contacts[i].Name + ",");
                    sw.Write(u.bloknot.contacts[i].SirName + ",");
                    for (int j = 0; j < u.bloknot.contacts[i].emailquantity; j++)
                    {
                        if(j == u.bloknot.contacts[i].emailquantity - 1)
                        {
                            sw.Write(u.bloknot.contacts[i].Emails[j] + ",");
                        }
                        else
                        {
                            sw.Write(u.bloknot.contacts[i].Emails[j] + ";");
                        }
                        
                    }
                    for (int j = 0; j < u.bloknot.contacts[i].phonenumberquantity; j++)
                    {
                        if (j == u.bloknot.contacts[i].phonenumberquantity - 1)
                        {
                            sw.Write(u.bloknot.contacts[i].PhoneNumbers[j]);
                        }
                        else
                        {
                            sw.Write(u.bloknot.contacts[i].PhoneNumbers[j] + ";");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }

        public void AddUser()
        {
            bool IsUserCreated = false;
            Console.Clear();
            Console.Write("Enter username : ");
            string name = Console.ReadLine();
            for (int i = 0; i < userquantity; i++)
            {
                if (name == users[i].UserName) IsUserCreated = true;
            }
            while (IsUserCreated == true)
            {
                IsUserCreated = false;
                Console.WriteLine("Such user is already created , type another name");
                name = Console.ReadLine();
                for (int i = 0; i < userquantity; i++)
                {
                    if (name == users[i].UserName) IsUserCreated = true;
                }
            }
            Console.Write("Enter login : ");
            string log = Console.ReadLine();
            Console.Write("Enter password : ");
            string pass = Console.ReadLine();

            User u = new User(name);
            u.Login = log;
            u.Password = pass;

            users[userquantity] = u;
            userquantity++;

            Console.WriteLine("New User Added  ! ");
            using(StreamWriter sw = new StreamWriter(u.PathToPersonalData))
            {
                sw.AutoFlush = true;
                sw.WriteLine(u.UserName);
                sw.WriteLine(u.Login);
                sw.WriteLine(u.Password);
            }
            File.Create(u.PathToContacts);
            Console.ReadLine();
        }

        public void DeleteUser(User u , string ans)
        {
            int usernumber = -1;
            for (int i = 0; i < userquantity; i++)
            {
                if(u == users[i])
                {
                    usernumber = i;
                    break;
                }
            }
            switch (ans)
            {
                case ("d"):
                    File.Delete(users[usernumber].PathToContacts);
                    File.Delete(users[usernumber].PathToPersonalData);
                    for (int i = usernumber; i < userquantity - 1; i++)
                    {
                        users[i] = users[i + 1];
                    }
                    users[userquantity - 1] = null;
                    userquantity--;
                    Console.WriteLine("Account successfully deleted !");
                    Console.ReadLine();
                    break;
            }
        }
    }
}