using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartAgent.WcfService.filters
{
    [DataContract]
    public class Filter
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string type { get; set; }
        public Filter(string n, string t)
        {
            name = n;
            type = t; 
        }
    }
}