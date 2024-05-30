using Domain;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReservationService : IReservationService
    {
        IReservationRepo _reservationRepo;
        public ReservationService(IReservationRepo reservationRepo )
        {
            _reservationRepo = reservationRepo;
        }
        public async Task<Reservation> AddReservation(Reservation reservation)
        {
            return await Task.FromResult(_reservationRepo.AddReservation(reservation));
        }

        public Task<List<Reservation>> GetReservationsForBooks(int bookID)
        {
            return Task.FromResult(_reservationRepo.GetReservationsForBooks(bookID));
        }

        public Task<List<Reservation>> GetReservationsForUsers(int userID)
        {
            return Task.FromResult(_reservationRepo.GetReservationsForUsers(userID));
        }
    }
}
