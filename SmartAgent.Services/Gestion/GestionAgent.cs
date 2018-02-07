using SmartAgent.Model;
using SmartAgent.Services.DTO;
using SmartAgent.Services.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
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

            Agent[] agents = { new Model.Agent() { FirstName = "Francois", LastName = "dumeige", Company ="ass" ,Job ="technicien",BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Eric", LastName = "dupont", Company ="a2II" ,Job ="technicien de surface", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Nastia", LastName = "pellet", Company ="cst" ,Job ="ingénieur", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Laurent", LastName = "Brod",  Company ="alp" ,Job ="plombier",BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Amandine", LastName = "Lee", Company ="cst" ,Job ="technicien reseau", BirthDate = DateTime.Now },
                            new Model.Agent() { FirstName = "Maceo", LastName = "Plex",  Company ="tpa" ,Job ="technicien cablage", BirthDate = DateTime.Now }
            };


            Model.Task ta = new Model.Task { Label = "reseaux", Location = "Paris" };
            Model.Task tb = new Model.Task { Label = "plomberie", Location = "rennes" };
            Model.Task tc = new Model.Task { Label = "menage", Location = "caen" };

            //agents[4].ReportedTasks.Add(ta);
            //agents[3].ReportedTasks.Add(tb);
            //agents[1].ReportedTasks.Add(ta);

            using (var context = new Model.SmartAgentDbEntities())
            {
                foreach (Model.Agent agent in agents) {
                    context.Agents.Add(agent);
                }
                context.SaveChanges();
            }

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
                
                AgentDTO[] agents = context.Agents.ToArray().Select(a => new AgentDTO(a)).ToArray();
               
                return agents;
            }
        }

        public DTO.AgentDTO[] GetAgentsSorted(string sort)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                AgentDTO[] agents = context.Agents.OrderBy(sort, true).ToArray().Select(a => new AgentDTO(a)).ToArray();
                return agents;
            }
        }

        public AgentsPag GetAgents(int sizeP , int skip)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                AgentsPag agts = new AgentsPag();
                agts.agents= context.Agents.ToArray().Select(a => new AgentDTO(a)).Skip(skip).Take(sizeP).ToArray();
                agts.total = context.Agents.Count();
                
                return agts;
            }
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

        public int UpdateAgent(AgentDTO ag )
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Agent agent = context.Agents.Find(ag.id);
                if (agent == null) return 0;
                agent.FirstName = ag.prenom;
                agent.LastName = ag.nom;
                agent.Job = ag.job;
                context.SaveChanges();
                return 1;   
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