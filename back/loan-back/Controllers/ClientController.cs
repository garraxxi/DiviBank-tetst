using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using loan_back.Models;
using Microsoft.Extensions.Logging;
using System.Net;

namespace loan_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;
        private readonly BankDbContext _context;

        public ClientController(ILogger<ClientController> logger, BankDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        
        [HttpGet(Name = nameof(GetCustomers))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Client>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCustomers()
        {
            List<Client> Customers = await _context.GetClientsAsync();
            var response = new ApiResponse<IEnumerable<Client>>(Customers);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _context.GetClientByIdAsync(id);
            var response = new ApiResponse<Client>(customer);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(Client customer)
        {
            _logger.LogInformation("Add Customer for CustomerId: {Id}", customer.Id);
            await _context.AddCustomerAsync(customer);
            var response = new ApiResponse<Client>(customer);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutCustomer(Client customer)
        {
            bool result = await _context.ClientUpdateAsync(customer);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerById(int id)
        {
            bool result = await _context.ClientDeleteAsync(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
} 