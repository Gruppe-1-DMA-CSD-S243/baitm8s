using BaitM8s.DAL.DAO;
using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.Model;

namespace BaitM8s.Test;

public class TestAnglerDAO
{
    private readonly string _testConnectionString =
    "Data Source=localhost;Database=BaitM8s;User ID=sa;Password=@12tf56so;Trust Server Certificate=True;";

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task TestGetAnglersAsync()
    {
        //Arrange
        IAnglerDAO DAO = new AnglerDAO(_testConnectionString);

        //Act
        IEnumerable<Angler> allAnglers = await DAO.GetAnglersAsync();

        //Assert
        Assert.NotNull(allAnglers);
        Assert.That(allAnglers.Count() > 0);
    }

    [Test]
    public async Task TestGetAnglerAsync()
    {
        //Arrange
        IAnglerDAO DAO = new AnglerDAO(_testConnectionString);
        IEnumerable<Angler> allAnglers = await DAO.GetAnglersAsync();
        int id = allAnglers.Min(angler => angler.Id);

        //Act
        Angler foundAngler = await DAO.GetAnglerAsync(id);

        //Assert
        Assert.NotNull(foundAngler);
        Assert.True(foundAngler.Id == id);
    }
}
