using Application.TimeHelpers;
using Domain;
using MediatR;
using Persistence;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ReservationPeriodApp
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public int DayOfWeek { get; set; }
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

                var jaintorExisted = await _context.Jaintors.FindAsync(request.JaintorId);
                if (jaintorExisted == null)
                    throw new Exception("Jaintor not existed");
                //用數字讀取星期幾再轉回星期
                DayOfWeek dayOfWeek = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), request.DayOfWeek);
                //找到此人此日有安排時段了

                var requestTimePeriod = new TimePeriod{StartTime = request.StartTime, EndTime = request.EndTime};

                var TimePeriods = _context.ReservationPeriods.Where(rp => rp.JaintorId == request.JaintorId && rp.DayOfWeek == dayOfWeek)
                                                             .Select(rp => new TimePeriod{StartTime = rp.StartTime, EndTime = rp.EndTime })
                                                             .ToList() ;

                int conflictTimes = 0;
                foreach (var t in TimePeriods)
                {
                    //找到此人此日此時有安排時段了
                    conflictTimes = TimeHelper.TimeConflict(requestTimePeriod, t);
                }
                
                                   
                //找到的安排不為空值時，代表沒空
                if (conflictTimes > 0)
                    throw new Exception("This time is repeated");


                var reservationPeriod = new ReservationPeriod
                {
                    Id = request.Id,
                    DayOfWeek = dayOfWeek,
                    StartTime = request.StartTime,
                    EndTime = request.EndTime,
                    JaintorId = request.JaintorId
                };

                _context.ReservationPeriods.Add(reservationPeriod);

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problen saving change");
            }

        }
    }
}
