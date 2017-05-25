using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modules.Filters
{
    public interface IAuthRepo
    {
        IEnumerable<string> GetData { get; set; }
    }
}