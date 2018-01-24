using SmartAgent.Services.Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgent.Services.DTO
{
    [DataContract]
    public class TacheDTO
    {
        private GestionAgent ag = new GestionAgent();
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public string priority { get; set; }
        [DataMember]
        public string company  { get; set; }
        [DataMember]
        public string job { get; set; }
        [DataMember]
        public string fnameAg { get; set; }
        [DataMember]
        public string lnameAg { get; set; }


        public TacheDTO(Model.Task t)
        {
            id = t.Id;
            name = t.Label;
            location = t.Location;
            priority = t.Priority;
            job =t.Author.Job;
            company = t.Author.Company;
            fnameAg = t.Author.FirstName;
            lnameAg = t.Author.LastName;
            //job = Model.Agent
        }
        //used for test
    }
}
