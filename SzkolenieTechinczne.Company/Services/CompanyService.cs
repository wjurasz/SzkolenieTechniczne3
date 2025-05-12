using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SzkolenieTechinczne.Company.Resolvers;
using SzkolenieTechniczne.Common.API.Service;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.Enums;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Extensions;
using SzkolenieTechniczne.Company.Storage;
using SzkolenieTechniczne.Geo.Storage;
using SzkoleniteTechniczne.Company.Extensions;

namespace SzkolenieTechniczne.Company.Services
{
    public class CompanyService : CrudServiceBase<CompanyDbContext, SzkolenieTechniczne.Company.Storage.Entities.Company, CompanyDto>
    {
        private readonly CountryIntegrationDataResolver _countryResolver;
        private readonly CompanyDbContext _context;

        public CompanyService(CompanyDbContext context, CountryIntegrationDataResolver countryResolver) : base(context)
        {
            _countryResolver = countryResolver;
            _context = context;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var companies = await base.Get();

            return companies.Select(e => e.ToDto());
        }

        public async Task<CompanyDto?> GetByIdAsync(Guid id)
        {
            var city = await base.GetById(id);
            return city.ToDto();
        }

        public async Task<CompanyDto> CreateAsync(CompanyDto dto)
        {
            var entity = dto.ToEntity();
            _context.Companies.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.Companies.FindAsync(id);
            if (entity == null) return false;

            _context.Companies.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        protected override IQueryable<Storage.Entities.Company> ConfigureFromIncludes(IQueryable<Storage.Entities.Company> linq)
        {
            return linq
                .Include(c => c.Address)
                .Include(c => c.JobPositions)
                .ThenInclude(j => j.Translations);
        }

        protected override async Task OnBeforeRecordCreateAsync(CompanyDbContext context, SzkolenieTechniczne.Company.Storage.Entities.Company entity)
        {
            if (entity.Address != null)
            {
                await _countryResolver.ResolveFor(entity.Address.CountryId);
            }
        }

    }
}