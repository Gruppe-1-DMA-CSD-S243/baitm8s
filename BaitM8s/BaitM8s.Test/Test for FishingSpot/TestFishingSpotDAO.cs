using BaitM8s.DAL.DAO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;

namespace BaitM8s.Test;

public class TestFishingSpotDAO
{
    private readonly string _testConnectionString =
    "Data Source=localhost;Database=BaitM8s;User ID=sa;Password=@12tf56so;Trust Server Certificate=True;";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestGetAllFishingSpotsAsync()
    {
        //Arrange
        IFishingSpotDAO DAO = new FishingSpotDAO(_testConnectionString);

        //Act
        IEnumerable<FishingSpot> fishingSpots = await DAO.GetAllFishingSpotsAsync();

        //Assert
        Assert.NotNull(fishingSpots);
        Assert.That(fishingSpots.Count() > 0);
    }

    [Test]
    public async Task TestGetFishingSpotAsync()
    {
        //Arrange 
        IFishingSpotDAO DAO = new FishingSpotDAO(_testConnectionString);
        IEnumerable<FishingSpot> allFishingSpots = await DAO.GetAllFishingSpotsAsync();
        int id = allFishingSpots.Min(booking => booking.Id);

        //Act
        FishingSpot foundFishingSpot = await DAO.GetFishingSpotAsync(id);

        //Assert
        Assert.NotNull(foundFishingSpot);
        Assert.That(foundFishingSpot.Id == id);
    }

    [Test]
    public async Task TestGetFishingSpotsByPondOwnerAsync()
    {
        //Arrange
        IFishingSpotDAO DAO = new FishingSpotDAO(_testConnectionString);
        IEnumerable<FishingSpot> allFishingSpots = await DAO.GetAllFishingSpotsAsync();
        int pondOwnerId = allFishingSpots.Min(fishingSpot => fishingSpot.Id);

        //Act
        IEnumerable<FishingSpot> foundFishingSpots = await DAO.GetFishingSpotsByPondOwnerAsync(pondOwnerId);

        //Assert
        Assert.NotNull(foundFishingSpots);
        Assert.That(foundFishingSpots.Count() > 0);
    }

    [Test]
    public async Task TestCreateFishingSpotAsync()
    {
        //Arrange 
        IFishingSpotDAO DAO = new FishingSpotDAO(_testConnectionString);
        IEnumerable<FishingSpot> allFishingSpots = await DAO.GetAllFishingSpotsAsync();
        int highestId = allFishingSpots.Max(fishingSpot => fishingSpot.Id);

        //Act 
        FishingSpot newFishingSpot = new FishingSpot
        {
            Name = "TestSpot",
            Address = "TestAddress",
            ZipCode = "9000",
            Longitude = 57.05f,
            Latitude = 9.92f,
            Capacity = 10,
            FishSpecies = new List<string>(),
            HandicapFriendly = true,
            IsAwaitingApproval = false,
            StartAvailableHours = 8,
            EndAvailableHours = 13,
            FK_PondOwnerId = 1 //TODO: Kig lige på dette id!
        };

        int newId = await DAO.CreateFishingSpotAsync(newFishingSpot);

        //Assert
        Assert.That(newId >  highestId);
    }

    [Test]
    public async Task TestDeleteFishingSpotAsync()
    {
        //Arrange
        IFishingSpotDAO DAO = new FishingSpotDAO(_testConnectionString);
        IEnumerable<FishingSpot> allFishingSpots = await DAO.GetAllFishingSpotsAsync();
        int idToDelete = allFishingSpots.Max(fishingSpot => fishingSpot.Id);

        //Act
        bool isDeleted = await DAO.DeleteFishingSpotAsync(idToDelete);

        //Assert
        Assert.True(isDeleted);
    }

    [Test]
    public async Task TestUpdateFishingSpot()
    {
        //Arrange 
        IFishingSpotDAO DAO = new FishingSpotDAO(_testConnectionString);
        IEnumerable<FishingSpot> allFishingSpots = await DAO.GetAllFishingSpotsAsync();
        FishingSpot fishingSpotToUpdate = allFishingSpots.OrderByDescending(fishingSpot => fishingSpot.Id).First();

        //Act
        fishingSpotToUpdate.Name = "UpdatedName";
        fishingSpotToUpdate.Address = "UpdatedAddress";

        bool isUpdated = await DAO.UpdateFishingSpotAsync(fishingSpotToUpdate);

        //Assert
        Assert.True(isUpdated); //TODO: Man skulle måske teste på noget mere.
    }

    [Test]
    public async Task TestManageFishingSpot()
    {
        //Arrange
        IFishingSpotDAO DAO = new FishingSpotDAO(_testConnectionString);
        IEnumerable<FishingSpot> allFishingSpots = await DAO.GetAllFishingSpotsAsync();
        FishingSpot fishingSpotToManage = allFishingSpots.OrderByDescending(FishingSpot => FishingSpot.Id).First();

        //Act
        fishingSpotToManage.Name = "ManagedName";
        fishingSpotToManage.Address = "ManagedAddress";

        bool isManaged = await DAO.ManageFishingSpotAsync(fishingSpotToManage);

        //Assert
        Assert.True(isManaged);
    }
}
