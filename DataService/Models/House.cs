using System;
using System.ComponentModel.DataAnnotations;
using DataService.models;

namespace DataService.Models
{
    public class House
    {
        public Guid Id { get; set; }
        [Required]
        public string SectorName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int BuildingNumber { get; set; }
        public string BuildingNumberPrefix { get; set; }
        public Guid SectorId { get; set; }
        public Sector Sector { get; set; }
    }
}