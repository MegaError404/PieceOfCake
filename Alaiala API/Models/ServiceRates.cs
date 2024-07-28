﻿using Alaiala_API.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Alaiala_API.Models
{
    public class ServiceRates
	{
        [Required,Key]
        public int Id { get; set; }
        
        [Required]
        public Guid GUID { get; set; } = Guid.Empty;

        [Required]
        public Guid UserGUID { get; set; } = Guid.Empty;

        [Required]
        public UsersTypes UserType { get; set; } = UsersTypes.None;

        [Required]
        public Rates Rate { get; set; } = Rates.None;
    }
}