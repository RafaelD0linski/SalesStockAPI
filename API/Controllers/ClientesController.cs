using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesStock.Domain.Entities;
using SalesStock.Infrastructure.Data;
using System.Runtime.InteropServices;

namespace SalesStock.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private readonly SalesStockDbContext _context;

    public ClientesController(SalesStockDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
    {
        var clientes = await _context.Clientes.ToListAsync();
        return Ok(clientes);
    }

    [HttpPost]
    public async Task<ActionResult<Cliente>> Create(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Create), new { id = cliente.Id }, cliente);
    }
}
