using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancalCrm.Entity.Concrete
{
    public class BankProcess
    {
        public int BankProcessId { get; set; }
        public string Sender { get; set; }
        public string Description { get; set; }
        public DateTime ProcessDate { get; set; }
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public int BankId { get; set; }
        
        //Banka işlemi tek bir bankaya bağlı olduğu için navigation property sınıf adı ile tanımlanır,
        //Bank sınıfından Bank nesnesi ile get ve set edilir.
        public virtual Bank Bank { get; set; } //Navigation property.
    }
}
