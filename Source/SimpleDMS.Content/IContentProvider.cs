using System;
using SimpleDMS.Content.DTO;

namespace SimpleDMS.Content
{
    public interface IContentProvider
    {
        ContentItem[] Acquire(Uri source, System.Net.ICredentials credentials = null);
    }
}
