using Manager.Models;
using MongoDB.Bson;
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

        public async Task<List<Contact>?> GetAllContacts()
        {
            try
            {
                var result = await _mongoClient.PhoneBook.Find(new BsonDocument()).ToListAsync();

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Contact>?> GetContactByPhone(string phone)
        {
            try
            {
                var result = await _mongoClient.PhoneBook.Find(row => row.Phone == phone).ToListAsync();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ContactDTO> AddContact(ContactDTO contact)
        {
            try
            {

                await _mongoClient.PhoneBook.InsertOneAsync(FromDto(contact));

                return contact;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<long> DeleteContactByPhone(string phone)
        {
            try
            {
                var result = await _mongoClient.PhoneBook.DeleteManyAsync(row => row.Phone == phone);

                return result.DeletedCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Contact FromDto(ContactDTO contact)
        {
            return new Contact()
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Phone = contact.Phone
            };
        }

        private ContactDTO ToDto(Contact contact)
        {
            return new ContactDTO()
            {
                Name = contact.Name,
                Surname = contact.Surname,
                Phone = contact.Phone
            };
        }
    }
}