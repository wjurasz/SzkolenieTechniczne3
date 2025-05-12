using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.Enums;
using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.GEO.Extensions;
using SzkolenieTechniczne.Common.API.Service;


namespace SzkolenieTechniczne.GEO.Services
{
    public class CityService : CrudServiceBase<GeoDbContext, City, CityDto>
    {
        private GeoDbContext _geoDbContext;

        public CityService(GeoDbContext geoDbContext) : base(geoDbContext)
        {
            _geoDbContext = geoDbContext;
        }

        public async Task<CityDto> GetById(Guid id)
        {
            var city = await base.GetById(id);
            return city.ToDto();
        }

        public async Task<IEnumerable<CityDto>> Get()
        {
            var cities = await base.Get();
               
            return cities.Select(x => x.ToDto());
        }
        public async Task<CrudOperationResult<CityDto>> Create(CityDto dto)
        {
            var entity = dto.ToEntity();
            var entityId = await base.Create(entity);
            var newDto = await GetById(entityId);

            return new CrudOperationResult<CityDto>
            {
                Result = newDto,
                Status = CrudOperationResultStatus.Success
            };
        }

        public async Task<CrudOperationResult<CityDto>> Delete(Guid id)
        {
            return await base.Delete(id);
        }

        public async Task<CrudOperationResult<CityDto>> Update(CityDto dto)
        {
            var entity = dto.ToEntity();
            return await base.Update(entity);
        }
        
    }
}

