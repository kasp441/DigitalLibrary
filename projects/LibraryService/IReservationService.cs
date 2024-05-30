using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IReservationService
    {
        Task<Reservation> AddReservation(Reservation reservation);

        Task<List<Reservation>> GetReservationsForUsers(int userID);

        Task<List<Reservation>> GetReservationsForBooks(int bookID);
    }
}
