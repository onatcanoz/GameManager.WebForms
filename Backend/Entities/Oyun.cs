using Backend.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Oyun : RecordBase
    {
        public string Adi { get; set; }
        public Nullable<double> Maliyeti { get; set; }   //null'a izin verdiği için nullable olması lazım.
        public double? Kazanci { get; set; }  //yukardaki yerine bunu kullan aynı şey.
        public int? YapimciId { get; set; }
        public virtual Yapimci Yapimci { get; set; } //yapimci tipinde yapimci oluşturun. OyunId uzerınden yapımcı bılgılerıne de ulaşabılırsın bunun sayesinde.//ilişkileri oluşturuyorum. Referans.
        public DateTime? YapimTarihi { get; set; }

        public virtual List<OyunTur> OyunTurler { get; set; }//virtual tanımlamazsan otomatik dolu gelmez.//ilişkileri oluşturuyorum.   // Lazyloading kullanacaksan bunu kesinlikle virtual tanımlamak lazım.
    }
}

