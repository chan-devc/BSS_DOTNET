using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

namespace BSSAPI.model
{
    public class OracleContext : Openceonection
    {
        public List<ESIM> GetData(string serial)
        {

            connectString();

            string query = "SELECT IMSI, SERIAL  FROM CUS_OWNER.STOCK_SIM WHERE SERIAL = '" + serial + "'";
            using (OracleCommand command = new OracleCommand(query, conn))
            using (OracleDataReader reader = command.ExecuteReader())
            {
                List<ESIM> result = new List<ESIM>();

                while (reader.Read())
                {
                    result.Add(new ESIM
                    {
                        imsi = reader.GetString(0),
                        serail = reader.GetString(1),
                    });
                }
                return result;
            }
        }
    }
}