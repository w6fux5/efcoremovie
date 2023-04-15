using EFCoreMovie.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentEntity>>> Get()
        {
            return await _context.Tbl_Payment.ToListAsync();
        }

        [HttpGet("card")]
        public async Task<ActionResult<IEnumerable<CardPayment>>> GetCardPayment()
        {
            return await _context.Tbl_Payment.OfType<CardPayment>().ToListAsync();
        }

        [HttpGet("paypal")]
        public async Task<ActionResult<IEnumerable<PaypalPayment>>> GetPaypalPayment()
        {
            return await _context.Tbl_Payment.OfType<PaypalPayment>().ToListAsync();
        }
    }
}
