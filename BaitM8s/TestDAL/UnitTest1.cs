using BaitM8s.DAL.Interfaces;
using BaitM8s.DAL.SQLServer;
using System.Linq;

namespace TestDAL
{
    public class Tests
    {
        private const string _connectionString = "Data Source=localhost;Initial Catalog = baitm8s; Persist Security Info=True;User ID = sa; Password=@12tf56so;Trust Server Certificate=True";


        private IPutAndTakePondDAO CreatePutAndTakePondDAO() => new PutAndTakePondDAO(_connectionString);


        [Test]
        public void GetAll_IncludesNewlyCreatedBlogPost()
        {
            
            var putAndTakePondDAO = CreatePutAndTakePondDAO();
            try
            {

                var all = putAndTakePondDAO.GetAll();
                
                Assert.That(all.Count() > 2);
            }
            catch
            {

            }

        }
    }
}