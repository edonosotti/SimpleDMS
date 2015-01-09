using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleDMS.Storage.DTO;

namespace SimpleDMS.Storage.Provider.LocalStorageProvider
{
    public partial class LocalStorageProvider : BaseStorageProvider, IStorageProvider
    {
        private Uri CurrentURI { get; set; }

        public StorageOperationResult Create(Uri path)
        {
            return new StorageOperationResult();
        }

        public StorageOperationResult Delete()
        {
            return new StorageOperationResult();
        }

        public StorageOperationResult SetCredentials(Security.Credentials credentials)
        {
            return new StorageOperationResult();
        }

        public StorageOperationResult Open(Security.Credentials credentials)
        {
            return new StorageOperationResult();
        }

        public StorageOperationResult Close()
        {
            return new StorageOperationResult();
        }

        public StorageOperationResult Store(byte[] data)
        {
            return new StorageOperationResult();
        }

        public StorageOperationResult Fetch(string path)
        {
            return new StorageOperationResult();
        }

        public Form GetConfigurationForm(IStorageProvider instance)
        {
            return new Form();
        }

        public Form GetCreationForm(IStorageProvider instance)
        {
            return new Forms.Create(instance);
        }

        public Uri GetURI()
        {
            return CurrentURI;
        }


        public Form GetAuthForm(IStorageProvider instance)
        {
            return new Form();
        }

        public Common.ProviderCapabilities GetProviderCapabilities()
        {
            return new Common.ProviderCapabilities()
            {
                AuthType = Common.AuthType.NoAuth,
                SupportsFormsUI = true
            };
        }

        public Common.ProviderInfo GetProviderInfo()
        {
            return new Common.ProviderInfo()
            {
                Name = Res.Labels.ProviderName,
                Version = Res.Labels.ProviderVersion,
                Description = Res.Labels.ProviderDescription,
                Url = Res.Labels.ProviderUrl
            };
        }

        public bool IsConnected()
        {
            return true;
        }


        public void SetURI(Uri uri)
        {
            CurrentURI = uri;
        }
    }
}
