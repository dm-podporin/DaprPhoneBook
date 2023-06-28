using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using DaprPhoneBook.Models;

namespace DaprPhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IMongoClient _mongoClient;

        public PhoneBookController(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetContacts()
        {
            var database = _mongoClient.GetDatabase("PhoneBook"); 
            var collection = database.GetCollection<Contact>("PhoneBook"); 

            var contacts = collection.Find(contact => true).ToList();

            return Ok(contacts);
        }

        [HttpPost]
        public ActionResult<Contact> CreateContact([FromBody] Contact contact)
        {
            try
            {
                var database = _mongoClient.GetDatabase("PhoneBook");
                var collection = database.GetCollection<Contact>("PhoneBook");

                collection.InsertOne(contact);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
