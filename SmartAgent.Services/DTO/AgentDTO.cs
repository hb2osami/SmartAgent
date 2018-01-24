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
        public string nom { get; set; }
        [DataMember]
        public string prenom { get; set; }
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string job { get; set; }
        [DataMember]
        public string company { get; set; }
        //[DataMember]
        //public TacheDTO[] tasks { get; set; }

        public AgentDTO(Agent ag)
        {
            nom = ag.LastName;
            prenom = ag.FirstName;
            id = ag.Id;
            job = ag.Job;
            company = ag.Company;
           // tasks = ag.ReportedTasks.ToArray().Select(a => new TacheDTO(a)).ToArray();
        }

        
    }
}
