using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesStock.Infrastructure.Data;
using SalesStock.Domain.Entities;

namespace SalesStock.API.Controllers;

[Route("[controller]")]
[ApiController]
public class VendasController : ControllerBase
{
    private readonly SalesStockDbContext _context;

    public VendasController(SalesStockDbContext context)
    {
        _context = context;
    }

    // GET: api/vendas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Venda>>> GetVendas()
    {
        return await _context.Set<Venda>().ToListAsync();
    }

    // GET: api/vendas/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Venda>> GetVenda(int id)
    {
        var venda = await _context.Set<Venda>().FindAsync(id);

        if (venda == null)
            return NotFound();

        return venda;
    }

    // POST: api/vendas
    [HttpPost]
    public async Task<ActionResult<Venda>> PostVenda(Venda venda)
    {
        _context.Set<Venda>().Add(venda);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetVenda), new { id = venda.Id }, venda);
    }

    //PUT: api/vendas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVenda(int id, Venda venda)
    {
        if (id != venda.Id)
            return BadRequest();

        _context.Entry(venda).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Set<Venda>().Any(e => e.Id == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: vendas/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenda(int id)
    {
        var venda = await _context.Set<Venda>().FindAsync(id);
        if (venda == null)
            return NotFound();

        _context.Set<Venda>().Remove(venda);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
