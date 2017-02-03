using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace OrangeBricks.Web.Controllers.Property.Commands
{
    public class RequestViewingCommandHandler
    {
        private readonly IOrangeBricksContext _context;

        public RequestViewingCommandHandler(IOrangeBricksContext context)
        {
            _context = context;
        }

        public void Handle(RequestViewingCommand command)
        {
            var property = _context.Properties.Find(command.PropertyId);
            DateTime viewingDateTime = default(DateTime);

            DateTime.TryParseExact(string.Format("{0} {1}", command.ViewingDate, command.ViewingTime), "dd/MM/yyyy HH:mm", 
                CultureInfo.InvariantCulture, DateTimeStyles.None, out viewingDateTime);

            var viewing = new Viewing
            {
                RequestDate = viewingDateTime,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                RequestUserId = command.RequestedUserId
            };

            if (property.Viewings == null)
            {
                property.Viewings = new List<Viewing>();
            }

            property.Viewings.Add(viewing);

            _context.SaveChanges();
        }
    }
}