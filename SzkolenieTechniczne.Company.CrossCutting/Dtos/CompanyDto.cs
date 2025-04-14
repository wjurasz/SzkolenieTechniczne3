using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Company.CrossCutting.Dtos
{
    public class CompanyDto
    {
        public Guid Id { get; set; }

        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        [MaxLength(32)]
        [Required]
        public string NIP { get; set; }
        public string REGON { get; set; }

        [MaxLength(8)]
        public string PhoneDirectional { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        //public List<CompanyAddressDto> Addresses { get; set; }

        public CompanyAddressDto? Address { get; set; }
        
    }
}
