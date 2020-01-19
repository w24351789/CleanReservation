using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public static class DbSeedingClass
    {
        public static void SeedDataContext(this DataContext context)
        {
            var jaintors = new List<Jaintor>()
            {
                new Jaintor {
                        Id = Guid.NewGuid(),
                        FirstName = "Ted",
                        LastName = "Tai",
                        BookingList = new List<Booking>()
                        {
                            new Booking
                            {
                                Id = Guid.NewGuid(),
                                BookingDate = new DateTime(2020, 1, 27),
                                StartTime = new DateTime(2020, 1, 27, 13, 15, 00),
                                EndTime = new DateTime(2020, 1, 27, 15, 15, 00),

                            },
                            new Booking
                            {
                                Id = Guid.NewGuid(),
                                BookingDate = new DateTime(2020, 1, 31),
                                StartTime = new DateTime(2020, 1, 31, 11, 00, 00),
                                EndTime = new DateTime(2020, 1, 31, 15, 00, 00),

                            }
                        },
                        ReservationPeriodList = new List<ReservationPeriod>()
                        {
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Monday,
                                //僅用的到09:00其它值隨意，.hour與.minute
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Tuesday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Wednesday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Thursday,
                                StartTime = new DateTime(2020, 1, 1, 10, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Friday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 17, 00, 00)

                            }
                        }

                    },
                    new Jaintor
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Jason",
                        LastName = "Liu",
                        BookingList = new List<Booking>()
                        {
                            new Booking
                            {
                                Id = Guid.NewGuid(),
                                BookingDate = new DateTime(2020, 2, 18),
                                StartTime = new DateTime(2020, 2, 18, 13, 15, 00),
                                EndTime = new DateTime(2020, 2, 18, 15, 15, 00)
                            },
                            new Booking
                            {
                                Id = Guid.NewGuid(),
                                BookingDate = new DateTime(2020, 2, 21),
                                StartTime = new DateTime(2020, 2, 21, 11, 00, 00),
                                EndTime = new DateTime(2020, 2, 21, 15, 00, 00)
                            }
                        },
                        ReservationPeriodList = new List<ReservationPeriod>()
                        {
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Monday,
                                //僅用的到09:00其它值隨意，.hour與.minute
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Tuesday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Wednesday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Thursday,
                                StartTime = new DateTime(2020, 1, 1, 10, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Friday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 17, 00, 00)

                            }
                        }
                    },
                    new Jaintor
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Ruby",
                        LastName = "Wu",
                        BookingList = new List<Booking>()
                        {
                            new Booking
                            {
                                Id = Guid.NewGuid(),
                                BookingDate = new DateTime(2020, 2, 3),
                                StartTime = new DateTime(2020, 2, 3, 13, 15, 00),
                                EndTime = new DateTime(2020, 2, 3, 15, 15, 00)
                            },
                            new Booking
                            {
                                Id = Guid.NewGuid(),
                                BookingDate = new DateTime(2020, 2, 4),
                                StartTime = new DateTime(2020, 2, 4, 11, 00, 00),
                                EndTime = new DateTime(2020, 2, 4, 15, 00, 00)
                            }
                        },
                        ReservationPeriodList = new List<ReservationPeriod>()
                        {
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Monday,
                                //僅用的到09:00其它值隨意，.hour與.minute
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Tuesday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Wednesday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Thursday,
                                StartTime = new DateTime(2020, 1, 1, 10, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 18, 00, 00)

                            },
                            new ReservationPeriod
                            {
                                Id = Guid.NewGuid(),
                                DayOfWeek = DayOfWeek.Friday,
                                StartTime = new DateTime(2020, 1, 1, 9, 00, 00),
                                EndTime = new DateTime(2020, 1, 1, 17, 00, 00)

                            }
                        }
                    }
            };
          

            context.Jaintors.AddRange(jaintors);
            context.SaveChanges();
        }
    }
}
