﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Certification : BaseEntity
    {
        [Required, Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        [Required, Column(TypeName = "nvarchar(100)")]
        public string IssuingBody { get; set; }
        [Required]
        public DateTime IssuingDate { get; set; }
        [ForeignKey(nameof(UserInformation))]
        public Guid UserInformationId { get; set; }
        public UserInformation? UserInformation { get; set; }
    }
}