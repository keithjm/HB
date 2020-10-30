using System;
using System.Collections.Generic;

namespace HotelBookings
{
    class Program
    {
        static void Main(string[] args)
        {
            IBookingManager bm = new BookingManager(new List<int>() { 1, 2, 3, 4, 5, 6, 7 });

            var today = new DateTime(2012, 3, 28);
            Console.WriteLine(bm.IsRoomAvailable(1, today)); // outputs true

            bm.AddBooking("Patel", 2, today);
            Console.WriteLine(bm.IsRoomAvailable(2, today)); // outputs false

            // Should throw Exception because room does not exist
            try
            {
                bm.AddBooking("Jamie", 10, today);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Should throw Exception because room is not available
            try
            {
                bm.AddBooking("Jeff", 2, today);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            bm.AddBooking("Alex", 3, today);

            // Print out all available rooms 
            foreach(int room in bm.GetAvailableRooms(today))
            {
                Console.WriteLine(room);
            }
        }
    }
}
