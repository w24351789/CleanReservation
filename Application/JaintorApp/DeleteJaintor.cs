using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JaintorApp
{
    public class DeleteJaintor
    {
        public class Command : IRequest
        {
            public Guid JaintorId { get; set; }
            
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
                var jaintor = await _context.Jaintors.FindAsync(request.JaintorId);
                if (jaintor == null)
                    throw new Exception("Jaintor not found");
                var jaintorReservationPeriod = _context.ReservationPeriods.Where(rp => rp.JaintorId == request.JaintorId).Count();
                if (jaintorReservationPeriod > 0)
                    throw new Exception($"{jaintor.FirstName} still has Reservation Period .");

                var jaintorBooking = _context.Bookings.Where(b => b.JaintorId == request.JaintorId).Count();
                if (jaintorBooking > 0)
                    throw new Exception($"{jaintor.FirstName} still has customer booking");

                _context.Jaintors.Remove(jaintor);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving change");
            }
        }
    }
}
