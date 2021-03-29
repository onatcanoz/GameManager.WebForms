using Backend.Contexts;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class TurService
    {
        private readonly OyunYoneticisiContext _db = new OyunYoneticisiContext();

        public IQueryable<TurModel> GetQuery()
        {
            return _db.Turler.OrderBy(tur => tur.Adi).Select(tur => new TurModel()
            {
                Id = tur.Id,
                Adi = tur.Adi
            });
        }
    }
}
