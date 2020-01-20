using Application.TimeHelpers;
using MediatR;
using Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReservationPeriodApp
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid ReservationPeriodId { get; set; }
            
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
                var reservationperiod = await _context.ReservationPeriods.FindAsync(request.ReservationPeriodId);
                
                var bookingExisted = _context.Bookings.Where(b => b.JaintorId == reservationperiod.JaintorId).Count();
                if (bookingExisted > 0)
                    throw new Exception("ReservationPeriod still have booking");

                _context.ReservationPeriods.Remove(reservationperiod);

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problen saving change");
            }

        }
    }
}
