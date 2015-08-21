using System;
using System.Windows.Forms;
using SimpleDMS.Security;
using SimpleDMS.Storage.Provider.DTO;

namespace SimpleDMS.Storage.Provider
{
    public interface IStorageProvider
    {
        StorageOperationResult Create(Uri path);
        StorageOperationResult Delete();
        StorageOperationResult SetCredentials(Credentials credentials);
        StorageOperationResult Open(Credentials credentials);
        StorageOperationResult Close();
        StorageOperationResult Store(byte[] data);
        StorageOperationResult Fetch(string path);
        Form GetConfigurationForm(IStorageProvider instance);
        Form GetCreationForm(IStorageProvider instance);
        Form GetAuthForm(IStorageProvider instance);
        Uri GetURI();
        Common.ProviderCapabilities GetProviderCapabilities();
        Common.ProviderInfo GetProviderInfo();
        bool IsConnected();
        void SetURI(Uri uri);
    }
}
