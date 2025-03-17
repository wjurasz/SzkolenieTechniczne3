using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;

namespace SzkolenieTechniczne.GEO.Extensions
{
    public static class CityDtoExtensions
    {
        public static City ToEntity(this CityDto dto)
        {
            return new City
            {
                Id = dto.Id,
                CountryId = dto.CountryId
            };
        }
    }
}
