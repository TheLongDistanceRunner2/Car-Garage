using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class PartsModels
    {
        public int ID { get; set; }

        public int CarId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Catalog number")]
        public int CatalogNo { get; set; }

        [Required]
        [Display(Name = "Purchase amount")]
        public double PurchaseAmount { get; set; }

        [Display(Name = "Sales amount")]
        public double? SalesAmount { get; set; }

        [Required]
        [Display(Name = "Purchase date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Sales date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SalesDate { get; set; }


        public virtual CarModels Car { get; set; }

    }
}