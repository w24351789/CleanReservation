using Domain;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReservationPeriodApp
{
    public class Details
    {
        public class Query : IRequest<ReservationPeriod>
        {
            public Guid ReservationPeriodId { get; set; }
        }

        public class Handler : IRequestHandler<Query, ReservationPeriod>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<ReservationPeriod> Handle(Query request, CancellationToken cancellationToken)
            {
                var reservationperiod = await _context.ReservationPeriods.FindAsync(request.ReservationPeriodId);

                if (reservationperiod == null)
                    throw new Exception("ReservationPeriod not found");

                return reservationperiod;
            }
        }
    }
}
