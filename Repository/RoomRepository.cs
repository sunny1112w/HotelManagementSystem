using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoomRepository : IRoomRepository
    {

        private readonly FuminiHotelManagementContext _context;

        public RoomRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public void Add(RoomInformation room)
        {
            _context.RoomInformations.Add(room);
            _context.SaveChanges();
        }

        public void Delete(int roomId)
        {
            var room = _context.RoomInformations.FirstOrDefault(r => r.RoomId == roomId);
            if (room != null)
            {
                room.RoomStatus = 0;
                _context.RoomInformations.Update(room);
                _context.SaveChanges();
            }
        }

        public IEnumerable<RoomInformation> GetAll()
        {
            return _context.RoomInformations.ToList();
        }

        public RoomInformation GetById(int roomId)
        {
            return _context.RoomInformations.FirstOrDefault(r => r.RoomId == roomId);
        }

        public void Update(RoomInformation room)
        {
            var existingRoom = _context.RoomInformations.FirstOrDefault(r => r.RoomId == room.RoomId);
            if (existingRoom != null)
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.RoomDetailDescription = room.RoomDetailDescription;
                existingRoom.RoomMaxCapacity = room.RoomMaxCapacity;
                existingRoom.RoomStatus = room.RoomStatus;
                existingRoom.RoomPricePerDay = room.RoomPricePerDay;
                existingRoom.RoomTypeId = room.RoomTypeId;

                _context.SaveChanges();
            }
        }
    }
}
