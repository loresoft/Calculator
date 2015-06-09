using System;
using System.Windows.Forms;
using LoreSoft.Calculator.Properties;
using Microsoft.VisualBasic.ApplicationServices;

namespace LoreSoft.Calculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Settings.Default.IsSingleInstance)
            {
                SingleInstanceApplication.Current.CreateMainFormFactory = () => new CalculatorForm();
                SingleInstanceApplication.Current.StartupNextInstance += Application_StartupNextInstance;
                SingleInstanceApplication.Current.Run(args);
            }
            else
            {
                Application.Run(new CalculatorForm());
            }
        }

        private static void Application_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            e.BringToForeground = true;
        }
    }
}