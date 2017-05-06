using EventService.DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService
{
    public partial class EventService
    {
        private int create(Event e)
        {
            using (DbConnection connection = EventData.DBConnection.GetConnection(ConfigurationManager.AppSettings["connString"]))
            {
                
            }

            return 0;
        }
    }
}
