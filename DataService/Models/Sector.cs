using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataService.Models;

namespace DataService.models
{
    public class Sector
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<House> houses { get; set; }
    }
}