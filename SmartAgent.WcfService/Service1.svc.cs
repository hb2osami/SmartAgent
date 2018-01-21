using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using SmartAgent.Services;
using SmartAgent.Services.Gestion;
using SmartAgent.Services.DTO;

namespace SmartAgent.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private GestionAgent ga = new GestionAgent();

        private GestionTache gt = new GestionTache();

        public void AddAgent(string fName,string lName)
        {
             ga.AddAgent(fName, lName, DateTime.Now);
        }

        public AgentDTO[] GetAgents()
        {
            return ga.GetAgents();
        }

        public AgentDTO[] Search(string nom)
        {
            return ga.GetAgents(nom);
        }

        public string GetData(int value)
        {
            //Model.Agent agent = new Model.Agent() { FirstName = "Valentin", LastName = "DURAND", BirthDate = DateTime.Now };

            //using (var context = new Model.SmartAgentDbEntities())
            //{
            //    context.Agents.Add(agent);

            //    context.SaveChanges();

            //    var l = context.Agents.Where(
            //      a => a.FirstName.Contains("mon")
            //    );
            //}

            //    Model.SmartAgentDbEntities context = new Model.SmartAgentDbEntities();

            //var list = context.Agents.Where(
            //    a => a.FirstName.Contains("mon")
            //).Select(a => new { prenom = a.FirstName });

            //foreach (var item in list)
            //{
            //    item.prenom
            //}

            return string.Format("You entered: {0}", value);
        }

        //public bool function(Model.Agent a)
        //{
        //    return a.FirstName.Contains("mon");
        //}
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string Tag()
        {
            return "yesss";
        }

        public void Init()
        {
            ga.Initialize();
        }

        public TacheDTO[] GetTasks()
        {
            return gt.GetTasks();
        }

        public AgentDTO GetAgent(string idA )
        {
            return ga.GetAgent(int.Parse(idA));
        }

        public void AddTask(string idA,string nomTache )
        {
            gt.AddTask(int.Parse(idA), nomTache);
            
        }

        public void Clean()
        {
            ga.clean();
        }

        public TacheDTO GetTask(string id)
        {
            return gt.GetTask(int.Parse(id));
        }



        public int UpdateAgent(string idA, string newFname)
        {
            return ga.UpdateAgent(int.Parse(idA), newFname);
        }

        public int UpdateTask(string idT, string newFname)
        {
            return gt.UpdateTask(int.Parse(idT), newFname);
        }

        public int DeleteAgent(string idA)
        {
            return ga.DeleteAgent(int.Parse(idA));
        }

        public int DeleteTask(string idT)
        {
           return gt.DeleteTask(int.Parse(idT));
        }
    }
}
