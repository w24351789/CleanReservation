using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.BookApp
{
    public class GetAvailableJaintorByTime
    {
        public class Query : IRequest<List<Jaintor>>
        {
            public DateTime BookingDate { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Jaintor>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Jaintor>> Handle(Query request, CancellationToken cancellationToken)
            {
                //加入該時段有空的人員交集該時段沒有預約的人員 
                var bookingDayOfWeek = request.BookingDate.DayOfWeek;
                var jaintors = _context.ReservationPeriods.Where(rp => rp.DayOfWeek == bookingDayOfWeek)
                                                          .Where(rp => TimeInDay(rp.StartTime) <= TimeInDay(request.StartTime) && TimeInDay(rp.EndTime) <= TimeInDay(request.EndTime))
                                                          .Select(rp => rp.Jaintor)
                                                          .Intersect(
                                                             _context.Bookings.Where(b => b.BookingDate == request.BookingDate)
                                                                              .Where(b => TimeInDay(request.StartTime) > TimeInDay(b.EndTime) || TimeInDay(request.EndTime) < TimeInDay(b.StartTime))
                                                                              .Select(b => b.Jaintor)
                                                           )
                                                          .ToList();
                 
                if (jaintors == null)
                    throw new Exception($"{request.BookingDate} Booked up ");

                return await Task.FromResult(jaintors);
                
            }

            public int TimeInDay(DateTime time)
            {
                return time.Hour * 60 + time.Minute; 
            }
        }
    }
}
