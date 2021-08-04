using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class OwnerModels
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        public int PhoneNo { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }


        public virtual ICollection<CarModels> Cars { get; set; }
    }
}