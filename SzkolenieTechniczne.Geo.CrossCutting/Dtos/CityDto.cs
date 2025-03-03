using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.ValidationAttributes;

namespace SzkolenieTechniczne.Geo.CrossCutting.Dtos
{
    public class CityDto
    {
        public Guid Id { get; set; }


        [LocalizedStringRequired]
        [LocalizedStringLenght(32)]
        public LocalizedString Name { get; set; }

        [MaxLength(256)]
        [MinLength(1)]
        public string City { get; set; }
    }
}
