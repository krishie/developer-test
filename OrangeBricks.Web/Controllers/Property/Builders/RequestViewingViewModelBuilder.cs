using OrangeBricks.Web.Controllers.Property.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Globalization;

namespace OrangeBricks.Web.Controllers.Property.Builders
{
    public class RequestViewingViewModelBuilder
    {
        private readonly IOrangeBricksContext _context;

        public RequestViewingViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public RequestViewingViewModel Build(int id)
        {
            var property = _context.Properties.Find(id);

            return new RequestViewingViewModel
            {
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                ViewingDate = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                ViewingTime = DateTime.Now.ToString("HH:mm")
            };
        }
    }
}