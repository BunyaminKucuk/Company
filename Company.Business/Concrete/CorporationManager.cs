using System;
using System.Collections.Generic;
using System.Text;
using Company.Business.Abstract;
using Company.DataAccess.Abstract;
using Company.DataAccess.Concrete;
using Company.Entities;

namespace Company.Business.Concrete
{
    public class CorporationManager : ICorporationService
    {
        private readonly ICorporationRepository _corporationRepository;

        public CorporationManager()
        {
            _corporationRepository = new CorporationRepository();
        }
        public Corporation CreateCorporation(Corporation corporation)
        {
            return _corporationRepository.CreateCorporation(corporation);
        }

        public void DeleteCorporation(int id)
        {
            _corporationRepository.DeleteCorporation(id);
        }

        public List<Corporation> GetAllCorporations()
        {
            return _corporationRepository.GetAllCorporations();
        }

        public Corporation GetCorporationById(int id)
        {
            if (id >= 0)
            {
                return _corporationRepository.GetCorporationById(id);
            }
            throw  new Exception("id birden küçük olamaz");
        }

        public Corporation UpdateCorporation(Corporation corporation)
        {
            return _corporationRepository.UpdateCorporation(corporation);
        }
    }
}
