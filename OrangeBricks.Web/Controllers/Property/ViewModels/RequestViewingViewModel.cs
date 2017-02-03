using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class RequestViewingViewModel
    {
        public string PropertyType { get; set; }
        public string StreetName { get; set; }
        public string ViewingDate { get; set; }
        public string ViewingTime { get; set; }
        public int PropertyId { get; set; }
    }
}