using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.DataAccess.Abstract
{
    public interface ICollectionRepository
    {
        List<Collection> GetAllCollections();
        Collection GetCollectionById(int id);
        List<Collection> GetCollectionByProject(int id);
        Collection CreateCollection(Collection collection);
        Collection UpdateCollection(Collection collection);
        void DeleteCollection(int id);
    }
}
