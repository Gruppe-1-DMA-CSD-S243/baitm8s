using BaitM8s.DAL.DAO;
using BaitM8s.DAL.Model;

namespace MainTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            // Opret et FishingSpot-objekt
            var spot = new FishingSpot
            {
                Name = "Lille Sø",
                Address = "Søvej 12",
                ZipCode = "9000", // matcher en Zipcode i din DB
                Longitude = 9.9217f,
                Latitude = 57.0488f,
                Capacity = 50,
                HandicapFriendly = true,
                FishSpecies = new List<string> { "Ørred", "Karpe", "Aborre" }
            };

            // Brug DAO til at indsætte
            var dao = new FishingSpotDAO("Data Source=localhost;Database=BaitM8sTest;Persist Security Info=True;User ID=sa;Password=@12tf56so;Encrypt=True;Trust Server Certificate=True");
            int newId = await dao.CreateFishingSpotAsync(spot, 4);

            Console.WriteLine($"FishingSpot blev indsat med Id = {newId}");
            FishingSpot spot1 = await dao.GetFishingSpotAsync(7);
            Console.WriteLine($"FishingSpot hentet: Navn = {spot1.Name}, Adresse = {spot1.Address}");
            //IEnumerable<FishingSpot> allSpots = await dao.GetAllFishingSpotsAsync();
            //foreach (var spot3 in allSpots)
            //{
            //    Console.WriteLine($"Id: {spot3.Id}");
            //    Console.WriteLine($"Name: {spot3.Name}");
            //    Console.WriteLine($"Address: {spot3.Address}");
            //    Console.WriteLine($"ZipCode: {spot3.ZipCode}");
            //    Console.WriteLine($"Longitude: {spot3.Longitude}, Latitude: {spot3.Latitude}");
            //    Console.WriteLine($"Capacity: {spot3.Capacity}");
            //    Console.WriteLine($"HandicapFriendly: {spot3.HandicapFriendly}");
            //    Console.WriteLine("Fish species: " + string.Join(", ", spot3.FishSpecies));
            //    Console.WriteLine(new string('-', 40));
            //}
            int spotId = 7; // sørg for at der findes et spot med dette Id i databasen

            // Opret et nyt FishingSpot-objekt med opdaterede værdier
            var updatedSpot = new FishingSpot
            {
                Id = spotId,
                Name = "Opdateret Sø",
                Address = "Nyvej 123",
                ZipCode = "9000", // skal matche en Zipcode i databasen
                Longitude = 9.91f,
                Latitude = 57.05f,
                Capacity = 100,
                HandicapFriendly = false,
                FishSpecies = new List<string> { "Sandart", "Gedder", "Ål" }
            };

            // Kald Update-metoden
            int resultId = await dao.UpdateFishingSpotAsync(spotId, updatedSpot);

            Console.WriteLine($"FishingSpot med Id {resultId} blev opdateret.");

            // Hent spot igen for at verificere
            var spotAfterUpdate = await dao.GetFishingSpotAsync(resultId);
            Console.WriteLine("Efter opdatering:");
            Console.WriteLine($"Name: {spotAfterUpdate.Name}");
            Console.WriteLine($"Address: {spotAfterUpdate.Address}");
            Console.WriteLine($"ZipCode: {spotAfterUpdate.ZipCode}");
            Console.WriteLine($"Capacity: {spotAfterUpdate.Capacity}");
            Console.WriteLine($"HandicapFriendly: {spotAfterUpdate.HandicapFriendly}");
            Console.WriteLine("Fish species: " + string.Join(", ", spotAfterUpdate.FishSpecies));


        }
    }
}
