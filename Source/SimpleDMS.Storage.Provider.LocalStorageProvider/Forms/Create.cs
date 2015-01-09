using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleDMS.Data;

namespace SimpleDMS.Storage.Provider.LocalStorageProvider.Forms
{
    public partial class Create : Form
    {
        private IStorageProvider ProviderInstance;
        private LocalStorageSettings ProviderSettings;

        public Create(IStorageProvider instance)
        {
            InitializeComponent();

            ProviderInstance = instance;

            ProviderSettings = SettingsManager.ReadSettings<LocalStorageSettings>(ProviderInstance.GetType());

            if (ProviderSettings == null)
            {
                ProviderSettings = new LocalStorageSettings();
            }

            if (string.IsNullOrEmpty(ProviderSettings.LastBasePath))
            {
                ProviderSettings.LastBasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            SetDefaults();
        }

        private void SetDefaults()
        {
            textBox1.Text = Path.Combine(
                    ProviderSettings.LastBasePath,
                    string.Format(Res.Labels.DefaultStorageName, System.Security.Principal.WindowsIdentity.GetCurrent().Name)
                );
        }
    }
}
