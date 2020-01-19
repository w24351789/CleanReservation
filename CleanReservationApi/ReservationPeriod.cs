using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class ReservationPeriod
    {
        public Guid Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid JaintorId { get; set; }

        [ForeignKey("JaintorId")]
        public virtual Jaintor Jaintor { get; set; }
    }
}
