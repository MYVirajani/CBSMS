using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSMS.models
{
    public class Module
    {
       

        public int Id { get; set; }
        public string Name { get; set; }

        public string Grade { get; set; }
        public double Grade_Point { get; set; }
        public double Credit_Point { get; set; }
        public Module(int id, string name, double credit_point)
        {
            Id = id;
            Name = name;
            Credit_Point = credit_point;
            Grade_Point = 0;
        }
        
    }

}
