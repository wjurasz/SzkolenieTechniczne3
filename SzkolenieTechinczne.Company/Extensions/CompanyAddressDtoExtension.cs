using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkoleniteTechniczne.Company.Extensions
{
    public static class CompanyAddressExtension
    {
        public static CompanyAddress ToEntity(this CompanyAddressDto dto)
        {
            return new CompanyAddress
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                CountryId = dto.CountryId,
                Post = dto.Post,
                Province = dto.Province,
                District = dto.District,
                Community = dto.Community,
                City = dto.City,
                Street = dto.Street,
                FlatNumber = dto.FlatNumber,
                HouseNumber = dto.HouseNumber
            };
        }
    }
}