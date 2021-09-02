using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestWebApp1.Areas.DAO;
using TestWebApp1.Models;

namespace TestWebApp1.Areas.Repostories
{
    public class RulesRepository: IRulesRepository
    {
        private IRulesDAO _rulesDAO { get; }
        public RulesRepository(IRulesDAO rulesDAO)
        {
            _rulesDAO = rulesDAO;
        }
        public List<Rules> GetRules()
        {
            return _rulesDAO.GetRules();
        }
    }
}