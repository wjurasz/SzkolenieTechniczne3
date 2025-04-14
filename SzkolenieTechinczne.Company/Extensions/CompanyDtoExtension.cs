using System.Linq;
using System.Collections.Generic;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Extensions;

namespace SzkoleniteTechniczne.Company.Extensions
{
    public static class CompanyDtoExtension
    {
        public static SzkolenieTechniczne.Company.Storage.Entities.Company ToEntity(this CompanyDto entity)
        {
            var result = new SzkolenieTechniczne.Company.Storage.Entities.Company
            {
                Id = entity.Id,
                Name = entity.Name,
                NIP = entity.NIP,
                REGON = entity.REGON,
                PhoneDirectional = entity.PhoneDirectional,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address?.ToEntity(),

            };

            return result;
        }
    }
}