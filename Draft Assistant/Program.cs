using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Draft_Assistant
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface MainMenu = new UserInterface();
            Window w = new Window();
            w.Content = MainMenu;
            w.Show();

        }
    }
}
