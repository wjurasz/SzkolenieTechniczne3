using System.Linq;
using System.Collections.Generic;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkoleniteTechniczne.Company.Extensions
{
    public static class JobPositionExtension
    {
        public static JobPosition ToEntity(this JobPositionDto dto)
        {
            return new JobPosition
            {
                Id = dto.Id,
                CompanyId = dto.CompanyId,
                GrossSalary = dto.GrossSalary,
                WorkingHours = dto.WorkingHours,
                WorkingWeekHours = dto.WorkingWeekHours,

                Translations = dto.Name?.ToDictionary()
                    .Select(kv => new JobPositionTranslation
                    {
                        LanguageCode = kv.Key,
                        Name = kv.Value
                    }).ToList()
                    ?? new List<JobPositionTranslation>()
            };
        }
    }
}
