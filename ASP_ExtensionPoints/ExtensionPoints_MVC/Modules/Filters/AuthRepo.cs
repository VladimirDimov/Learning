using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modules.Filters
{
    public class AuthRepo : IAuthRepo
    {
        public IEnumerable<string> GetData { get; set; }
    }
}