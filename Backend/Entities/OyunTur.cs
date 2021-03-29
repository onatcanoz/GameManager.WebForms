using Backend.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class OyunTur : RecordBase
    {
        public int OyunId { get; set; }
        public virtual Oyun Oyun { get; set; }//ilişkileri oluşturuyorum.Veritabanımız ilişkili olduğu için ilişkili olduğu tablolarıda getirmeni sağlar.
        public int TurId { get; set; }
        public virtual Tur Tur { get; set; }// ilişkileri oluşturuyorum.
    }
}
