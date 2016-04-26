using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SinglePage.Models
{
    public class Analyst
    {
        [Key]
        [Required(ErrorMessage = "analyst_name is required.")]
        [Display(Name = "analyst_name")]
        [MaxLength(50)]
        public string analyst_name { get; set; }

        [Required(ErrorMessage = "analyst_initials is required.")]
        [Display(Name = "analyst_initials")]
        [MaxLength(50)]
        public string analyst_initials { get; set; }
    }
}