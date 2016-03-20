using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11PW
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Menu();
        }
    }
}

//finish adding in the student accounts and filewriting to check in/out menus.  already added to DVD check out 
// when user checks out more than one item, it only writes one item in the file, need to fix that 
// need to do filewriting for check ins to rewrite the files
// edit resources
//  make polymorphism better with resource class
// double check rubric
