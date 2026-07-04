using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Adapter
{
    public class Data
    {
        public string GetData()
        {
            return "<BudgetMax>$1000000</BudgetMax>" +
                    "<BudgetMin>$600000</BudgetMin>";
        }
    }
}
