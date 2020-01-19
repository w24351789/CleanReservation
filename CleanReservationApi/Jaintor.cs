using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Jaintor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public virtual List<ReservationPeriod> ReservationPeriodList { get; set; }
        [NotMapped]
        public virtual List<Booking> BookingList { get; set; }
    }
}
