using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaitM8s.DAL.DAO
{
    public class InMemoryBookingDAO : BaseDAO, IBookingDAO
    {
        private readonly IEnumerable<Booking> _bookings = new List<Booking>();

        public InMemoryBookingDAO(string connectionString) : base(connectionString)
        {
            _bookings = new List<Booking>
            {
                new Booking
                {
                    BookingNumber = "BKG-2025-001",
                    Pond = "Søndersø",
                    Date = new DateTime(2025, 5, 12),
                    NumberOfPeople = 2,
                    TimeSlots = new List<TimeSlot>
                    {
                        new TimeSlot
                        {
                            Id = 1,
                            TimeSlotNumber = "TS-1",
                            Date = new DateTime(2025, 5, 12),
                            StartTime = DateTime.Parse("2025-05-12 06:00"),
                            EndTime = DateTime.Parse("2025-05-12 10:00"),
                            IsAvailable = false,
                            Capacity = 10,
                            FK_PutAndTakePondId = 1
                        }
                    }
                },
                new Booking
                {
                    BookingNumber = "BKG-2025-002",
                    Pond = "Lillesø",
                    Date = new DateTime(2025, 5, 13),
                    NumberOfPeople = 4,
                    TimeSlots = new List<TimeSlot>
                    {
                        new TimeSlot
                        {
                            Id = 2,
                            TimeSlotNumber = "TS-2",
                            Date = new DateTime(2025, 5, 13),
                            StartTime = DateTime.Parse("2025-05-13 12:00"),
                            EndTime = DateTime.Parse("2025-05-13 16:00"),
                            IsAvailable = false,
                            Capacity = 10,
                            FK_PutAndTakePondId = 1
                        }
                    }
                },
                new Booking
                {
                    BookingNumber = "BKG-2025-003",
                    Pond = "Storedam",
                    Date = new DateTime(2025, 5, 14),
                    NumberOfPeople = 3,
                    TimeSlots = new List<TimeSlot>
                    {
                        new TimeSlot
                        {
                            Id = 3,
                            TimeSlotNumber = "TS-3",
                            Date = new DateTime(2025, 5, 14),
                            StartTime = DateTime.Parse("2025-05-14 17:00"),
                            EndTime = DateTime.Parse("2025-05-14 21:00"),
                            IsAvailable = false,
                            Capacity = 10,
                            FK_PutAndTakePondId = 1
                        }
                    }
                },
                new Booking
                {
                    BookingNumber = "BKG-2025-004",
                    Pond = "Mosehullet",
                    Date = new DateTime(2025, 5, 15),
                    NumberOfPeople = 5,
                    TimeSlots = new List<TimeSlot>
                    {
                        new TimeSlot
                        {
                            Id = 4,
                            TimeSlotNumber = "TS-4",
                            Date = new DateTime(2025, 5, 15),
                            StartTime = DateTime.Parse("2025-05-15 08:00"),
                            EndTime = DateTime.Parse("2025-05-15 18:00"),
                            IsAvailable = false,
                            Capacity = 10,
                            FK_PutAndTakePondId = 1
                        }
                    }
                },
                new Booking
                {
                    BookingNumber = "BKG-2025-005",
                    Pond = "Ørredparken",
                    Date = new DateTime(2025, 5, 16),
                    NumberOfPeople = 1,
                    TimeSlots = new List<TimeSlot>
                    {
                        new TimeSlot
                        {
                            Id = 5,
                            TimeSlotNumber = "TS-5",
                            Date = new DateTime(2025, 5, 16),
                            StartTime = DateTime.Parse("2025-05-16 07:00"),
                            EndTime = DateTime.Parse("2025-05-16 11:00"),
                            IsAvailable = false,
                            Capacity = 10,
                            FK_PutAndTakePondId = 2
                        }
                    }
                }
            };
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return _bookings;
        }

        public async Task<Booking?> GetBookingAsync(int id)
        {
            Booking foundBooking = _bookings.Where(booking =>
            booking.Id == id).Single();

            return foundBooking;
        }
    }
}
