using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class CarModels
    {
        public int ID { get; set; }

        [Required]
        public string Make { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int VIN { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Purchase date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [Display(Name = "Purchase amount")]
        public double PurchaseAmount { get; set; }


        public int OwnerID { get; set; }

        public virtual OwnerModels Owner { get; set; }

        public virtual ICollection<RepairsModels> Repair { get; set; }

        public virtual ICollection<PartsModels> Part { get; set; }




    }
}