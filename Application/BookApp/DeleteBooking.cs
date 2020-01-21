using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BookApp
{
    public class DeleteBooking
    {
        public class Command : IRequest
        {
            public Guid BookingId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var booking = await _context.Bookings.FindAsync(request.BookingId);
                if (booking == null)
                    throw new Exception("Booking not found");

                _context.Bookings.Remove(booking);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;
                throw new Exception("Problem saving change");
            }
        }
    }
}
