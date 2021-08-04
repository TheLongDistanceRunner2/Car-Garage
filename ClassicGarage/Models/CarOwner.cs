using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassicGarage.Models
{
    public class CarOwner
    {
        public List<OwnerModels> ownerList { get; set; }
        public List<CarModels> carList { get; set; }
    }
}