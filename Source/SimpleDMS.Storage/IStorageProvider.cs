using System;
using System.Windows.Forms;
using SimpleDMS.Storage.DTO;
using SimpleDMS.Security;

namespace SimpleDMS.Storage
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
        SimpleDMS.Storage.Common.ProviderCapabilities GetProviderCapabilities();
        SimpleDMS.Storage.Common.ProviderInfo GetProviderInfo();
        bool IsConnected();
        void SetURI(Uri uri);
    }
}
