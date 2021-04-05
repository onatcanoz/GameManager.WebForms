using Backend.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Yapimci : RecordBase
    {
        public string Adi { get; set; }
        public int UlkeId { get; set; }
        public virtual Ulke Ulke { get; set; }
        public virtual List<Oyun> Oyunlar { get; set; }
    }
}
