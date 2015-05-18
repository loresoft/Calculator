using System;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;

namespace LoreSoft.Calculator
{
    internal class SingleInstanceApplication : WindowsFormsApplicationBase
    {

        private static readonly Lazy<SingleInstanceApplication> _application = new Lazy<SingleInstanceApplication>();
        internal static SingleInstanceApplication Current
        {
            get { return _application.Value; }
        }

        public SingleInstanceApplication()
        {
            IsSingleInstance = true;
            ShutdownStyle = ShutdownMode.AfterMainFormCloses;
        }

        public Func<Form> CreateMainFormFactory { get; set; }

        protected override void OnCreateMainForm()
        {
            if (CreateMainFormFactory != null)
                MainForm = CreateMainFormFactory();
        }
    }
}
