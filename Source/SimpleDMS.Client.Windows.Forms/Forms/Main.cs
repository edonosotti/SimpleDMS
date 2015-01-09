using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleDMS.Storage;

namespace SimpleDMS.Client.Windows.Forms.Forms
{
    public partial class Main : Form
    {
        IStorageProvider provider;

        public Main()
        {
            InitializeComponent();

            provider = new SimpleDMS.Storage.Provider.LocalStorageProvider.LocalStorageProvider();

            var form = provider.GetCreationForm(provider);
            form.MdiParent = this;
            form.FormClosing += OnCreateFormClosing;
            form.Show();
        }

        void OnCreateFormClosing(object sender, EventArgs e)
        {
            var s = provider.GetURI();
        }
    }
}
