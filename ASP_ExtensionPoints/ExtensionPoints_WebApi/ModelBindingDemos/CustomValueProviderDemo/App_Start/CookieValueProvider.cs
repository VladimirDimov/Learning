namespace CustomValueProviderDemo.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http.Controllers;
    using System.Web.Http.ValueProviders;

    public class CookieValueProvider : IValueProvider
    {
        private Dictionary<string, string> _values;

        public CookieValueProvider(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            _values = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var cookie in actionContext.Request.Headers.GetCookies())
            {
                foreach (CookieState state in cookie.Cookies)
                {
                    _values[state.Name] = state.Value;
                }
            }
        }

        public bool ContainsPrefix(string prefix)
        {
            return _values.Keys.Contains(prefix);
        }

        public ValueProviderResult GetValue(string key)
        {
            string value;
            if (_values.TryGetValue(key, out value))
            {
                return new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
            }

            return null;
        }
    }
}