using SmartAgent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgent.Services.DTO
{
    [DataContract]
    public class AgentDTO
    {
        [DataMember(Order = 0)]
        public string LastName { get; set; }
        [DataMember(Order = 1)]
        public string FirstName { get; set; }
        [DataMember(Order = 2)]
        public int id { get; set; }
        [DataMember(Order = 3)]
        public string job { get; set; }
        [DataMember(Order = 4)]
        public string company { get; set; }

        public AgentDTO(Agent ag)
        {
            LastName = ag.LastName;
            FirstName = ag.FirstName;
            id = ag.Id;
            job = ag.Job;
            company = ag.Company;

        }

        
    }
}
