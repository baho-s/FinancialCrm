using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class BillDashboardDto
    {
        // DTO(Data Transfer Object)
        // Katmanlı mimaride veriyi katmanlar arasında taşımak için kullanılan özel bir modeldir.
        // Entity sınıflarını doğrudan UI katmanına göndermek yerine DTO kullanılır.
        //
        // Neden DTO kullanılır?
        // - Gereksiz alanların taşınmasını engeller
        // - Güvenliği artırır
        // - Performansı artırır
        //
        // Bu DTO, faturaların başlığı ve tutarını birlikte taşımak için oluşturulmuştur.

        public string BillTitle { get; set; }
        public decimal BillAmount { get; set; }
    }
}
