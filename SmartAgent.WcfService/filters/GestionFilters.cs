using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartAgent.WcfService.filters
{
    public class GestionFilters
    {
        public List<Filter> GetAgentsFilters()
        {
            List <Filter> listF = new List<Filter>();

            using (var context = new Model.SmartAgentDbEntities())
            {
                var data = context.Agents.FirstOrDefault();
                var props = data.GetType().GetProperties();
                
               

                foreach (var column in props)
                {
                    //if ( column.PropertyType.IsInstanceOfType(typeof(System.String))){

                    //    Filter tmp = new Filter(column.Name, column.MemberType.ToString());
                    //    listF.Add(tmp);
                    //    string columnName = column.Name;
                    //    string columnValue = string.Empty;
                    //}
                    Filter tmp = new Filter(column.Name, column.PropertyType.Name);
                    listF.Add(tmp);
                }
                return listF;

            }
           
        }
        public List<Filter> GetTasksFilters()
        {
            List<Filter> listF = new List<Filter>();

            using (var context = new Model.SmartAgentDbEntities())
            {
                var data = context.Tasks.FirstOrDefault();
                var props = data.GetType().GetProperties();



                foreach (var column in props)
                {
                    //if ( column.PropertyType.IsInstanceOfType(typeof(System.String))){

                    //    Filter tmp = new Filter(column.Name, column.MemberType.ToString());
                    //    listF.Add(tmp);
                    //    string columnName = column.Name;
                    //    string columnValue = string.Empty;
                    //}
                    Filter tmp = new Filter(column.Name, column.PropertyType.Name);
                    listF.Add(tmp);
                }
                return listF;

            }

        }


    }
}