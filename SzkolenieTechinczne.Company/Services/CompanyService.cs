using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Extensions;
using SzkolenieTechniczne.Company.Storage;
using SzkolenieTechniczne.Geo.Storage;
using SzkoleniteTechniczne.Company.Extensions;

namespace SzkolenieTechniczne.Company.Services
{
    public class CompanyService
    {
        private readonly CompanyDbContext _context;

        public CompanyService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<List<CompanyDto>> GetAllAsync()
        {
            var companies = await _context.Companies
                .Include(c => c.Address)
                .Include(c => c.JobPositions)
                    .ThenInclude(j => j.Translations)
                .ToListAsync();

            return companies.Select(c => c.ToDto()).ToList();
        }

        public async Task<CompanyDto?> GetByIdAsync(Guid id)
        {
            var company = await _context.Companies
                .Include(c => c.Address)
                .Include(c => c.JobPositions)
                    .ThenInclude(j => j.Translations)
                .FirstOrDefaultAsync(c => c.Id == id);

            return company?.ToDto();
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
    }
}