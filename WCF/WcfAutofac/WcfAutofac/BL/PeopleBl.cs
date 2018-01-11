using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfAutofac.BL
{
    public class PeopleBl
    {
        public string FormatValue(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}