﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Runtime.Serialization;


namespace JsonSerializationApp001
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
