using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.DataAccess.Abstract;
using Company.Entities;

namespace Company.DataAccess.Concrete
{
    public class CorporationRepository : ICorporationRepository
    {
        public Corporation CreateCorporation(Corporation corporation)
        {
            using var corporationDbContext = new CompanyDbContext();
            corporationDbContext.Corporations.Add(corporation);
            corporationDbContext.SaveChanges();
            return corporation;
        }

        public void DeleteCorporation(int id)
        {
            using var corporationDbContext = new CompanyDbContext();
            var deletedCorportion = GetCorporationById(id);
            corporationDbContext.Corporations.Remove(deletedCorportion);
            corporationDbContext.SaveChanges();
        }

        public List<Corporation> GetAllCorporations()
        {
            using var corporationDbContext=new CompanyDbContext();
            return corporationDbContext.Corporations.ToList();
;        }

        public Corporation GetCorporationById(int id)
        {
            using var corporationDbContext = new CompanyDbContext();
            return corporationDbContext.Corporations.Find(id);
        }

        public Corporation UpdateCorporation(Corporation corporation)
        {
            using var corporationDbContext = new CompanyDbContext();
            corporationDbContext.Corporations.Update(corporation);
            corporationDbContext.SaveChanges();
            return corporation;
        }
    }
}
