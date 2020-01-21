using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BookApp
{
    public class CreateBooking
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public DateTime BookingDate { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
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
                //串接此api前需要先用getavailablejaintorBytime來確定人員時間是可預約的
                var booking = new Booking
                {
                    Id = request.Id,
                    BookingDate = request.BookingDate,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    JaintorId = request.JaintorId
                };

                _context.Bookings.Add(booking);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;
                throw new Exception("Problem saving change");
            }
        }
    }
}
