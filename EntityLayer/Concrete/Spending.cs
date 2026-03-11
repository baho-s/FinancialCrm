using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancalCrm.Entity.Concrete
{
    public class Spending
    {
        public int SpendingId { get; set; }
        public string SpendingTitle { get; set; }
        public decimal SpendingAmount { get; set; }
        public DateTime SpendingDate { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
