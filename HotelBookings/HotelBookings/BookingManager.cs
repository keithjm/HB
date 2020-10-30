using System;
using System.Collections.Generic;

namespace HotelBookings
{
    public class BookingManager: IBookingManager
    {
        private List<Booking> bookings;
        private List<int> roomList;
        private object bookingsLock = new object();

        public BookingManager(List<int> roomList)
        {
            this.roomList = roomList;
            bookings = new List<Booking>();
        }

        public void AddBooking(string guest, int room, DateTime date)
        {
            if(IsRoomAvailable(room, date))
            {
                Booking newBooking = new Booking(guest, room, date);
                lock(bookingsLock)
                {
                    bookings.Add(newBooking);
                }
            }
            else
            {
                throw new Exception("Room is not available");
            }
        }

        public bool IsRoomAvailable(int room, DateTime date)
        {
            lock(bookingsLock)
            {
                return roomList.Contains(room) && bookings.FindIndex((booking) => booking.room == room && booking.date == date) == -1;
            }
        }

        public IEnumerable<int> GetAvailableRooms(DateTime date)
        {
            List<int> availableRooms = new List<int>(roomList);

            lock(bookingsLock)
            {
                var bookingsOnDate = bookings.FindAll((booking) => booking.date == date);

                foreach (Booking booking in bookingsOnDate)
                {
                    availableRooms.Remove(booking.room);
                }

                return availableRooms;
            }
        }
    }
}