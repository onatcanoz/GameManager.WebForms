using Backend.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Ulke : RecordBase
    {
        public string Adi { get; set; }

        //ulkede birden çok yapımcı olması lazım.         Yapimciyada ulkeyi ekliyorum.
        public virtual List<Yapimci> Yapimcilar { get; set; }
    }
}
