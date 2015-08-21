using SimpleDMS.Content.Provider;
using SimpleDMS.Storage.Provider;
using System;
using System.Windows.Forms;

namespace SimpleDMS.Client.Windows.Forms.Forms
{
    public partial class Main : Form
    {
        IStorageProvider provider;
        IContentProvider ContentProvider;

        public Main()
        {
            InitializeComponent();

            provider = new SimpleDMS.Storage.Provider.LocalStorageProvider.LocalStorageProvider();

            var form = provider.GetCreationForm(provider);
            form.MdiParent = this;
            form.FormClosing += OnCreateFormClosing;
            form.Show();

            ContentProvider = new Content.Provider.Scanner.ScannerContentProvider();
        }

        void OnCreateFormClosing(object sender, EventArgs e)
        {
            var s = provider.GetURI();
        }
    }
}
