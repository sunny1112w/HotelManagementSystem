using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Repository
{
    public class BookingDetailRepository
    {
        private readonly FuminiHotelManagementContext _context;

        public BookingDetailRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public IEnumerable<BookingDetail> GetBookingDetailByRoomID(int RoomID)
        {
            return _context.BookingDetails.Where(b => b.RoomId == RoomID).ToList();
        }

        public IEnumerable<BookingDetail> GetBookingDetailByBookingReservationID(int BookingReservationID)
        {
            return _context.BookingDetails.Where(b => b.BookingReservationId == BookingReservationID).ToList();
        }

        public IEnumerable<BookingDetail> GetAlls()
        {
            return _context.BookingDetails.ToList();
        }
    }
}
