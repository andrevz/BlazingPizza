using BlazingPizza.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialsController(PizzaStoreContext db) : ControllerBase
{
    private readonly PizzaStoreContext _db = db;

    public async Task<ActionResult<IEnumerable<PizzaSpecial>>> GetSpecials()
    {
        return (await _db.Specials.ToListAsync()).OrderByDescending(s => s.BasePrice).ToList();
    }
}
