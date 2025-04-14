using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("Companies", Schema ="Company")]
    public class Company : BaseEntity
    {
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }

        public CompanyAddress Address { get; set; }

        [MaxLength(8)]
        public string PhoneDirectional { get; set; }

        [MaxLength(32)]
        public string PhoneNumber { get; set; }

        [MaxLength(32)]
        public string NIP { get; set; } = null!;

        [MaxLength(16)]
        public string REGON { get; set; }

        public ICollection<JobPosition> JobPositions { get; set; } = new HashSet<JobPosition>();
    }
}
