using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("JobPositionTranslations", Schema = "Company")]
    public class JobPositionTranslation : BaseTranslation
    {
        [Required]
        public Guid JobPositionId { get; set; }

        [Required]
        public JobPosition JobPosition { get; set; } = null!;

        [MaxLength(256)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; } = null!;

        [MaxLength(1024)]
        public string? Responsibilities { get; set; }

        [MaxLength(1024)]
        public string? Description { get; set; }
    }
}
