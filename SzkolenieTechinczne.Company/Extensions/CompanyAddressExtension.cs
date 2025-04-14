using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkolenieTechniczne.Company.Extensions
{
    public static class CompanyAddressExtension
    {
        public static CompanyAddressDto ToDto(this CompanyAddress entity)
        {
            return new CompanyAddressDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                CountryId = entity.CountryId,
                Post = entity.Post,
                Province = entity.Province,
                District = entity.District,
                Community = entity.Community,
                City = entity.City,
                Street = entity.Street,
                FlatNumber = entity.FlatNumber,
                HouseNumber = entity.HouseNumber
            };
        }
    }
}