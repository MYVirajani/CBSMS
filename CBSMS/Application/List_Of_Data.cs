using CBSMS.models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CBSMS
{
    public static class List_Of_Data
    {
        public static List<StudentUser> users = new List<StudentUser>();
         public static int studentId= 1001;


        public static void Add_User()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Enter User Id: {studentId} ");

            Console.CursorVisible = true;
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Date of Birth DD/MM/YEAR: ");
            string dateOfBirth = Console.ReadLine();

            while (IsvalidDate(dateOfBirth) == false)
            {
                Console.WriteLine("This not a valid date.\a ");
                Console.Write("Enter Date of Birth Again: ");
                string DOB = Console.ReadLine();
                dateOfBirth = DOB;
            }

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            StudentUser user = new StudentUser(studentId, firstName, lastName, dateOfBirth, address);
            users.Add(user);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            studentId++;
        }

        
       
   
        public static void Display_Modules()
        {
            Console.WriteLine("Available Modules are:");
            Console.WriteLine("* EE3305 - Signals and Systems ");
            Console.WriteLine("* EE3301 - Analog Electronics");
            Console.WriteLine("* EE3302 - Data Structures and Algorithems");
            Console.WriteLine("* EE3203 - Electrical and Electronic Measurements");
            Console.WriteLine("* EE3251 - GUI Prgramming");
            Console.WriteLine("* EE3250 - Programming  Project");

        }

        public static void Create_Modules(int uID,int modId)
        {
        
            foreach (var user in users)
            {
               
                if(user.Id == uID){ 
                   
                    switch (modId)
                    {
                        case 3305:
                            Module SAS = new Module(3305, "Signals and Systems", 3);
                            user.Modules.Add(SAS);
                            Console.WriteLine($"Module {modId}-{SAS.Name} is registered.");
                            break;
                        case 3301:
                            Module AE = new Module(3301, "Analog Electronics", 3);
                            Console.WriteLine($"Module {modId}-{AE.Name} is registered.");
                            user.Modules.Add(AE);
                            
                            break;
                        case 3302:
                            Module DSA = new Module(3302, "Data Structures and Algorithems", 3);
                            user.Modules.Add(DSA);
                            Console.WriteLine($"Module {modId}-{DSA.Name} is registered.");
                            break;
                        case 3203:
                            Module EEM = new Module(3203, "Electrical and Electronic Measurements", 2);
                            user.Modules.Add(EEM);
                            Console.WriteLine($"Module {modId}-{EEM.Name} is registered.");
                            break;
                        case 3251:
                            Module GUI = new Module(3251, "GUI Prgramming", 2);
                            user.Modules.Add(GUI);
                            Console.WriteLine($"Module {modId}-{GUI.Name} is registered.");
                            break;
                        case 3250:
                            Module PP = new Module(3250, "Programming  Project", 3);
                            user.Modules.Add(PP);
                            Console.WriteLine($"Module {modId}-{PP.Name} is registered.");
                            break;
                        
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Module Id!\a");

                            break;


                    }
                    break;
                }
            }
            
        }
        
        
        public static void Display_RegModules(StudentUser user_mod)
        {
            Console.SetCursorPosition(80, 0);
            int i = 1;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("| ->>>Registered Modules are :");
            foreach (var mod in user_mod.Modules)
            {
                Console.SetCursorPosition(80, i);
                Console.WriteLine($"| * {mod.Id} {mod.Name}");
                i=i+1;
            }
            Console.SetCursorPosition(2, 0);
           

        }


        public static void Print_Users()
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            int i = 1;
     
            Console.SetCursorPosition(10, i);
            Console.WriteLine("Id");
            Console.SetCursorPosition(25, i);
            Console.WriteLine("First Name");
            Console.SetCursorPosition(40, i);
            Console.WriteLine("Last Name");
            Console.SetCursorPosition(55, i);
            Console.WriteLine("Date of Birth");
            Console.SetCursorPosition(80, i);
            Console.WriteLine("Address");
            Console.SetCursorPosition(100, i);
            Console.WriteLine("GPA Value");
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (var user in users)
            {
                Console.SetCursorPosition(10, i);
                i = i + 1;
                
                Console.SetCursorPosition(10, i);
                Console.WriteLine(user.Id);
                Console.SetCursorPosition(25, i);
                Console.WriteLine(user.First_Name);
                Console.SetCursorPosition(40, i);
                Console.WriteLine(user.Last_Name);
                Console.SetCursorPosition(55, i);
                Console.WriteLine(user.Date_Of_Birth);
                Console.SetCursorPosition(80, i);
                Console.WriteLine(user.Residential_Address);
                Console.SetCursorPosition(100, i);
                Console.WriteLine(user.Cal_GPA(user));
            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void print()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(75, 0);
            int i = 1;
            Console.WriteLine("ID\t\tFirst Name\t\tLast Name\t\tDOB\t\t\tAddress");
            foreach (var user in users)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(75, i);
                i = i + 1;
                Console.WriteLine($"{user.Id}\t\t{user.First_Name,-15}\t\t{user.Last_Name,-15}\t\t{user.Date_Of_Birth,-15}\t\t{user.Residential_Address,-50}");
            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }

   
        public static void Delete_User(StudentUser user_del)
        {
            users.Remove(user_del);
           
        }
        
  

        public static void Display_User(StudentUser u)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\nID\tFirst Name\tLast Name\tDOB\t\tAddress");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{u.Id}\t{u.First_Name}\t\t{u.Last_Name}\t\t{u.Date_Of_Birth}\t{u.Residential_Address}");

        }
        public static bool IsvalidDate( string date)
        {
            DateTime DOB;
            return DateTime.TryParse(date, out DOB);
        }

    }
}
