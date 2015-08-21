using SimpleDMS.Content.Provider.DTO;
using System;

namespace SimpleDMS.Content.Provider
{
    public interface IContentProvider
    {
        ContentItem[] Acquire();
        ContentItem[] Acquire(Uri source, System.Net.ICredentials credentials = null);
    }
}
