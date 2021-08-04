using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class AdvertismentModels
    {
        public int ID { get; set; }

        public int CarId { get; set; }

        public bool Active { get; set; }

        public virtual CarModels Car { get; set; }

        [Required]
        [Display(Name = "Sales date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SalesDate { get; set; }

        [Required]
        [Display(Name = "Sales amount")]
        public double SalesAmount { get; set; }

    }
}