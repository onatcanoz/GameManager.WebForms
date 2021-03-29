using Backend.Contexts;
using Backend.Entities;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class OyunService //bu servisin bütün görevi oyun işlemlerini yönetmek.(Create , delete, update, add)
    {
        private readonly OyunYoneticisiContext _db = new OyunYoneticisiContext();   // _db objesini oluşturdun aşağılarda onu kullan. Aşağıda birdaha new'leme readonly olarak işaretle.

        //public List<Oyun> GetOyunList()    // sorguyu çalıştırıyorsun.
        //{
        //    return _db.Oyunlar.ToList();
        //}
        public IQueryable<OyunModel> GetQuery()//query : sorgu //sorguyu oluşturuyorsun çalıştırmıyorrsun.Sonucu almak istiyorsan tolist veya singleordefault,kullanıyoruz.Filtreleme yapabılıyoruz. Boş yere tüm listeleri çekmiyoruz.
        {
            //return _db.Oyunlar.Include("OyunTurler").Include("Yapimci").Select(oyun => new OyunModel())
            return _db.Oyunlar.Select(oyun => new OyunModel()//oyunlar farklı bir değer tipi olduğu için Select! bunu OyunModel tipine değiştirdi.     //select Id, Adi, Kazanci, YapimciId, YapimTarihi from Oyunlar
            {
                Id = oyun.Id,
                Adi = oyun.Adi,
                Kazanci = oyun.Kazanci,
                Maliyeti = oyun.Maliyeti,
                YapimciId = oyun.YapimciId,
                YapimTarihi = oyun.YapimTarihi,
                Yapimci = oyun.Yapimci.Adi + "(" + oyun.Yapimci.Ulke.Adi + ")",  //lazyloading
                //YapimTarihiFormat = 
                             //oyun.YapimTarihi.HasValue ? oyun.YapimTarihi.Value.ToShortDateString() : "" bunun Sql'de karşılığı yok.
                //entity den gelen yapım tarıhı null degılse yukardakı işlemi yap. null'sa null olsun.
                TurIdleri = oyun.OyunTurler.Select(oyuntur => oyuntur.TurId).ToList(),
                                          //listelerin değerini select'le değişiyoruz.
                Turler = oyun.OyunTurler.Select(oyunTur => new TurModel()
                {
                    Id = oyunTur.Tur.Id,
                    Adi = oyunTur.Tur.Adi
                }).ToList()
            });
            //service'in tek görevi entityden alıp modele set etmek olsun.
        }

        public void Add(OyunModel model)
        {
            Oyun entity = new Oyun()
            {
                Adi = model.Adi,
                Kazanci = model.Kazanci,
                Maliyeti = model.Maliyeti,
                YapimTarihi = model.YapimTarihi,
                YapimciId = model.YapimciId,
                OyunTurler = model.TurIdleri.Select(turId => new OyunTur()
                {
                    TurId=turId
                }).ToList()
            };
            _db.Oyunlar.Add(entity);
            _db.SaveChanges();
        }

        public void Update(OyunModel model)
        {
            Oyun oyun = _db.Oyunlar.Find(model.Id);    //lazyloading kullanmasaydım "İnclude" kullanacaktım burada.
            oyun.Adi = model.Adi;
            oyun.Kazanci = model.Kazanci;
            oyun.Maliyeti = model.Maliyeti;
            oyun.YapimTarihi = model.YapimTarihi;
            oyun.YapimciId = model.YapimciId;

            _db.OyunlarTurler.RemoveRange(oyun.OyunTurler); //oyundakı oyuntur kayıtlarını siliyor.
            //oyun.OyunTurler = new List<OyunTur>();                1.YÖNTEM
            //foreach (int turId in model.TurIdleri)
            //{
            //    oyun.OyunTurler.Add(new OyunTur()
            //    {
            //        OyunId = oyun.Id,
            //        TurId = turId
            //    });
            //}

            oyun.OyunTurler = model.TurIdleri.Select(turId => new OyunTur()
            {
                OyunId = oyun.Id,
                TurId = turId
            }).ToList();

            _db.Entry(oyun).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Oyun entity = _db.Oyunlar.Find(id);
            _db.OyunlarTurler.RemoveRange(entity.OyunTurler);
            _db.Oyunlar.Remove(entity);
            _db.SaveChanges();
        }
    }
}
