using Microsoft.AspNetCore.Mvc;
using Manager.Models;
using Accessor.Services;

namespace Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookServices _phoneBookServices;

        public PhoneBookController(
            PhoneBookServices phoneBookServices)
        {
            _phoneBookServices = phoneBookServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetContacts()
        {
            try
            {

                var result = await _phoneBookServices.GetContact();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ContactDTO>> CreateContact(ContactDTO contact)
        {
            try
            {

                var result = await _phoneBookServices.CreateContact(contact);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
