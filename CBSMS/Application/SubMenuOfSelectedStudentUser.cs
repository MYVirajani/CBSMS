using CBSMS;
using CBSMS.models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace CBSMS_Menu
{
    public class SubMenuOfSelectedStudentUser
    {
        public int ColPos2 { get; set; }
        public int RowPos2 { get; set; }
        public int SelectedItem2 { get; set; }

      



        public List<MenuItem> MenuItems2 { get; set; }


        
        public SubMenuOfSelectedStudentUser()
        {
            ColPos2 = 15;
            RowPos2 = 8;
            SelectedItem2 = 0;
            MenuItems2 = new List<MenuItem>
            {
                new MenuItem(">>>Modify User",true),
                new MenuItem(">>>Add Modules",false),
                new MenuItem(">>>Remove Modules",false),
                new MenuItem(">>>Add Grade",false),
                new MenuItem(">>>Delete User",false),
                new MenuItem(">>>Back",false)
            };
        }

       

        public void Display_SubMenu(StudentUser get_user)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;

            Console.Clear();
            Console.CursorVisible = false;
            bool running2 = true;
            bool display2 = true;

            while (running2)
            {
                Console.SetCursorPosition(ColPos2, RowPos2);

                for (int i = 0; i < MenuItems2.Count; i++)
                {
                    Console.SetCursorPosition(ColPos2, RowPos2 + i);
                    if (MenuItems2[i].Is_Selected)
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        if (display2 == true) Console.Write(MenuItems2[i].Title);
                    }

                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItems2[SelectedItem2].Is_Selected = false;
                    SelectedItem2 = (SelectedItem2 + 1) % MenuItems2.Count;

                    MenuItems2[SelectedItem2].Is_Selected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)                {
                    MenuItems2[SelectedItem2].Is_Selected = false;
                    SelectedItem2 = SelectedItem2 - 1;

                    if (SelectedItem2 < 0)
                    {
                        SelectedItem2 = MenuItems2.Count - 1;
                    }

                    MenuItems2[SelectedItem2].Is_Selected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(2, 0);
                    
               
                    bool stop2 = false;
                    
                    while (!stop2)
                    {


                        
                        switch (MenuItems2[SelectedItem2].Title)
                        {
                            case ">>>Modify User":
                                Console.Clear();
                                Console.SetCursorPosition(20, 0);
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine("***...Modify User...***\n");
                                Console.SetCursorPosition(0, 2);



                                Console.CursorVisible= true;
                                
                                
                                List_Of_Data.Display_User(get_user);
                
                                Console.WriteLine("\n->Enter 'f' to change First Name");
                                Console.WriteLine("->Enter 'l' to change Last Name");
                                Console.WriteLine("->Enter 'd' to change Date of Birth");
                                Console.WriteLine("->Enter 'a' to change Address\n");
                                string m1=Console.ReadLine();
                               
                                switch (m1)
                                {
                                    case "f":
                                        Console.WriteLine("Insert the First Name:");
                                        get_user.First_Name = Console.ReadLine();
                                        Console.WriteLine();
                                        List_Of_Data.Display_User(get_user);
                                        break;
                                    case "l":
                                        Console.WriteLine("Insert the Last Name:");
                                        get_user.Last_Name = Console.ReadLine();
                                        Console.WriteLine();
                                        List_Of_Data.Display_User(get_user);
                                        break;
                                    case "d":
                                        Console.WriteLine("Insert the Date of Birth:");
                                        get_user.Date_Of_Birth = Console.ReadLine();
                                        Console.WriteLine();
                                        List_Of_Data.Display_User(get_user);
                                        break;
                                    case "a":
                                        Console.WriteLine("Insert the Address:");
                                        get_user.Residential_Address = Console.ReadLine();
                                        Console.WriteLine();
                                        List_Of_Data.Display_User(get_user);
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Index ID!\a");
                                            break;
                                }
                                
                                
                         
                                Console.CursorVisible = false;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, 22);
                                Console.WriteLine("\n ***Press Enter to insert again***");
                                Console.ForegroundColor = ConsoleColor.Gray;
                            
                                break;

                            case ">>>Add Modules":
                                Console.Clear();
                                List_Of_Data.Display_RegModules(get_user);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("***Add Modules***");
                                List_Of_Data.Display_Modules();
                                List_Of_Data.Display_User(get_user);

                                Console.WriteLine($"\n->Enter the Module Id to add module to User {get_user.First_Name}");
                                int idmod = Convert.ToInt32(Console.ReadLine());
                                bool isadded = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == idmod)
                                    {
                                        Console.WriteLine("Module is already added");
                                        isadded = true;
                                        break;
                                    }


                                }
                                if (isadded == false) List_Of_Data.Create_Modules(get_user.Id, idmod);
                                
                                List_Of_Data.Display_RegModules(get_user);
                               
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("***Press Enter to insert again***");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;

                            case ">>>Remove Modules":
                                Console.Clear();
                                List_Of_Data.Display_RegModules(get_user);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("***Remove Modules***");
                                List_Of_Data.Display_User(get_user);
                                Console.WriteLine($"\nEnter the Module Id to delete module from User {get_user.First_Name}");
                                int idmod_r = Convert.ToInt32(Console.ReadLine());
                                bool isdeleted = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == idmod_r)
                                    {
                                        get_user.Modules.Remove(mod);
                                        isdeleted = true;
                                        break;
                                    }


                                }
                                Console.Clear();

                                if (isdeleted == false) Console.WriteLine("----Module is already deleted or Invalid Module Id.----");
                                List_Of_Data.Display_User(get_user);
                                List_Of_Data.Display_RegModules(get_user);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("***Press Enter to insert again***");
                                Console.ForegroundColor = ConsoleColor.Gray;
                        

                                break;

                            case ">>>Add Grade":
                                Console.Clear();
                                List_Of_Data.Display_RegModules(get_user);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("***Add Grade***");
                                List_Of_Data.Display_User(get_user);
                                Console.WriteLine($"\nEnter the Module id to add module grade  to User {get_user.First_Name}");
                                int get_mod_id = Convert.ToInt32(Console.ReadLine());
                                bool is_mod_registered = false;
                                foreach (var mod in get_user.Modules)
                                {
                                    if (mod.Id == get_mod_id)
                                    {
                                        Console.WriteLine("To add the Grade\n");
                                        Console.WriteLine("->Enter 'A' to add Grade A \n->Enter 'B' to add Grade B \n->Enter 'C' to add Grade C \n->Enter 'E' to add Grade E");
                                        string grade = Console.ReadLine().ToLower();
                                        is_mod_registered = true;
                                        switch (grade)
                                        {
                                            case "a":
                                                mod.Grade_Point = 4;
                                                Console.WriteLine("Grade A is added.");
                                                break;
                                            case "b":
                                                mod.Grade_Point = 3;
                                                Console.WriteLine("Grade B is added.");
                                                break;
                                            case "c":
                                                mod.Grade_Point = 2.5;
                                                Console.WriteLine("Grade C is added.");
                                                break;
                                            case "e":
                                                mod.Grade_Point = 0;
                                                Console.WriteLine("Grade E is added.");
                                                break;
                                            default:
                                                Console.WriteLine("Invalid Grade!\a");
                                                break;
                                        }


                                        break;
                                    }
                                }
                                if (is_mod_registered == false) {

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid Index!\a"); 
                                }

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, 24);

                                Console.WriteLine("***Press Enter to insert again***");
                                Console.ForegroundColor = ConsoleColor.Gray;

                                break;

                            case ">>>Delete User":
                                Console.Clear();
                                Console.SetCursorPosition(20,0);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("***Delete User***");
                                List_Of_Data.Display_User(get_user);
                                Console.WriteLine("\nDo you want to delete this User Y/N?");
                                string r1 = Console.ReadLine();
                                if ((r1 == "Y") || (r1 == "y"))
                                {
                                    List_Of_Data.Delete_User(get_user);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine($"User {get_user.First_Name} is Removed Successfuly !");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                }
                                else if ((r1 == "N") || (r1 == "n"))
                                {
                                    Console.WriteLine($"User is not deleted.");

                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input!\a");
                                }

                                running2 = false;
                                stop2 = true;
                                break;

                            

                            

                            case ">>>Back":
                                Console.Clear(); 


                                running2 = false;
                                stop2 = true;
                               
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid!\a ");
                                break;
                        }
                        if (stop2 != true)
                        {
                            Console.SetCursorPosition(2, 26);
                            Console.WriteLine(">>>Enter 'K' to Back<<<");
                           
                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "K") || (response == "k"))
                            {
                                stop2 = true;

                            }
                            Console.SetCursorPosition(2, 0);
                        }
                        

                    }


                }
            }
        }

    };
}
