namespace Learn_Code_2025.Helpers;

public class Car
{
    public Car()
    {
        
    }
    public Car(string brand, string color)
    {
        Brand = brand;
        Color = color;
    }
    
    public string Brand { get; set; }
    public string Color { get; set; }
}