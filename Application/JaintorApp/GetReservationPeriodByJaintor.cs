using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JaintorApp
{
    public class GetReservationPeriodByJaintor
    {
        public class Query : IRequest<List<ReservationPeriod>>
        {
            public Guid JaintorId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<ReservationPeriod>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ReservationPeriod>> Handle(Query request, CancellationToken cancellationToken)
            {
                var reservationPeriods = await _context.ReservationPeriods.Where(rp => rp.JaintorId == request.JaintorId)
                                                                          .ToListAsync();

                return reservationPeriods;
            }
        }
    }
}
