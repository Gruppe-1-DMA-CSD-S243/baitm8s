//using BaitM8s.DAL.Interfaces;
//using BaitM8s.DAL.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BaitM8s.DAL.DAO
//{
//    public class InMemoryAnglerDAO : BaseDAO, IAnglerDAO
//    {
//        private readonly List<Angler> _anglers;

//        public InMemoryAnglerDAO(string connectionString) : base(connectionString)
//        {
//            _anglers = new List<Angler>
//            {
//                new Angler
//                {
//                    Id = 1,
//                    AnglerNumber = 1,
//                    FirstName = "Mikkel",
//                    LastName = "Hansen",
//                    Address = "Street 1",
//                    Email = "Email@email.com",
//                    PhoneNumber = "88888888",
//                    UserName = "MikkelBuff",
//                    Password = "Password"
//                }, 
//                new Angler
//                {
//                    Id = 2,
//                    AnglerNumber = 2,
//                    FirstName = "Terkel",
//                    LastName = "Madsen",
//                    Address = "Street 2",
//                    Email = "Email@workmail.com",
//                    PhoneNumber = "12345678",
//                    UserName = "TerkelIKnibe",
//                    Password = "Password"
//                }
//            };
//        }

//        public async Task<Angler?> GetAnglerAsync(int Id)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<IEnumerable<Angler>> GetAnglersAsync()
//        {
//            return _anglers;
//        }
//    }
//}
