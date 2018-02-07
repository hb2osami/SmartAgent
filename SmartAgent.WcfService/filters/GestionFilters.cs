using SmartAgent.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SmartAgent.WcfService.filters
{
    public class GestionFilters
    {
        public List<Filter> GetAgentsFilters()
        {
            List <Filter> listF = new List<Filter>();

            PropertyInfo[] properties = typeof(AgentDTO).GetProperties();
            foreach (PropertyInfo property in properties)
            {

                Filter tmp = new Filter(property.Name, property.PropertyType.Name);
                listF.Add(tmp);
            }
            return listF;
            //using (var context = new Model.SmartAgentDbEntities())
            //{
            //    var data = context.Agents.FirstOrDefault();
            //    var props = data.GetType().GetProperties();

            //    foreach (var column in props)
            //    {
            //        Filter tmp = new Filter(column.Name, column.PropertyType.Name);
            //        listF.Add(tmp);
            //    }
            //    return listF;
            //}

        }
        public List<Filter> GetTasksFilters()
        {
            List<Filter> listF = new List<Filter>();


            PropertyInfo[] properties = typeof(TacheDTO).GetProperties();
            foreach (PropertyInfo property in properties)
            {

                Filter tmp = new Filter(property.Name, property.PropertyType.Name);
                listF.Add(tmp);
            }
            return listF;
            //using (var context = new Model.SmartAgentDbEntities())
            //{
            //    var data = context.Tasks.FirstOrDefault();
            //    var props = data.GetType().GetProperties();
            //    foreach (var column in props)
            //    {
            //        Filter tmp = new Filter(column.Name, column.PropertyType.Name);
            //        listF.Add(tmp);
            //    }
            //    return listF;

            //}

        }


    }
}