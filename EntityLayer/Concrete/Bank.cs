using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancalCrm.Entity.Concrete
{
    public class Bank:BaseEntity
    {
        //Entity sınıfları veritabanındaki Tabloları temsil eder,
        //Sınıf içerisindeki propertyler Tablo içerikleridir,
        //Eğer bir tablo bir tablo ile ilişki içerisindeyse burada belirtilir,

        //Bir banka nın birden fazla bankaİşlemi olabileceği için bunu List türünde ekledik,Buna Navigation property denir.
        //Navigation property tekli ise onun örneği bankProcess sınıfında yazıyor.
        public int BankId { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankTitle { get; set; }
        public decimal BankBalance { get; set; }

        public virtual List<BankProcess> BankProcesses { get; set; }

    }
}
