using System;
namespace HotelBookings
{
    public struct Booking
    {
        public string name;

        public int room;

        public DateTime date;

        public Booking(string name, int room, DateTime date)
        {
            this.name = name;
            this.room = room;
            this.date = date;
        }
    }   
}
