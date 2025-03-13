using Microsoft.AspNetCore.Mvc;
using WebApp_Fon.Data;
using WebApp_Fon.Model;

namespace WebApp_Fon.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class VehicleController : ControllerBase
{
    private readonly DataContext _context;

    public VehicleController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            List<Vehicle> vehicles =
            [
                new()
                {
                    Id = Guid.NewGuid(),
                    Brand = "BMW",
                    ReleaseDate = DateTime.Today,
                },
                new()
                {
                Id = Guid.NewGuid(),
                Brand = "Toyota",
                ReleaseDate = DateTime.Today,
                }
            ];
            return Ok(vehicles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }
    }
}