using CBSMS;
using CBSMS.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace CBSMS_Menu
{
    public class MainMenu
    {
        public int Col_Pos { get; set; }
        public int Row_Pos { get; set; }
        public int Selected_Item{get; set;}

       

        SubMenuOfSelectedStudentUser subMenu = new SubMenuOfSelectedStudentUser();
        


        public List<MenuItem> Menu_Items { get; set; }

        
        
        public MainMenu()
        {
            Col_Pos = 15;
            Row_Pos = 8;
            Selected_Item = 0;
            Menu_Items = new List<MenuItem>
            {

                new MenuItem(">>>Add User",true),
                new MenuItem(">>>Select User",false),
                new MenuItem(">>>Delete User",false),
                new MenuItem(">>>Display All Users",false),
                new MenuItem(">>>Quit",false)
            };
        }
     
      


        public void Display_Menu()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
        

            Console.Clear();
            bool running = true;
            bool displaying=true;

            while (running)
            {
                Console.SetCursorPosition(Col_Pos, Row_Pos);
                Console.CursorVisible = false;

                for(int i = 0; i<Menu_Items.Count; i++)
                {
                    Console.SetCursorPosition(Col_Pos, Row_Pos + i);
                    if (Menu_Items[i].Is_Selected)
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if(displaying==true) Console.Write(Menu_Items[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        if (displaying == true) Console.Write(Menu_Items[i].Title);
                    }
                    
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow) 
                { 
                    Menu_Items[Selected_Item].Is_Selected = false;
                    Selected_Item = (Selected_Item+1)%Menu_Items.Count;
                    
                    Menu_Items[Selected_Item].Is_Selected = true;
                }
                if(key.Key == ConsoleKey.UpArrow)
                {
                    Menu_Items[Selected_Item].Is_Selected = false;
                    Selected_Item = Selected_Item - 1;

                    if(Selected_Item < 0)
                    {
                        Selected_Item = Menu_Items.Count - 1;
                    }

                    Menu_Items[Selected_Item].Is_Selected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    
                    Console.SetCursorPosition(2, 0);
                

              
                    bool stopping = false;
                   
                    while (!stopping)
                    {
                       



                        switch (Menu_Items[Selected_Item].Title)
                        {
                            case ">>>Add User":
                                Console.Clear();
                                List_Of_Data.print();
                                Console.WriteLine("***Add User***");
                                List_Of_Data.Add_User();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, 10);
                                Console.WriteLine("***Press Enter to add another user***");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(2, 0);

                                break;
                            case ">>>Select User":
                                
                                Console.Clear();
                                
                                List_Of_Data.print();
                                
                                Console.WriteLine("***Select User***");
                                
                                Console.WriteLine("Enter the User Id");

                                int user_id=Convert.ToInt32(Console.ReadLine());
                                bool is_user_valid = false;
                                foreach(var user in List_Of_Data.users)
                                {
                                    if(user.Id == user_id)
                                    {
                                        is_user_valid=true;
                                        
                                        subMenu.Display_SubMenu(user);
                                        break;
                                    }
                                }
                                if(is_user_valid==false) { Console.WriteLine("Invalid User Id"); }


                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, 10);
                                Console.WriteLine("***Press Enter to select user again***");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(2, 0);

                                break;

                            case ">>>Delete User":
                                Console.Clear();
                                List_Of_Data.print();
                                Console.WriteLine("***Delete User***");
                                Console.WriteLine("Enter the user Id ");
                                int _d_Id=Convert.ToInt32(Console.ReadLine());
                                bool is_user_valid_d=false;
                             
                                foreach (var user in List_Of_Data.users)
                                {
                                    if (user.Id == _d_Id)
                                    {
                                        List_Of_Data.Display_User(user);
                                        Console.WriteLine("\nDo you want to delete this User Y/N?");
                                        string r1 = Console.ReadLine();
                                        is_user_valid_d = true;
                                        if ((r1 == "Y") || (r1 == "y"))
                                        {
                                            List_Of_Data.Delete_User(user);
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            Console.WriteLine($"User {user.Id} is Removed Successfuly !");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        else if ((r1 == "N") || (r1 == "n"))
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"User is not deleted.");

                                        }
                                        else 
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid Input!\a");
                                        }


                                        break;
                                    }
                                    
                                }

                                if (is_user_valid_d == false)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid user ID or User was already Deleted!\a");
                                }
                                 


                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(2, 10);
                                Console.WriteLine("***Press Enter to insert again***");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case ">>>Display All Users":
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(50, 0);
                                Console.WriteLine("***Display All Users***\n");
                                List_Of_Data.Print_Users();
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.SetCursorPosition(2, 0);


                                break;

                            case ">>>Quit":
                                Console.Clear();
                                Console.SetCursorPosition(50, 15);
                              
                                Console.WriteLine(" ****  Quit" +
                                    "  Exiting.....****\a");
                                running = false;
                                stopping = true;
                               
                                break; 
                               
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid ");
                                break;
                        }
                        if (stopping!= true) {
                            Console.SetCursorPosition(2, 12);

                            Console.WriteLine(">>>Enter 'K' for Back to MainMenu<<<");
                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "K")||(response=="k"))
                            {
                                stopping = true;
                            }
                            Console.SetCursorPosition(2, 0);
                        }
                        
                    }


                }
            }
        }

    };
}
