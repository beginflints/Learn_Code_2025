using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Ray.Data;
using WebApp_Ray.Model;
using WebApp_Ray.ModelDto;

namespace WebApp_Ray.Controllers;

[ApiController]
[Route(template:"api/[controller]/[action]")]
public class VehicleController : ControllerBase
{
    private readonly DataContext _context;

    public VehicleController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
         public async Task<IActionResult> GetAll()
         {
             try
             {
                 var models = await _context.Vehicles.ToListAsync();
                 
                 // List<Vehicle> vehicles =
                 // [
                 //     new()
                 //     {
                 //         Id = Guid.NewGuid(),
                 //         Brand = "BM",
                 //         ReleasedDate = DateTime.Today
                 //     },
                 //     new()
                 //     {
                 //         Id = Guid.NewGuid(),
                 //         Brand = "Toyota",
                 //         ReleasedDate = DateTime.Today
                 //     }
                 // ];
                 return Ok(models);
             }
             catch (Exception e)
             {
                 Console.WriteLine(e);
                 return BadRequest(e.Message);
             }
     
         }
    [HttpPost]
    public async Task<IActionResult> Create(VehicleDto vehicle)
    {
        try
        {
            Vehicle newVehicle = new()
            {
                Brand = vehicle.Brand,
                ReleasedDate = vehicle.ReleasedDate,
            };
           await _context.AddAsync(newVehicle);
           await _context.SaveChangesAsync();
               return Ok(vehicle);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }

    }
    [HttpPost]
    public async Task<IActionResult> CreateWithValidate(VehicleDto vehicle)
    {
        try
        {
            var isExList =  await _context.Vehicles.AnyAsync(a=>a.Brand == vehicle.Brand);
            if (isExList) return BadRequest("Brand already exists");
            Vehicle newVehicle = new()
            {
                Brand = vehicle.Brand,
                ReleasedDate = vehicle.ReleasedDate,
            };
         
            await _context.AddAsync(newVehicle);
            await _context.SaveChangesAsync();
            return Ok(vehicle);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }

    }

    [HttpDelete(template :"name")]
    public async Task<IActionResult> Delete(string name)
    {
        try
        {
            var model = await _context.Vehicles.FirstOrDefaultAsync(a=>a.Brand == name);
            if(model == null) return NotFound();
            //Bluk Delete
            await _context.Vehicles.Where(a.=>a.Brand==name).ExecuteDeleteAsynce();
            //_context.Vehicles.Remove(model);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}