using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.CrossCutting.Dtos;
using SzkolenieTechniczne.Common.CrossCutting.ValidationAttributes;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class JobPositionDto
    {
        public Guid Id { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        [LocalizedStringRequiredAttribute]
        [LocalizedStringLenghtAttribute(256)]
        public LocalizedString Name { get; set; }

        public short? WorkingHours { get; set; }

        
        public decimal GrossSalary { get; set; }

       
        
        public short WorkingWeekHours { get; set; }

    }
}
