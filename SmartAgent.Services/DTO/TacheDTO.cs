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
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string location { get; set; }
        [DataMember]
        public string priority { get; set; }

        public TacheDTO(Model.Task t)
        {
            id = t.Id;
            name = t.Label;
            location = t.Location;
            priority = t.Priority;
        }
        //used for test
        
    }
}
