using Backend.Records.Bases;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class OyunModel : RecordBase
    {
        //entity
        public string Adi { get; set; }
        public Nullable<double> Maliyeti { get; set; }
        public double? Kazanci { get; set; }
        public int? YapimciId { get; set; }
        public DateTime? YapimTarihi { get; set; }

        //custom
        public string Yapimci { get; set; }
        public string YapimTarihiFormat => YapimTarihi.HasValue ? YapimTarihi.Value.ToShortDateString() : "";
        //yapımtarihine sahipse bu yapım tarihini shortdate'e dönüştürsün eğer yoksa null göndersin.
        //Amacı sadece gösterim set etmicez. Bundan dolayı sadece get metodunu yazıyoruz.
        //Encapsulation yaptık.
        public string KarZarar => Kazanci != null && Maliyeti != null ? (Kazanci.Value - Maliyeti.Value).ToString("C2",
         new CultureInfo("tr")) : "";
        //set etmeye gerek yok kullanıcıdan bunu girmesini istemicez.
        //kazanci ve maliyetinin değeri varsa çıkar. Eğer yoksa null ata.
        //standart numeric format string tostring'in yanındaki ("C2").docs.microsoft.com'dan bu simgelere bakabilirsin.

        public List<int> TurIdleri { get; set; }

        public List<TurModel> Turler { get; set; }   //amacı verileri çekebilmek.
        public string TurlerText                     //amacı gösterim.
        {
            get
            {
                //string turler = "";
                //if (Turler != null && Turler.Count > 0)
                //{
                //    foreach (TurModel tur in Turler)
                //    {
                //        turler += tur.Adi + "\n";
                //    }
                //}
                //return turler;
                return string.Join("<br />", Turler.Select(tur => tur.Adi).ToList());
            }
        }
    }
}
