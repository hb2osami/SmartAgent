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
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string job { get; set; }
        [DataMember]
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
