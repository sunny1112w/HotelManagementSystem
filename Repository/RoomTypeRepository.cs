using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Repository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly FuminiHotelManagementContext _context;

        public RoomTypeRepository(FuminiHotelManagementContext context)
        {
            _context = context;
        }

        public void Add(RoomType type)
        {
            _context.RoomTypes.Add(type);
        }

        public IEnumerable<RoomType> GetAll()
        {
            return _context.RoomTypes.ToList();
        }

        public RoomType GetById(int roomTypeId)
        {
            return _context.RoomTypes.FirstOrDefault(r => r.RoomTypeId == roomTypeId);
        }

        public void Update(RoomType type)
        {
            var existingRoom = _context.RoomTypes.FirstOrDefault(r => r.RoomTypeId == type.RoomTypeId);
            if (existingRoom != null)
            {
                existingRoom.RoomTypeName = type.RoomTypeName;
                existingRoom.TypeDescription = type.TypeDescription;
                existingRoom.TypeNote = type.TypeNote;
                _context.SaveChanges();
            }
        }
    }
}
