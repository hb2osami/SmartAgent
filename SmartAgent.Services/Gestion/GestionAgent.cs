using SmartAgent.Model;
using SmartAgent.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgent.Services.Gestion
{
    public class GestionAgent
    {
        public GestionAgent()
        {
            //context = new SmartAgentDbEntities();

        }
        public void clean()
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Agents");


                context.SaveChanges();
            }
        }
        public void Initialize() {

            Agent[] agents = { new Model.Agent() { FirstName = "Francois", LastName = "Ali", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Toto", LastName = "Titi", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Tata", LastName = "tutu", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Laurent", LastName = "Lolo", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Amandine", LastName = "toto", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Maceo", LastName = "Plex", BirthDate = DateTime.Now }
            };

            Agent test = new Agent() { FirstName = "Toto", LastName = "Titi", BirthDate = DateTime.Now };

            Model.Task ta = new Model.Task { Label = "reseaux", Location = "Paris" };
            Model.Task tb = new Model.Task { Label = "plomberie", Location = "rennes" };
            Model.Task tc = new Model.Task { Label = "menage", Location = "caen" };

            List<Model.Task> lt = new List<Model.Task>();
            lt.Add(ta);
            lt.Add(tb);
            lt.Add(tc);
            agents[2].ReportedTasks = lt;

        }


        public AgentDTO[] GetAgent(String nom)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                AgentDTO[] agents = context.Agents.Where(a => a.FirstName.Contains(nom)).ToArray().Select(a => new AgentDTO(a)).ToArray();
                return agents;

            }

        }
        public AgentDTO GetAgent(int id)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Agent agent = context.Agents.Find(id);
                if (agent == null) return null;
                return new AgentDTO(agent);
            }

        }
        public DTO.AgentDTO[] GetAgents(String nom)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                AgentDTO[] agents = context.Agents.Where(a => a.FirstName.Contains(nom)).ToArray().Select(a => new AgentDTO(a)).ToArray();
                return agents;

            }
        }

        public Agent[] test(String nom)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Agent[] agents = context.Agents.Where(a => a.FirstName.Contains(nom)).ToArray();
                return agents;

            }
        }
        public DTO.AgentDTO[] GetAgents()
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                //context.Agents.Add(new Agent() { FirstName = "a", LastName = "b",BirthDate=DateTime.Now });
               // int res = context.SaveChanges();
                AgentDTO[] agents = context.Agents.ToArray().Select(a => new AgentDTO(a)).ToArray();
                
                return agents;
                //agent[] tmp = context.agents.toarray();

                //for (int i = 0; i < tmp.length; i++)
                //{
                //    agents[i] = new agentdto(tmp[i]);

                //}
                //return agents;
            }
            //AgentDTO[] agents = { new AgentDTO("sami", "aassa", 4), new AgentDTO("dasaasahmani", "mstafa", 4) };
            //return agents;
        }
        
        public int AddAgent(String nom, String prenom, DateTime date)
        {
            int retour;
            Agent agent = new Model.Agent() { FirstName = prenom, LastName = nom, BirthDate = date };
            using (var context = new Model.SmartAgentDbEntities())
            {
                context.Agents.Add(agent);
                retour = context.SaveChanges();
            }
            return retour;
        }
        public int AddAgent(AgentDTO ag)
        {
            int retour;
            Agent agent = new Model.Agent() { FirstName = ag.prenom, LastName = ag.nom, BirthDate = DateTime.Now ,Company=ag.company ,Job = ag.job };
            using (var context = new Model.SmartAgentDbEntities())
            {
                context.Agents.Add(agent);
                retour = context.SaveChanges();
            }
            return retour;
        }

        public int UpdateAgent(int idA, string newFname)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Agent agent = context.Agents.Find(idA);
                if (agent == null) return 0;
                agent.FirstName = newFname;
                context.SaveChanges();
                return agent.Id;   
            }

        }
        public int DeleteAgent(int idA) {
            using (var context = new Model.SmartAgentDbEntities())
            {
                GestionTache gt = new GestionTache();
                Agent agent = context.Agents.Find(idA);
                if (agent == null) return 0;
                for( int i=0; i < agent.ReportedTasks.Count(); i++)
                {
                    gt.DeleteTask(agent.ReportedTasks.ElementAt(i).Id);
                }
                context.Agents.Remove(agent);
                context.SaveChanges();
                return 1;
            }

        }
        public static implicit operator GestionAgent(GestionTache v)
        {
            throw new NotImplementedException();
        }
    }
}
