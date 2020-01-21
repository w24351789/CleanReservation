using Application.TimeHelpers;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var bookingTimePeriod = new TimePeriod { StartTime = request.StartTime, EndTime = request.EndTime };

                var JaintorReservationPeriods = await _context.ReservationPeriods.Where(rp => rp.DayOfWeek == bookingDayOfWeek)
                                                                                 .Select(rp => new JaintorTimePeriod { 
                                                                                       StartTime = rp.StartTime,
                                                                                       EndTime = rp.EndTime,
                                                                                       Jaintor = rp.Jaintor
                                                                                  })
                                                                                 .ToListAsync();

                var jaintors = await _context.Jaintors.ToListAsync();

                
                foreach (var jrp in JaintorReservationPeriods)
                {
                    var conflict = TimeHelper.JaintorTimeConflict(bookingTimePeriod, jrp);
                    if (conflict > 0)
                        jaintors.Remove(jrp.Jaintor);

                }


                //理想情況想做到可以排除該天無法的Jaintor再來排除衝突的booking，目前的作法是將其有空地加入，再移除被預約走的

                var JaintorBookingPeriods = await _context.Bookings.Where(b => b.BookingDate == request.BookingDate)
                                                                   .Select(b => new JaintorTimePeriod{
                                                                        StartTime = b.StartTime,
                                                                        EndTime = b.EndTime,
                                                                        Jaintor = b.Jaintor
                                                                    })
                                                                   .ToListAsync();
                
                foreach (var jbp in JaintorBookingPeriods)
                {
                    var conflict = TimeHelper.JaintorTimeConflict(bookingTimePeriod, jbp);
                    if (conflict > 0)
                        jaintors.Remove(jbp.Jaintor);
                    
                }

                return jaintors;

            }

            
        }
    }
}
