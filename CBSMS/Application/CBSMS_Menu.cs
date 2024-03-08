using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBSMS_Menu
{
    public class MenuItem
    {
        public string Title { get;set; }
        public bool Is_Selected { get;set; }

        public MenuItem(string title, bool isSelected)
        {
            Title = title;
            Is_Selected = isSelected;
        }
    }
}
