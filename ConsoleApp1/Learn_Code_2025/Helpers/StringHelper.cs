namespace Learn_Code_2025.Helpers;

public static class StringHelper
{
    public static string ToUpperSpecial(this string text)
    {
        return text.ToUpper() + "Special";
    }
    
    public static void MyMethod(object fname) 
    {
        Console.WriteLine(fname + " Refsnes");
    }
    
    public static void MyMethod(string child1, string child2, string child3) 
    {
        Console.WriteLine("The youngest child is: " + child3);
    }
    
    public static void MyMethod(string child1) 
    {
        Console.WriteLine("The youngest child is: ");
    }
}