using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo
{
    public class ReservationRepo : IReservationRepo
    {
        LibraryContext _context; 
        public ReservationRepo(LibraryContext libraryContext) 
        {
            _context = libraryContext;
        }
        public Reservation AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
            return reservation;
        }

        public List<Reservation> GetReservationsForBooks(int bookID)
        {
            return _context.Books.Find(bookID).Reservations;
        }

        public List<Reservation> GetReservationsForUsers(int userID)
        {
            return _context.Reservations.Where(r => r.User.Id == userID).ToList();
        }
    }
}
