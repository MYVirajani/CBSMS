using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;   
using System.Text;
using System.Threading.Tasks;

namespace CBSMS.models
{
    public  class StudentUser
    {
       

        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Date_Of_Birth { get; set; }

        public string Residential_Address { get; set; }
        public List<Module> Modules = new List<Module>();
        public StudentUser(int id, string firstName, string lastName, string dateOfBirth, string address)
        {
            Id = id;
            First_Name = firstName;
            Last_Name = lastName;
            Date_Of_Birth = dateOfBirth;
            Residential_Address = address;

        }public double Cal_GPA(StudentUser user)
        {
            double Point=0;
            double Sum_of_Credit=0.0000000001;
            
            foreach (var mode in user.Modules) {
                Point =Point +(mode.Grade_Point) * (mode.Credit_Point);
                Sum_of_Credit=Sum_of_Credit + mode.Credit_Point;
            }
            double _GPA_=Point/Sum_of_Credit;
            return Math.Round(_GPA_, 2);

            //return _GPA_;

        }
        
        
       
        
           
        

    }
}
