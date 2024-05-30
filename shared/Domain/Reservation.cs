using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Reservation
    {
        public int Id { get; set; }
        public User User { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
