using SzkolenieTechniczne.Geo.CrossCutting.Dtos;
using SzkolenieTechniczne.Geo.Storage.Entities;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace SzkolenieTechniczne.GEO.Extensions
{
    public static class CityExtension
    {
        public static CityDto toDto(this City entity)
        {
            var result = new CityDto
            {
                Id = entity.Id,
                //Name = new LocalizedString(entity.Translations.Select(t => new KeyValuePair<string , string>(t.LanguageCode , t.Name))),
            };
            return result;
        }
    }
}
