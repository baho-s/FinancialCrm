
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancalCrm.Entity.Concrete
{
    public class Category:BaseEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual List<Spending> Spendings { get; set; }
        
    }
}
