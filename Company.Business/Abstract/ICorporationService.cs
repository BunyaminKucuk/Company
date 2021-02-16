using Company.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Business.Abstract
{
    public interface ICorporationService
    {
        List<Corporation> GetAllCorporations();
        Corporation GetCorporationById(int id);
        Corporation CreateCorporation(Corporation corporation);
        Corporation UpdateCorporation(Corporation corporation);
        void DeleteCorporation(int id);
    }
}
