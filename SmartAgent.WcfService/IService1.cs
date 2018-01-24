using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SmartAgent.Services.DTO;

namespace SmartAgent.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        [WebGet(UriTemplate = "/Tag")]
        string Tag();

        [OperationContract]
        [WebGet(UriTemplate = "/Init")]
        void Init();

        [OperationContract]
        [WebGet(UriTemplate = "/Clean")]
        void Clean();

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        [WebGet(UriTemplate = "/Agents")]
        AgentDTO[] GetAgents();

        [OperationContract]
        [WebGet(UriTemplate = "/Agent/{idA}")]
        AgentDTO GetAgent(string idA);

        [OperationContract]
        [WebGet(UriTemplate = "/Tasks")]
        TacheDTO[] GetTasks();

        [OperationContract]
        [WebGet(UriTemplate = "/Tasks/{sort}/{order}")]
        TacheDTO[] GetTasks(string sort , string order);

        [OperationContract]
        
        [WebGet(UriTemplate = "/Task/{id}")]
        TacheDTO GetTask(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/Search{nom}")]
        AgentDTO[] Search(String nom);

        //[OperationContract]
        //[WebInvoke(Method = "POST", UriTemplate = "/AddAgent/{fName}/{lName}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        //void AddAgent(string fName,string lName);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddAgent/", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        AgentDTO AddAgent(AgentDTO ag );

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/AddTask/{idA}/{nomTache}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void AddTask(string idA,string nomTache);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Agent/update/{idA}/{newFname}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int UpdateAgent(string idA, string newFname);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Task/update/{idT}/{newLabel}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int UpdateTask(string idT, string newLabel);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Agent/delete/{idA}")]
        int DeleteAgent(string idA);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Task/delete/{idT}")]
        int DeleteTask(string idT);

        // TODO: ajoutez vos opérations de service ici
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
