using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDb1.Data;
using WebApp_Shared.Model;
using WebApp_Shared.ModelDto;

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
    public async Task<IActionResult> CreateV2(object obj)
    {
        try
        {
            var vehicle = JsonSerializer.Deserialize<VehicleDto>(obj.ToString()) ?? new VehicleDto();

            var newVehicle = new Vehicle()
            {
                Brand = vehicle.Brand,
                ReleasedDate = vehicle.ReleasedDate,
                Engine = vehicle.Engine,
                Model = vehicle.Model
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
    public async Task<IActionResult> Creates(List<VehicleDto> vehicles)
    {
        try
        {
            // #1 LINQ-expression 
            var newVehicles = vehicles.Select(a => new Vehicle() 
                    { Brand = a.Brand, ReleasedDate = a.ReleasedDate })
                .ToList();
            
            // var newVehiclesA = vehicles.Select(a => new Vehicle() 
            //         { Brand = a.Brand, ReleasedDate = a.ReleasedDate })
            //     .ToArray();
            //
            // var newVehiclesH = vehicles.Select(a => new Vehicle() 
            //         { Brand = a.Brand, ReleasedDate = a.ReleasedDate })
            //     .ToHashSet();

            await _context.AddRangeAsync(newVehicles);
            await _context.SaveChangesAsync();
            
            // #2 foreach
            var newVehicles2 = new List<Vehicle>();
            foreach (var v in vehicles)
            {
                var newVehicle = new Vehicle()
                {
                    Brand = v.Brand,
                    ReleasedDate = v.ReleasedDate,
                };
                
                newVehicles2.Add(newVehicle);
            }
            
            await _context.AddRangeAsync(newVehicles2);
            await _context.SaveChangesAsync();
            
            return Ok(newVehicles);
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

    [HttpPut("{brand}")]
    public async Task<IActionResult> Update(string brand, VehicleDto vehicle)
    {
        // ดึงค่ามาจาก Database
        // Update ค่า
        // Save
        // Return
        
        // ดึงค่ามาจาก Database
        var modelUpdate = await _context.Vehicles.FirstOrDefaultAsync(a => a.Brand == brand);
        if (modelUpdate is null) return NotFound($"Brand {brand} does not exist");
        
        // Update
        modelUpdate.Brand = vehicle.Brand;
        modelUpdate.ReleasedDate = vehicle.ReleasedDate;
        
        // Save
        await _context.SaveChangesAsync();

        // Return
        return NoContent();
    }


    [HttpDelete("{name}")]
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