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
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly BankDbContext _context;

        private IEnumerable<Loan> Loans = new List<Loan>();

        public LoanController(ILogger<LoanController> logger, BankDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        [HttpGet(Name = nameof(GetLoans))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Loan>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetLoans()
        {
            List<Loan> Loans = await _context.GetLoanssAsync();
            var response = new ApiResponse<IEnumerable<Loan>>(Loans);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoanById(int id)
        {
            var loan = await _context.GetLoanByIdAsync(id);
            var response = new ApiResponse<Loan>(loan);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostLoan(Loan loan)
        {
            await _context.AddLoanAsync(loan);
            var response = new ApiResponse<Loan>(loan);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutLoan(Loan loan)
        {
            bool result = await _context.LoanUpdateAsync(loan);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoanById(int id)
        {
            bool result = await _context.LoanDeleteAsync(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}