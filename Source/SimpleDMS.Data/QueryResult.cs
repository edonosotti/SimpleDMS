using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDMS.Data.Models;

namespace SimpleDMS.Data
{
    public class QueryResult
    {
        public Document[] Set { get; set; }
        public SimpleDMS.Data.Context.CommandStatus Result { get; set; }
    }
}
