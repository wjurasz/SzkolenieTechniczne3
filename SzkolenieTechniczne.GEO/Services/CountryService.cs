using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Common.API.Service;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.Enums;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.GEO.Extensions;

namespace SzkolenieTechniczne.GEO.Services
{
    public class CountryService : CrudServiceBase<GeoDbContext, Country, CountryDto>
    {
        private GeoDbContext _geoDbContext;

        public CountryService(GeoDbContext geoDbContext) : base(geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CountryDto> GetById(Guid id)
        {
            var country = await base.GetById(id);

            return country.ToDto();
        }

        public async Task<IEnumerable<CountryDto>> Get()
        {
            var cities = await base.Get();

            return cities.Select(c => c.ToDto());
        }

        public async Task<CrudOperationResult<CountryDto>> Create(CountryDto dto)
        {
            var entity = dto.ToEntity();

            var entityId = await base.Create(entity);

            var newDto = await GetById(entityId);

            return new CrudOperationResult<CountryDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }
        public async Task<CrudOperationResult<CountryDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<CountryDto>> Update(CountryDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }



    }
}
