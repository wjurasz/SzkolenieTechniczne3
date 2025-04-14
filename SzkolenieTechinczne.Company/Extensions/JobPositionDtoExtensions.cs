using System.Collections.Generic;
using System.Linq;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.CrossCutting.Dtos;
using SzkolenieTechniczne.Company.Storage.Entities;

namespace SzkoleniteTechniczne.Company.Extensions
{
    public static class JobPositionDtoExtension
    {
        public static JobPositionDto ToDto(this JobPosition entity)
        {
            return new JobPositionDto
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                GrossSalary = entity.GrossSalary,
                WorkingHours = entity.WorkingHours,
                WorkingWeekHours = entity.WorkingWeekHours,

                Name = new LocalizedString(
                    entity.Translations?
                        .ToDictionary(t => t.LanguageCode, t => t.Name)
                    ?? new Dictionary<string, string>()
                )
            };
        }
    }
}