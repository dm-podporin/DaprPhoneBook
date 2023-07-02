using Dapr.Client;
using Manager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manager.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class AccessorController : ControllerBase
    {
        private readonly ILogger<AccessorController> _logger;
        private readonly DaprClient _daprClient;

        public AccessorController(ILogger<AccessorController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpGet("/contacts")]
        public async Task<ActionResult<List<ContactDTO>>> GetAllContacts()
        {
            try
            {
                var result = await _daprClient.InvokeMethodAsync<List<ContactDTO>>(HttpMethod.Get, "accessor", "/contacts");

                return Ok(result);
    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpGet("/contact")]
        public async Task<ActionResult<List<ContactDTO>>> GetContactByPhone(
            [FromQuery(Name = "phone")] string phone)
        {
            try
            {
                var result = await _daprClient.InvokeMethodAsync<List<ContactDTO>>(HttpMethod.Get, "accessor", $"/phonebook/{phone}");

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        [HttpDelete("/contact")]
        public async Task<ActionResult<List<ContactDTO>>> DeleteContactByPhone(
            [FromQuery(Name = "phone")] string phone)
        {
            try
            {
                var result = await _daprClient.InvokeMethodAsync<long>(HttpMethod.Delete, "accessor", $"/phonebook/{phone}");

                return Ok($"Deleted {result} phone with name: {phone}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


        [HttpPost("/phonebook")]
        public async Task<ActionResult<ContactDTO>> CreateContact(ContactDTO phoneName)
        {
            try
            {
                await _daprClient.InvokeBindingAsync("phonequeue", "create", phoneName);

                _logger.LogInformation("Sucessfully added");
                return Ok("Sucessfully added to phonequeue");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }


    }
}
