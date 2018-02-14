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


            
            Model.Task[] tasks = {
                new Model.Task{ Author = agents[4], Label = "Reseaux", Location="rennes",Priority="high"},
                new Model.Task{ Author = agents[1], Label = "climatisation", Location="Caen",Priority="low"},
                new Model.Task{ Author = agents[2], Label = "Plomberie" ,Location="Paris",Priority="Medium"},

             };

            //agents[4].ReportedTasks.Add(ta);
            //agents[3].ReportedTasks.Add(tb);
            //agents[1].ReportedTasks.Add(ta);

            using (var context = new Model.SmartAgentDbEntities())
            {
                foreach (Model.Agent agent in agents) {
                    context.Agents.Add(agent);
                }
                context.Tasks.AddRange(tasks);
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
        public AgentDTO[] GetAgentsbis(int offset, int limit, string sort, int dir, string searchG, Dictionary<string, string> dic) {
            Boolean order = true;
            if (dir == 0) order = false;

            using (var context = new Model.SmartAgentDbEntities())
            {
                var result = context.Agents.AsQueryable();
                foreach (KeyValuePair<string, string> entry in dic)
                {
                    if (entry.Key.ToLower() == "id")
                    {
                        result = result.Where(x => x.Id == int.Parse(entry.Value));
                    }
                    if (entry.Key.ToLower() == "firstname")
                    {
                        result = result.Where(x => x.FirstName == entry.Value);
                    }
                    if (entry.Key.ToLower() == "lastname")
                    {
                        result = result.Where(x => x.LastName == entry.Value);
                    }
                    if (entry.Key == "job")
                    {
                        result = result.Where(x => x.Job == entry.Value);
                    }
                    if (entry.Key == "company")
                    {
                        result = result.Where(x => x.Company == entry.Value);
                    }
                }
                if (!string.IsNullOrEmpty(searchG))
                {
                    result = result.Where(x => x.FirstName.Contains(searchG) || x.LastName.Contains(searchG) || x.Job.Contains(searchG) || x.Company.Contains(searchG));
                }

                if (!string.IsNullOrEmpty(sort))
                {

                    result.OrderBy(sort, order);
                }

                // Pagination
                AgentDTO[] agents = result.ToArray().Select(a => new AgentDTO(a)).Skip(offset).Take(limit).ToArray();
                return agents;

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
            Agent agent = new Model.Agent() { FirstName = ag.FirstName, LastName = ag.LastName, BirthDate = DateTime.Now ,Company=ag.company ,Job = ag.job };
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
                agent.FirstName = ag.FirstName;
                agent.LastName = ag.LastName;
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