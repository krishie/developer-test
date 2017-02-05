﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class RequestViewingViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        [Required]
        [Display(Name = "Viewing Date")]
        public string ViewingDate { get; set; }
        [Required]
        [Display(Name = "Viewing Time")]
        public string ViewingTime { get; set; }
        public int PropertyId { get; set; }
    }
}