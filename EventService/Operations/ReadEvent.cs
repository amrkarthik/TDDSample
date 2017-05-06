using EventService.DataContracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventService
{
    public partial class EventService
    {
        private Event Read(int id)
        {
            using (DbConnection connection = EventData.DBConnection.GetConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            {

            }
            return new Event();
        }
    }
}
