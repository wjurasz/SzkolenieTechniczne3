using System.Linq;
using System.Collections.Generic;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyExtension
    {
        public static CrossCutting.Dtos.CompanyDto ToDto(this SzkolenieTechniczne.Company.Storage.Entities.Company entity)
        {
            var result = new CrossCutting.Dtos.CompanyDto
            {
                Id = entity.Id,
                Name = entity.Name,
                NIP = entity.NIP,
                REGON = entity.REGON,
                PhoneDirectional = entity.PhoneDirectional,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address?.ToDto()

            };

            return result;
        }
    }
}
