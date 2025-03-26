using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Fon.Data;
using WebApp_Fon.Model;
using WebApp_Fon.ModelDto;

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
            var models = await _context.Vehicles.ToListAsync();
            // List<Vehicle> vehicles =
            // [
            //     new()
            //     {
            //         Id = Guid.NewGuid(),
            //         Brand = "BMW",
            //         ReleaseDate = DateTime.Today,
            //     },
            //     new()
            //     {
            //         Id = Guid.NewGuid(),
            //         Brand = "Toyota",
            //         ReleaseDate = DateTime.Today,
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
            Vehicle newvehicle = new()
            {
                Id = Guid.NewGuid(),
                Brand = vehicle.Brand,
                ReleaseDate = vehicle.ReleaseDate,
                Engine = vehicle.Engine,
                Model = vehicle.Model

            };
            await _context.Vehicles.AddAsync(newvehicle);
            await _context.SaveChangesAsync();
            return Ok(newvehicle);
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
            bool isExist = await _context.Vehicles.AnyAsync(x => x.Brand == vehicle.Brand);
            if (isExist) return BadRequest("Vehicle already exist");
            Vehicle newvehicle = new()
            {
                Brand = vehicle.Brand,
                ReleaseDate = vehicle.ReleaseDate

            };
            await _context.Vehicles.AddAsync(newvehicle);
            await _context.SaveChangesAsync();
            return Ok(newvehicle);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.InnerException);
        }
    }

    [HttpDelete ("name")]
        public async Task<IActionResult> Delete(string name)
        {
            try
            {
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(a => a.Brand == name);
                if (vehicle == null) return NotFound("Vehicle not found");
                
                
                //await _context.Vehicles.Where(a=> a.Brand == name).ExecuteDeleteAsync();
                
                _context.Vehicles.Remove(vehicle);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.InnerException);
            }
        }

    [HttpPut("{brand}")]
    public async Task<IActionResult> Update(string brand, VehicleDto vehicle)
    {
        var vehicleToUpdate = await _context.Vehicles.FirstOrDefaultAsync(a => a.Brand == brand);
        if (vehicleToUpdate == null) return NotFound("Not found");
        vehicleToUpdate.Brand = vehicle.Brand;
        vehicleToUpdate.ReleaseDate = vehicle.ReleaseDate;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpPost]
    public async Task<IActionResult> Creates(List<VehicleDto> vehicles)
    {
        try
        {
            //linq
            var newvehicles = vehicles.Select(a => new Vehicle()
                { Brand = a.Brand, ReleaseDate = a.ReleaseDate }).ToList();
            
            await _context.Vehicles.AddRangeAsync(newvehicles);
            await _context.SaveChangesAsync();
            
            //for each
            var newvehicles2 = new List<Vehicle>();
            foreach (var v in newvehicles)
            {
                var newvehicle = new Vehicle()
                {
                    Brand = v.Brand,
                    ReleaseDate = v.ReleaseDate
                };
                newvehicles2.Add(newvehicle);
            }
            await _context.Vehicles.AddRangeAsync(newvehicles2);
            await _context.SaveChangesAsync();
            
            return Ok(newvehicles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.InnerException);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAll()
    {
        try
        {
            await _context.Vehicles.ExecuteDeleteAsync();
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.InnerException);
        }
        
    }
    
    }
