using System;
using System.Collections.Generic;
using System.Text;
using Company.Business.Abstract;
using Company.DataAccess.Abstract;
using Company.DataAccess.Concrete;
using Company.Entities;

namespace Company.Business.Concrete
{
    public class CollectionManager : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        public CollectionManager()
        {
            _collectionRepository=new CollectionRepository();
        }

        public Collection CreateCollection(Collection collection)
        {
            return _collectionRepository.CreateCollection(collection);
        }

        public void DeleteCollection(int id)
        {
            _collectionRepository.DeleteCollection(id);
        }

        public List<Collection> GetAllCollections()
        {
            return _collectionRepository.GetAllCollections();
        }

        public Collection GetCollectionById(int id)
        {
            if (id > 0)
            {
                return _collectionRepository.GetCollectionById(id);
            }
            throw new Exception("id birden küçük olamaz");
        }

        public List<Collection> GetCollectionByProject(int id)
        {
            return _collectionRepository.GetCollectionByProject(id);
        }

        public Collection UpdateCollection(Collection collection)
        {
            return _collectionRepository.UpdateCollection(collection);
        }
    }
}
