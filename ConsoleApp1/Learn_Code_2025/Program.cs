// See https://aka.ms/new-console-template for more information

using Learn_Code_2025.Helpers;

Console.Write("Line1");
Console.WriteLine("Line2");


string txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
Console.WriteLine(txt.Length);
txt.ToUpper();

var txt2 = txt.ToUpperSpecial();

var intStr1 = "10.1";
Console.WriteLine(intStr1.GetType());
decimal.TryParse(intStr1, out decimal int2);

Console.WriteLine($"int2: {int2}");
Console.WriteLine("int2: {0}", int2);

int int3 = (int)int2;
Console.WriteLine($"int3: {int3}");

switch (int3)
{
    case 1:
        Console.WriteLine(1);
        break;
    case 2:
        Console.WriteLine(2);

        break;
}

var str4 = int3 switch
{
    1 => int3.ToString(),
    2 => int3.ToString(),
    _ => int3.ToString()
};

List<string> Str5 = ["ABC", "DEF", "GHI"];
Str5.ForEach(str => Console.WriteLine(str));

string strInt6 = "a";
try
{
    var abc = "";
    if (strInt6 != null)
    {
    }

    var int6 = int.Parse(strInt6);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
finally
{
    var abc = "abc";
}

Console.WriteLine("Enter your age:");
// int age = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine("Your age is: " + age);

// int num = 10;
// num += 5;
string myString = "Hello \"";
string myString2 = myString[2..];

string myString3 = """
                   Hello \ " ' 
                   """;
Console.WriteLine($"myString3 : {myString3}");

myString3.Split("#;");

string comparison1 = "abc";
string comparison2 = "abC";

Console.WriteLine($"{comparison1} {comparison2}");
Console.WriteLine($"{string.Equals(comparison1,comparison2, StringComparison.OrdinalIgnoreCase)}");

List<int>? numbers = null;
//Process
//Process
if (true)
{
    numbers = new List<int>();
}
//Process
numbers ??= [ 1, 2, 3];



Car toyota = new Car();
toyota.Brand = "Toyota";
toyota.Color = "Red";

Car Volvo = new Car() { Brand = "Volvo", Color = "Blue"};
Car BYD = new Car("BYD","Gray");
BYD.Color = "Blue";

var color1 = BYD.Color;


