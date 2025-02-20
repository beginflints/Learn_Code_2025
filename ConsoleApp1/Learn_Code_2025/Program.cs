// See https://aka.ms/new-console-template for more information

using Learn_Code_2025.Helpers;

Console.WriteLine("Hello, World!");

string txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
Console.WriteLine(txt.Length);
txt.ToUpper();

var txt2 = txt.ToUpperSpecial();

var intStr1 = "10.1";
Console.WriteLine(intStr1.GetType());
decimal.TryParse(intStr1, out decimal int2);

Console.WriteLine($"int2: {int2}");
Console.WriteLine("int2: {0}",int2);

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

List<string> Str5 = ["ABC","DEF","GHI"];
Str5.ForEach(str => Console.WriteLine(str));

