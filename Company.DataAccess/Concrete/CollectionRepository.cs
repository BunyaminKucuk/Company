using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Company.DataAccess.Abstract;
using Company.Entities;
using Microsoft.EntityFrameworkCore;


namespace Company.DataAccess.Concrete
{
    public class CollectionRepository : ICollectionRepository
    {
        public Collection CreateCollection(Collection collection)
        {
            using var collectionDbContext = new CompanyDbContext();
            collectionDbContext.Collections.Add(collection);
            collectionDbContext.SaveChanges();
            return collection;
        }

        public void DeleteCollection(int id)
        {
            using var collectionDbContext = new CompanyDbContext();
            var deletedCollection = GetCollectionById(id);
            collectionDbContext.Collections.Remove(deletedCollection);
            collectionDbContext.SaveChanges();
        }

        public List<Collection> GetAllCollections()
        {
            using var collectionDbContext = new CompanyDbContext();
            return collectionDbContext.Collections.ToList();
        }


        public List<Collection> GetCollectionByProject(int id)
        {
            using var collectionDbContext = new CompanyDbContext();
            return collectionDbContext.Collections.Where(a => a.ProjectId == id).ToList();
        }

        public Collection GetCollectionById(int id)
        {
            using var collectionDbContext = new CompanyDbContext();
            return collectionDbContext.Collections.Find(id);
        }

        public Collection UpdateCollection(Collection collection)
        {
            using var collectionDbContext = new CompanyDbContext();
            collectionDbContext.Collections.Update(collection);
            collectionDbContext.SaveChanges();
            return collection;
        }
        
        public void TotalCollection()
        {
            using var collectionDbContext = new CompanyDbContext();
            collectionDbContext.Collections.FromSqlRaw("exec dbo.spTotalAmount").ToListAsync().Result.FirstOrDefault();
        }
    }
}
