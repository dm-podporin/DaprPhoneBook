﻿using DaprPhoneBook.Models;
using Manager.Models;
using MongoDB.Driver;

namespace Manager.Service
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

        public async Task<Contact> CreateContact(Contact contact)
        {
            try
            {

                await _mongoClient.PhoneBook.InsertOneAsync(contact);

                return contact;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}