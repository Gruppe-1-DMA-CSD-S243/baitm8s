using BaitM8s.APIClient.Clients;
using BaitM8s.APIClient.Interfaces;
using BaitM8s.DAL.DAO;
using BaitM8s.DAL.DTO;
using BaitM8s.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BaitM8s.Test;

public class ViewAvailableTimeSlots
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public async Task OnlyAvailableTimeSlotsAreRetrieved()
    {
        //Arrange
        IAPIClient<TimeSlotDTO> apiClient = new TimeSlotAPIClient<TimeSlotDTO>("https://localhost:8888/api");
        int expectedCount = 5;

        //Act
        IEnumerable<TimeSlotDTO> timeSlots = await apiClient.GetAllAsync();

        //Assert
        Assert.That(expectedCount, Is.EqualTo(timeSlots.Count()));
    }
}
