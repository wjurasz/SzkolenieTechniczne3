﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne.Common.Storage.Entities;

namespace SzkolenieTechniczne.Company.Storage.Entities
{
    [Table("CompanyAddresses", Schema ="Company")]
    public class CompanyAddress : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        [MaxLength(256)]
        public string? Post { get; set; }

        [MaxLength(256)]
        public string? Province { get; set; }

        [MaxLength(256)]
        public string? District { get; set; }

        [MaxLength(256)]
        public string? Community { get; set; }

        [MaxLength(256)]
        public string? City { get; set; }

        [MaxLength(256)]
        public string? Street { get; set; }

        [MaxLength(16)]
        public string? FlatNumber { get; set; }

        [MaxLength(16)]
        public string? HouseNumber { get; set; }
    }
}
