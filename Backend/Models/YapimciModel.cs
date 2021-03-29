using Backend.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class YapimciModel : RecordBase
    {
        public string Adi { get; set; }
        public int UlkeId { get; set; }
        public string UlkeAdi { get; set; }
    }
    
}
