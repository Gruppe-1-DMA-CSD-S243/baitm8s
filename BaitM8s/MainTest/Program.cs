using BaitM8s.DAL.DAO;
using BaitM8s.DAL.Model;

namespace MainTest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Database=BaitM8sTest;Persist Security Info=True;User ID=sa;Password=@12tf56so;Encrypt=True;Trust Server Certificate=True";

            var dao = new PutAndTakePondDao(connectionString);

            Console.WriteLine("=== TEST AF PutAndTakePondDao ===");

            //// 1. Create
            //var newPond = new PutAndTakePond
            //{
            //    Name = "Test Sø",
            //    Coordinates = "55.123, 10.456",
            //    FishSpecies = "Ørred",
            //    SpotType = "Put and Take",
            //    FishingLicenseRequired = true,
            //    Address = "Testvej 1",
            //    ZipCode = "1234",
            //    Email = "kontakt@test.dk",
            //    PhoneNumber = "12345678",
            //    SizeInSquareMeters = 5000,
            //    Toilet = true,
            //    CleanTable = true,
            //    HandicapFriendly = false,
            //    FamilyFriendly = true,
            //    LinkToWebsite = "http://test.dk"
            //};

            //Console.WriteLine("Opretter test-sø...");
            //int createdId = await dao.CreatePutAndTakePondAsync(newPond);
            //Console.WriteLine($"Oprettet med ID: {createdId}");

            //// 2. Get by ID
            //Console.WriteLine("\nHenter sø via ID...");
            //var pondFromDb = await dao.GetPutAndTakePondByIdAsync(createdId);
            //Console.WriteLine($"Navn: {pondFromDb?.Name}");

            //// 3. Update
            //Console.WriteLine("\nOpdaterer sø...");
            //pondFromDb.Name = "Opdateret Test Sø";
            //pondFromDb.Toilet = false;

            //await dao.UpdatePutAndTakePondAsync(pondFromDb);
            //Console.WriteLine("Sø opdateret!");

            //// 4. Get all
            //Console.WriteLine("\nHenter alle Put & Take søer...");
            //var allPonds = await dao.GetAllPutAndTakePondsAsync();
            //foreach (var p in allPonds)
            //{
            //    Console.WriteLine($"{p.FishingSpotNumber}: {p.Name}");
            //}

            //// 5. Delete
            //Console.WriteLine("\nSletter test-sø...");
            //await dao.DeletePutAndTakePondAsync(createdId);
            //Console.WriteLine("Sø slettet!");

            // Opret DAO/Repository objekt

            // Opret et nyt PutAndTakePond objekt
            var newPond = new PutAndTakePond
            {
                Name = "2Test Sø",
                Coordinates = "55.123, 10.456",
                FishSpecies = "2Ørred",
                SpotType = "2Put and Take",
                FishingLicenseRequired = true,
                Address = "2Testvej 1",
                ZipCode = "21234",
                Email = "2kontakt@test.dk",
                PhoneNumber = "12345679",
                SizeInSquareMeters = 2000,
                Toilet = true,
                CleanTable = true,
                HandicapFriendly = false,
                FamilyFriendly = true,
                LinkToWebsite = "http://2test.dk"
            };

            try
            {
                Console.WriteLine("Opretter test-sø...");

                int createdId = await dao.CreatePutAndTakePondAsync(newPond);

                Console.WriteLine($"Oprettet med ID: {createdId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Noget gik galt:");
                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine(ex.InnerException.Message);
            }

            Console.WriteLine("=== TEST AFSLUTTET ===");
        }
    }
}
