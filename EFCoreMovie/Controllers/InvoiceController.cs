using EFCoreMovie.Entities;
using EFCoreMovie.Entities.Function;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InvoiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InvoiceController(ApplicationDbContext context)
    {
        _context = context;
    }


    [HttpPost]
    public async Task<ActionResult> Post()
    {

        using var transactin = await _context.Database.BeginTransactionAsync();

        try
        {
            var invoice = new InvoiceEntity()
            {
                CreateAt = DateTime.Now,
            };

            _context.Add(invoice);

            await _context.SaveChangesAsync();

            throw new ApplicationException("throw error for test");


            var invoiceDetail = new List<InvoiceDetailEntity>()
            {
                new InvoiceDetailEntity()
                {
                    InvoiceId = invoice.Id,
                    Product = "Product A",
                    Price = 123
                },

                new InvoiceDetailEntity()
                {
                    InvoiceId = invoice.Id,
                    Product = "Product B",
                    Price = 456
                }
            };

            _context.AddRange(invoiceDetail);
            await _context.SaveChangesAsync();

            await transactin.CommitAsync();

            return Ok("all good");

        }
        catch (Exception ex)
        {
            return BadRequest("There was an error");
        }

    }


    [HttpPost("withOutTransaction")]
    public async Task<ActionResult> PostWithOutTransaction()
    {
        var invoice = new InvoiceEntity()
        {
            CreateAt = DateTime.Now
        };

        _context.Add(invoice);

        await _context.SaveChangesAsync();

        throw new ApplicationException("throw error for test");

        var invoiceDetail = new List<InvoiceDetailEntity>()
        {
            new InvoiceDetailEntity()
            {
                InvoiceId=invoice.Id,
                Product = "Product A",
                Price = 123
            },
            new InvoiceDetailEntity()
            {
                InvoiceId=invoice.Id,
                Product = "Product B",
                Price = 456
            }
        };

        _context.AddRange(invoiceDetail);

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("scalars")]
    public async Task<ActionResult> GetScalars()
    {
        var invoies = await _context.Tbl_Invoice.Select(f => new
        {
            Id = f.Id,
            Total = Scalars.InvoiceDetailSum(f.Id),
            Average = Scalars.InvoiceDetailAverage(f.Id)
        }).OrderByDescending(f => Scalars.InvoiceDetailSum(f.Id)).ToListAsync();


        return Ok(invoies);
    }
}
