namespace WebApp_Fon.Model;

public class Vehicle
{
    public Guid Id { get; set; }
    public string? Brand { get; set; }
    public DateTime ReleaseDate { get; set; }
    
    public string? Engine { get; set; }
    
    public string? Model { get; set; }
    
}