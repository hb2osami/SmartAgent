using SmartAgent.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SmartAgent.Services.Pagination
{
    [DataContract]
    public class AgentsPag
    {
        [DataMember]
        public int total { get; set; }

        [DataMember]
        public AgentDTO[] agents { get; set; }

        public AgentsPag()
        {

        }
    }
}