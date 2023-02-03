﻿using System.ComponentModel.DataAnnotations;

namespace DiplomaProject.Backend.Common.Models.Dto.Service
{
    public class ServicePostDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string TypeService { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
