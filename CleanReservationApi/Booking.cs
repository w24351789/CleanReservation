﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    public class Booking
    {
        public Guid Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid JaintorId { get; set; }
        [ForeignKey("JaintorId")]
        public virtual Jaintor Jaintor { get; set; }
    }
}
