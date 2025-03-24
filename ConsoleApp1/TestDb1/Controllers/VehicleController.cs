using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDb1.Data;
using TestDb1.ModelDtos;
using TestDb1.Models;

namespace TestDb1.Controllers;

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
            //         Brand = "BMW",
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
            var newV = new Vehicle()
            {
                Brand = vehicle.Brand,
                ReleasedDate = vehicle.ReleasedDate,
            };

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
            return BadRequest(e.InnerException);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateWithValidate(VehicleDto vehicle)
    {
        try
        {
            bool isExist = await _context.Vehicles.AnyAsync(a => a.Brand == vehicle.Brand);
            if (isExist) return BadRequest("Brand already exist");

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
            return BadRequest(e.InnerException);
        }
    }

    [HttpDelete("name")]
    public async Task<IActionResult> Delete(string name)
    {
        try
        {
            var model = await _context.Vehicles.FirstOrDefaultAsync(a => a.Brand == name);
            if (model == null) return NotFound();

            //Bulk Delete
            // await _context.Vehicles.Where(a => a.Brand == name).ExecuteDeleteAsync();
            
            _context.Vehicles.Remove(model);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.InnerException);
        }
    }
    
}