using Manager.Models;
using MongoDB.Driver;

namespace Accessor.Services
{
    public class PhoneBookServices
    {
        private readonly MongoDbContext _mongoClient;

        public PhoneBookServices(MongoDbContext mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public async Task<List<Contact>?> GetContact()
        {
            try
            {
                var result = await _mongoClient.PhoneBook.Find(contact => true).ToListAsync();

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactDTO> CreateContact(ContactDTO contact)
        {
            try
            {

                await _mongoClient.PhoneBookPost.InsertOneAsync(contact);

                return contact;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}