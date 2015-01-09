using System.Linq;
using Newtonsoft.Json;
using SimpleDMS.Data.Models;

namespace SimpleDMS.Data
{
    public class Context
    {
        public enum CommandStatus
        {
            OK,
            GenericError,
            InvalidArchive,
            CredentialsError
        }

        public Archive Archive = new Archive();

        public Context()
        {
            
        }

        public Context(string json, string password = "")
        {
            SetPassword(password);
            Load(json);
        }

        public void SetPassword(string password)
        {
            
        }

        public void Load(string json)
        {
            Archive = JsonConvert.DeserializeObject<Archive>(json);
        }

        public QueryResult Search(string[] tags = null, string text = null)
        {
            var result = new QueryResult();

            if (IsValid())
            {
                var query = Archive.Documents.AsEnumerable();

                if (!string.IsNullOrEmpty(text))
                {
                    query = query.Where(
                            w => 
                                w.Title.Contains(text) ||
                                w.Description.Contains(text) ||
                                w.Pages.Where(
                                        p => 
                                            p.Title.Contains(text) ||
                                            p.Description.Contains(text) ||
                                            p.Content.Contains(text)
                                    ).Any() || 
                                (w.Tags.Any() && w.Tags.Contains(text))
                        );
                }

                if (tags != null)
                {
                    foreach (var tag in tags)
                    {
                        query = query.Where(w => w.Tags.Any() && w.Tags.Contains(tag));
                    }
                }

                result.Set = query.ToArray();
                result.Result = CommandStatus.OK;
            }
            else
            {
                result.Result = CommandStatus.InvalidArchive;
            }

            return result;
        }

        public bool IsValid()
        {
            return (Archive != null);
        }
    }
}
