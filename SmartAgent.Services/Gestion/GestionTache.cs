using SmartAgent.Model;
using SmartAgent.Services.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgent.Services.Gestion
{
    public class GestionTache
    {
        public GestionTache()
        {

        }
        public DTO.TacheDTO[] GetTasks()
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                TacheDTO[] tasks = context.Tasks.ToArray().Select(a => new TacheDTO(a)).ToArray();
                List<TacheDTO> list = context.Tasks.ToList().Select(a => new TacheDTO(a)).ToList();
                return tasks;
            }
        }
        public TacheDTO[] GetTasksbis(int offset, int limit, string sort, int dir ,string searchG, Dictionary<string, string> dic)

        {

            Boolean order = true;
            if (dir == 0) order = false;

            using (var context = new Model.SmartAgentDbEntities())
            {
                
                var result = context.Tasks.AsQueryable();
                string where = "";
                foreach (KeyValuePair<string, string> entry in dic)
                {
                    if (entry.Key.ToLower() == "location") {
                        result = result.Where(x => x.Location == entry.Value);
                    }
                    if (entry.Key.ToLower() == "priority")
                    {
                        result = result.Where(x => x.Priority == entry.Value );
                    }
                    if (entry.Key == "label")
                    {
                        result = result.Where(x => x.Label == entry.Value);
                    }
                    if (entry.Key == "company")
                    {
                        result = result.Where(x => x.Author.Company == entry.Value);
                    }
                    if (entry.Key == "job")
                    {
                        result = result.Where(x => x.Author.Job == entry.Value);
                    }
                }
                if (!string.IsNullOrEmpty(searchG)) {
                    result = result.Where(x => x.Label.Contains(searchG) || x.Location.Contains(searchG) || x.Label.Contains(searchG) || x.Author.FirstName.Contains(searchG) || x.Author.LastName.Contains(searchG) || x.Author.Job.Contains(searchG));
                }

                if (!string.IsNullOrEmpty(sort)) {
                    
                    result.OrderBy(sort, order);
                }
                // Pagination
                TacheDTO[] tasks = result.ToArray().Select(a => new TacheDTO(a)).Skip(offset).Take(limit).ToArray();
                return tasks;
            }
        }
        public TacheDTO GetTask(int id)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                try
                {
                    Model.Task t = context.Tasks.Find(id);
                    if (t == null) return null;
                    TacheDTO tache = new TacheDTO(t);
                    return tache;
                }
                catch(InvalidOperationException e)
                {
                    return null;
                }
            }

        }
        public int AddTask(TacheDTO t)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Agent agent = context.Agents.Find(t.idA);
                if (agent == null) return 0;
                Model.Task task = new Model.Task { Label = t.label, Priority = t.priority, Location = t.location,Author=agent };
                agent.ReportedTasks.Add(task);
                context.SaveChanges();
            }
            return 1;
        }
        public int UpdateTask(TacheDTO t)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Model.Task tache = context.Tasks.Find(t.id);
                Model.Agent agent = context.Agents.Find(t.idA);
                if (tache == null) return 0;
                tache.Label = t.label;
                tache.Location = t.location;
                tache.Priority = t.priority;
                tache.Author = agent;
                context.SaveChanges();
                return 1;
            }

        }
        public int DeleteTask(int idT)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Model.Task task = context.Tasks.Find(idT);
                if (task == null) return 0;
                context.Tasks.Remove(task);
                context.SaveChanges();
                return 1;
            }

        }
    }
}
