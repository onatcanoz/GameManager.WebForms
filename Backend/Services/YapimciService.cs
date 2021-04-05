using Backend.Contexts;
using Backend.Entities;
using Backend.Models;
using System;
using System.Linq;

namespace Backend.Services
{
    public class YapimciService
    {
        private readonly OyunYoneticisiContext _db = new OyunYoneticisiContext();

        public IQueryable<YapimciModel> GetQuery()
        {
            return _db.Yapimcilar.OrderBy(yapimci => yapimci.Adi).Select(yapimci => new YapimciModel()
            //OrderBy ile ada göre sıraladık.
            {
                Adi = yapimci.Adi,
                Id = yapimci.Id,
                UlkeId = yapimci.UlkeId,
                UlkeAdi = yapimci.Ulke.Adi
            });
        }

        public IQueryable<YapimciModel> GetQueryUlke()
        {
            return _db.Ulkeler.Select(ulke => new YapimciModel()
            {
                UlkeAdi = ulke.Adi,
                UlkeId = ulke.Id
            });
        }

        public void Add(YapimciModel model)
        {
            Yapimci entity = new Yapimci()
            {
                Adi = model.Adi,
                UlkeId = model.UlkeId
            };
            _db.Yapimcilar.Add(entity);
            _db.SaveChanges();
        }

        public void Guncelle(YapimciModel model)
        {
            Yapimci yapimci = _db.Yapimcilar.Find(model.Id);
            yapimci.Adi = model.Adi;
            yapimci.UlkeId = model.UlkeId;

            _db.Entry(yapimci).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Yapimci entity = _db.Yapimcilar.Find(id);
            if (entity.Oyunlar.Count == 0)
            {
                _db.Yapimcilar.Remove(entity);
                _db.SaveChanges();
            }
        }
    }
}