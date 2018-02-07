using SmartAgent.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgent.Services.Pagination
{
    [DataContract]
    class TachesPag
    {
        [DataMember]
        public int total { get; set; }

        [DataMember]
        public TacheDTO[] tasks { get; set; }

        public TachesPag()
        {

        }
    }
}
