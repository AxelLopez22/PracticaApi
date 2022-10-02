using System.Security.Claims;
using ApiProductos.DTO;
using ApiProductos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProductos.Controllers;

[ApiController]
[Route("[Api/controller]")]
public class CategoriaController : ControllerBase
{
    private readonly PruebaContext _context;

    public CategoriaController(PruebaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        CategoriaDTO model = new CategoriaDTO();
        List<Categorium> result = await _context.Categoria.Where(x => x.Estado == true).ToListAsync();
        if(result == null){
            return BadRequest("La lista esta vacia perro");
        }
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetId(int id)
    {
        var result = await _context.Categoria.Where(x => x.Id == id && x.Estado == true).FirstOrDefaultAsync();
        if(result == null){
            return BadRequest("El Id no existe");
        }
        return Ok(result);
    }
}