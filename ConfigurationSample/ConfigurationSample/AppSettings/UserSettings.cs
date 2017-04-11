using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationSample.AppSettings
{
    public class UserSettings
    {
        public bool IsDemoMode { get; set; }
        public DefaultUser DefaultUser { get; set; }
    }

    public class DefaultUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
