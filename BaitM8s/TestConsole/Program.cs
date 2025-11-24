using BaitM8s.DAL.DAO;
using BaitM8s.DAL.Interfaces;

namespace TestConsole
{
    internal class Program
    {
        private const string _connectionString = "Data Source=localhost;Database=BaitM8s;Persist Security Info=True;User ID=sa;Password=@12tf56so;Trust Server Certificate=True";

        private static IFishingSpotDAO CreateFishingSpotDAO() => new FishingSpotDAO(_connectionString);

        static async Task Main(string[] args)
        {
            //await TestGetAll();
            await TestGetByPondOwner();
        }

        public static async Task TestGetAll()
        {
            var fishingSpotDAO = CreateFishingSpotDAO();
            var all = await fishingSpotDAO.GetAllFishingSpotsAsync();

            foreach (var item in all)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static async Task TestGetByPondOwner()
        {
            var fishingSpotDAO = CreateFishingSpotDAO();
            var allByOwner = await fishingSpotDAO.GetFishingSpotsByPondOwnerAsync(1);

            foreach (var item in allByOwner)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
