﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public class CompanyRequestObject
    {
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        public IFormFile? Logo { get; set; }
        public bool IsValidFile => Logo?.Length > 0;
        public bool IsValidParams => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Name);
    }
}
