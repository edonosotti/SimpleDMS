using System;
using System.Windows.Forms;

namespace SimpleDMS.Client.Windows.Forms
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.Main());
        }
    }
}
