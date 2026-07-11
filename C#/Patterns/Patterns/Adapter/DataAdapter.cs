using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    public class DataAdapter
    {
        public string XmlToJson(string xml)
        {
            string res = "{\"BudgetMax\": \"$1000000\", \"BudgetMin\": \"$600000\"}";
            return res;
        }
    }
}
