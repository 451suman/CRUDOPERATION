﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUDOPERATION.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }

        [Required]
        [DisplayName("kasdjl;kasd")]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order must be greater than 0")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
