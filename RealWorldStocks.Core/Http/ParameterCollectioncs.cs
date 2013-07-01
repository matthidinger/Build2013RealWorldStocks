using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RealWorldStocks.Core.Http
{
    public class ParameterCollection : Collection<KeyValuePair<string, string>>
    {
        public void AddIfHasValue(string name, bool? b)
        {
            if (b.HasValue)
                this.Add(name, b.Value.ToString().ToLowerInvariant());
        }

        public void AddIfHasValue(string name, long? l)
        {
            if (l.HasValue)
                this.Add(name, l.Value.ToString());
        }

        public void AddIfHasValue(string name, double? d)
        {
            if (d.HasValue)
                this.Add(name, d.Value.ToString());
        }

        public void AddIfHasValue(string name, int? i)
        {
            if (i.HasValue)
                this.Add(name, i.Value.ToString());
        }

        public void AddIfHasValue(string name, string s)
        {
            if (!String.IsNullOrEmpty(s))
                this.Add(name, s);
        }

        public void Add(string name, string value)
        {
            this.Add(new KeyValuePair<string, string>(name, value));
        }
    }
}
