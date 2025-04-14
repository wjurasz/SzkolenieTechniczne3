using Microsoft.EntityFrameworkCore;
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
    [Index(nameof(Name), IsUnique = false)]
    [Table("ContactTypeTranslations", Schema = "Dictionaries")]
    public class ContactTypeTranslation : BaseTranslation
    {
        [Required]
        public long ContactTypeId { get; set; }

        [Required]
        public ContactType ContactType { get; set; } = null!;

        [MaxLength(100)]
        [MinLength(2)]
        [Required]
        public string Name { get; set; } = null!;
    }
}
