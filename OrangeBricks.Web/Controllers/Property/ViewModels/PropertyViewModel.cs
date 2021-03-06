using System;

namespace OrangeBricks.Web.Controllers.Property.ViewModels
{
    public class PropertyViewModel
    {
        public string StreetName { get; set; }
        public string Description { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string PropertyType { get; set; }
        public int Id { get; set; }
        public bool IsListedForSale { get; set; }
        public bool IsOfferedByLoggedInUser { get; set; }
        public int OfferAmount { get; set; }
        public bool IsOfferAcceptedForLoggedInUser { get; set; }
        public DateTime AcceptedDateTime { get; set; }
        public bool IsViewingByLoggedInUser { get; set; }
        public DateTime ViewingDate { get; set; }
    }
}