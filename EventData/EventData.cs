using System;
using System.Data.Common;

namespace EventData
{
    public class EventData
    {
        public int Create<T>(T obj, DbConnection connection)
        {

            return 0;
        }

        public T Read<T>(int id)
        {
            return default(T);
        }

        public void Update<T>(T obj)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete<T>(int id)
        {
            return false;
        }
    }
}
