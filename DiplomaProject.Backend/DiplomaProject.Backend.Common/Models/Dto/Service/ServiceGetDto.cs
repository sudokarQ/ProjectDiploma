﻿namespace DiplomaProject.Backend.Common.Models.Dto.Service
{
    public class ServiceGetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TypeService { get; set; }
        public decimal? Price { get; set; }
    }
}