using Backend.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Tur : RecordBase
    {
        public string Adi { get; set; }
        public virtual List<OyunTur> OyunTurler { get; set; }//bir türün birden çok oyun kayıdı vvar.
    }
}
