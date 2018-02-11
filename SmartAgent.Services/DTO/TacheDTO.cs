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
        public string label { get; set; }
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public string priority { get; set; }
        [DataMember]
        public string company { get; set; }
        [DataMember]
        public string job { get; set; }
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public int idA { get; set; }

        public TacheDTO(Model.Task t)
        {
            id = t.Id;
            label = t.Label;
            location = t.Location;
            priority = t.Priority;
            job =t.Author.Job;
            company = t.Author.Company;
            name = t.Author.FirstName +" "+ t.Author.LastName;
            idA = t.Author.Id;
        }
        //used for test
    }
}
