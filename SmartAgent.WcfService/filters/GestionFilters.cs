using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartAgent.WcfService.filters
{
    public class GestionFilters
    {
        Filter[] getTaskFilters()
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                //    Filter[] agents = context.Agents.Where(a => a.FirstName.Contains(nom)).ToArray().Select(a => new AgentDTO(a)).ToArray();

                //    context.Agents.Select(x => x.).ToArray()

                //    context.SaveChanges();
                //}
                return null;
            }
        }
        Filter[] GetAgentFilters()
        {
            using (var context = new Model.SmartAgentDbEntities())
            {
                
                return null;
            }
        }
    }
}