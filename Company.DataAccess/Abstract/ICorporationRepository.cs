using System;
using System.Collections.Generic;
using System.Text;
using Company.Entities;

namespace Company.DataAccess.Abstract
{
    public interface ICorporationRepository
    {
        List<Corporation> GetAllCorporations();
        Corporation GetCorporationById(int id);
        Corporation CreateCorporation(Corporation corporation);
        Corporation UpdateCorporation(Corporation corporation);
        void DeleteCorporation(int id);
    }
}
