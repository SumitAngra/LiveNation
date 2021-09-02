using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TestWebApp1.Models;

namespace TestWebApp1.Areas.DAO
{
    public class RulesDAO: IRulesDAO
    {
        private readonly string _connstring;

        public RulesDAO()
        {
            _connstring = ConfigurationManager.ConnectionStrings["rules"].ConnectionString;
        }
        public List<Rules> GetRules()
        {
            using(IDbConnection db = new SqlConnection(_connstring))
            {
               return db.Query<Rules>(@"SELECT r.id,r.ruleName,r.propertyName,r.operation,r.value,r.ComparisonOperation,r.ComparisonValue,r.output FROM rules r;").ToList();
            }
        }
    }
}