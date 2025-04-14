using Microsoft.EntityFrameworkCore;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;
using SzkoleniteTechniczne.Company.Extensions;
using SzkolenieTechniczne.Company.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SzkolenieTechniczne.Geo.Storage;

namespace SzkolenieTechniczne.Company.Services
{
    public class JobPositionService
    {
        private readonly CompanyDbContext _context;

        public JobPositionService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<List<JobPositionDto>> GetAllAsync()
        {
            var entities = await _context.JobPositions
                .Include(j => j.Translations)
                .ToListAsync();

            return entities.Select(e => e.ToDto()).ToList();
        }

        public async Task<JobPositionDto?> GetByIdAsync(Guid id)
        {
            var entity = await _context.JobPositions
                .Include(j => j.Translations)
                .FirstOrDefaultAsync(e => e.Id == id);

            return entity?.ToDto();
        }

        public async Task<JobPositionDto> CreateAsync(JobPositionDto dto)
        {
            var entity = dto.ToEntity();
            _context.JobPositions.Add(entity);
            await _context.SaveChangesAsync();
            return entity.ToDto();
        }

        public async Task<JobPositionDto?> UpdateAsync(JobPositionDto dto)
        {
            var existing = await _context.JobPositions
                .Include(j => j.Translations)
                .FirstOrDefaultAsync(e => e.Id == dto.Id);

            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(dto.ToEntity());
            existing.Translations = dto.Name.ToDictionary()
                .Select(kv => new JobPositionTranslation
                {
                    LanguageCode = kv.Key,
                    Name = kv.Value
                }).ToList();

            await _context.SaveChangesAsync();
            return existing.ToDto();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.JobPositions.FindAsync(id);
            if (entity == null) return false;

            _context.JobPositions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
