using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebApp_Fon.Model;

namespace WebApp_Fon.Data;

public class DataContext : DbContext
{
    private string DbPath { get; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DataContext()
    {
        var folder = "DB";
        var path = folder;
        Console.WriteLine($"Path: {path}");
        DbPath = System.IO.Path.Join(path, "Data.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}


