using Microsoft.AspNetCore.Mvc;
using Manager.Models;
using Accessor.Services;

namespace Manager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly ILogger<PhoneBookController> _logger;
        private readonly PhoneBookServices _phoneBookServices;

        public PhoneBookController(
            ILogger<PhoneBookController> logger,
            PhoneBookServices phoneBookServices)
        {
            _logger = logger;
            _phoneBookServices = phoneBookServices;
        }

        [HttpGet("/contacts")]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            try
            {

                var result = await _phoneBookServices.GetAllContacts();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpGet("/contact/{phone}")]
        public async Task<ActionResult<List<Contact>>> GetContactByPhone(string phone)
        {
            try
            {

                var result = await _phoneBookServices.GetContactByPhone(phone);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpDelete("/contact/{phone}")]
        public async Task<ActionResult<List<Contact>>> DeleteContactByPhone(string phone)
        {
            try
            {

                var result = await _phoneBookServices.DeleteContactByPhone(phone);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpPost("/newcontact")]
        public async Task<ActionResult<ContactDTO>> CreateContact(ContactDTO contact)
        {
            try
            {

                var result = await _phoneBookServices.AddContact(contact);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
