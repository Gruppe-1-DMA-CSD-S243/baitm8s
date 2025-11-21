using BaitM8s.DAL.DAO;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;

namespace BaitM8s.Test;

public class TestBookingDAO
{
    private readonly string _testConnectionString =
    "Data Source=localhost;Database=BaitM8s;User ID=sa;Password=@12tf56so;Trust Server Certificate=True;";
    
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public async Task TestGetAllBookingsAsync()
    {
        // Arrange
        IBookingDAO DAO = new BookingDAO(_testConnectionString);

        // Act
        IEnumerable<Booking> allBookings = await DAO.GetAllBookingsAsync();

        // Assert
        Assert.NotNull(allBookings);
        Assert.True(allBookings.Count() > 0); 
    }

    [Test]
    public async Task TestGetOneBookingAsync()
    {
        // Arrange
        IBookingDAO DAO = new BookingDAO(_testConnectionString);
        IEnumerable<Booking> allBookings = await DAO.GetAllBookingsAsync();
        int id = allBookings.Min(booking => booking.Id);

        // Act
        Booking? foundBooking = await DAO.GetBookingAsync(id);

        // Assert
        Assert.NotNull(foundBooking);
        Assert.True(foundBooking.Id == id);
    }

    [Test]
    public async Task TestDeleteBookingAsync()
    {
        // Arrange
        IBookingDAO DAO = new BookingDAO(_testConnectionString);
        IEnumerable<Booking> allBookings = await DAO.GetAllBookingsAsync();
        int id = allBookings.Max(booking => booking.Id);

        // Act
        bool isDeleted = await DAO.DeleteBookingAsync(id);

        // Assert
        Assert.True(isDeleted);
    }

    //[Test]
    //public async Task TestCreateBookingAsync()
    //{
    //    Arrange
    //   IBookingDAO DAO = new BookingDAO(_testConnectionString);

    //    Act
    //    IEnumerable<Booking> allBookings = await DAO.GetAllBookingsAsync();

    //    Assert
    //    Assert.NotNull(allBookings);
    //    Assert.True(allBookings.Count() > 0);
    //}

}
