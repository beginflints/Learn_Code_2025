namespace WebApp_Shared.Model;

public class Vehicle
{
    public Guid Id { get; set; }
    public string? Brand { get; set; }
    public DateTime ReleasedDate { get; set; }
    public string? Engine { get; set; }
    public string? Model { get; set; }
    
    public string? Color { get; set; }
    
    
}