﻿using SmartAgent.Model;
using SmartAgent.Services.DTO;
using System;
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

        public int AddTask(int AgentId,String label)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Agent agent = context.Agents.Find(AgentId);

                if (agent == null) return 0;

                Model.Task task = new Model.Task { Label = label, Priority = "high", Location = "Paris" };

                List<Model.Task> lt = new List<Model.Task>();

                lt.Add(task);
                agent.ReportedTasks.Add(task);
                //context.Tasks.Add(task);
                context.SaveChanges();


            }
            return 1;
        }
        public int UpdateTask(int idT, string newLabel)
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                Model.Task task = context.Tasks.Find(idT);
                if (task == null) return 0;
                task.Label = newLabel;
                context.SaveChanges();
                return task.Id;
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
