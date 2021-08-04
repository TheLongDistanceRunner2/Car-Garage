using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class RepairsModels
    {
        public int ID { get; set; }

        public int CarId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Repair price")]
        public double RepairPrice { get; set; }

        public virtual CarModels Car { get; set; }


    }
}