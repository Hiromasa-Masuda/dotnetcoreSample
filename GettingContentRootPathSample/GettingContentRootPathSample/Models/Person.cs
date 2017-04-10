using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GettingContentRootPathSample.Models
{
    [DataContract]
    internal class Person
    {
        [DataMember]
        internal string Name { get; set; }

        [DataMember]
        internal int Age { get; set; }
    }
}
