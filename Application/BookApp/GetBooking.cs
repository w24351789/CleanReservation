using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BookApp
{
    public class GetBooking
    {
        public class Query : IRequest<Booking>
        {
            public Guid BookingId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Booking>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Booking> Handle(Query request, CancellationToken cancellationToken)
            {
                var booking = await _context.Bookings.FindAsync(request.BookingId);

                if (booking == null)
                    throw new Exception("Booking not found");

                return booking;
            }
        }
    }
}
