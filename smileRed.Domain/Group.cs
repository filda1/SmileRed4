﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smileRed.Domain
{
    public class Group
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "The field {0} is required.")]
        [MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters lenght.")]
        [Index("Category_Description_Index", IsUnique = true)]
        public string Description { get; set; }
        
        public string Image { get; set; }

        [Display(Name = "Is Active?")]
        public bool IsActive { get; set; }    

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}