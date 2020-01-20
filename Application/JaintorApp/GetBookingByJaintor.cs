using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JaintorApp
{
    public class GetBookingByJaintor
    {
        public class Query : IRequest<List<Booking>>
        {
            public Guid JaintorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Booking>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Booking>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bookings = await _context.Bookings.Where(rp => rp.JaintorId == request.JaintorId)
                                                                          .ToListAsync();

                return bookings;
            }
        }
    }
}
