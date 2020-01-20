using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BookApp
{
    public class GetBookings
    {
        public class Query : IRequest<List<Booking>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Booking>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context )
            {
                _context = context;
            }

            public async Task<List<Booking>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bookings = await _context.Bookings.ToListAsync();

                return bookings;
            }
        }
    }
}
