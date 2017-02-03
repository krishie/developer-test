using System.Linq;
using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System.Data.Entity;
using System;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class PropertiesViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        private static string _currentUser;
        public PropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public PropertiesViewModel Build(PropertiesQuery query)
        {
            var properties = _context.Properties
                .Where(p => p.IsListedForSale)
                .Include(x => x.Offers);

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                properties = properties.Where(x => x.StreetName.Contains(query.Search)
                    || x.Description.Contains(query.Search));
            }

            _currentUser = query.LoggedInUserId;

            return new PropertiesViewModel
            {
                Properties = properties
                    .ToList()
                    .Select(MapViewModel)
                    .ToList(),
                Search = query.Search
            };
        }

        private static PropertyViewModel MapViewModel(Models.Property property)
        {
            var userOffer = (property.Offers == null ? null : property.Offers.Where(o => o.OfferedByUserId == _currentUser).FirstOrDefault());
            return new PropertyViewModel
            {
                Id = property.Id,
                StreetName = property.StreetName,
                Description = property.Description,
                NumberOfBedrooms = property.NumberOfBedrooms,
                PropertyType = property.PropertyType,
                IsOfferedByLoggedInUser = (userOffer != null),
                OfferAmount = (userOffer == null ? 0 : userOffer.Amount),
                IsOfferAcceptedForLoggedInUser = (userOffer != null && userOffer.Status == OfferStatus.Accepted),
                AcceptedDateTime = (userOffer == null ? default(DateTime) : userOffer.UpdatedAt)
            };
        }
    }
}