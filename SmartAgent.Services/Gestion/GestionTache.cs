using SmartAgent.Model;
using SmartAgent.Services.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
                List < TacheDTO > list = context.Tasks.ToList().Select(a => new TacheDTO(a)).ToList();
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
                Model.Task task = new Model.Task { Label = t.task, Priority = t.priority, Location = t.location,Author=agent };
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
                tache.Label = t.task;
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
