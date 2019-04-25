//Referencing Distributed Computing Worksheet 01 
//Making a Maps-style satellite imagery browser
//Creating a GUI client as a presentation/GUI tier in the practical
//Author : Kasundi Maneesha Wickramaarachchi 
//Curtin ID : 19735171

using System;
using Gtk;

namespace TrueMarbleGUI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            Application.Run();
        }
    }
}
