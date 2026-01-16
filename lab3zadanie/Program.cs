using Lab2;
using Newtonsoft.Json;

var path = Path.Combine(Directory.GetCurrentDirectory(), "Cars.json");
var txt = File.ReadAllText(path);
var data = JsonConvert.DeserializeObject<List<Car>>(txt);

void AddCar()
{
    Console.WriteLine("Enter car model:");
    string model = Console.ReadLine();
    Console.WriteLine("Enter car color:");
    string color = Console.ReadLine();
    Console.WriteLine("Enter production year:");
    var success = int.TryParse(Console.ReadLine(), out int year);

    if (!success || model == null || color == null)
    {
        Console.WriteLine("Incorrect input data.");
        return;
    }
    data.Add(new Car(model, year, color));
}

void RemoveCar()
{
    if (data.Count == 0)
    {
        Console.WriteLine("\nDatabase is empty.");
        return;
    }
    Console.WriteLine("Provide index of the car to delete:");
    var success = int.TryParse(Console.ReadLine(), out int index);
    if (!success || index < 0 || index >= data.Count)
    {
        Console.WriteLine("Invalid index value.");
        return;
    }
    data.RemoveAt(index);
}

void ChangeColor()
{
    if (data.Count == 0)
    {
        Console.WriteLine("\nNo records found.");
        return;
    }
    Console.WriteLine("Select car index to change its color:");
    var success = int.TryParse(Console.ReadLine(), out int index);
    if (!success || index < 0 || index >= data.Count)
    {
        Console.WriteLine("Index out of range.");
        return;
    }
    Console.WriteLine("Type new color:");
    string color = Console.ReadLine();
    if (color == null)
    {
        Console.WriteLine("Color cannot be empty.");
        return;
    }
    data[index].Color = color;
}

void ListCars()
{
    if (data.Count == 0)
    {
        Console.WriteLine("\nNo cars stored.");
        return;
    }
    Console.WriteLine("Current cars in system:");
    for (int i = 0; i < data.Count; i++)
    {
        Console.WriteLine("ID: {0}", i);
        Console.WriteLine("Model: " + data[i].Model);
        Console.WriteLine("Color: " + data[i].Color);
        Console.WriteLine("Year: " + data[i].Year);
    }
}

do
{
    Console.WriteLine("Choose option:");
    Console.WriteLine("1. Add new car");
    Console.WriteLine("2. Delete car");
    Console.WriteLine("3. Update color");
    Console.WriteLine("4. Display all cars");
    Console.WriteLine("0. Save and exit");
    var option = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (option)
    {
        case '0':
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(path, json);
            return;
        case '1':
            AddCar();
            break;
        case '2':
            RemoveCar();
            break;
        case '3':
            ChangeColor();
            break;
        case '4':
            ListCars();
            break;
    }
} while (true);
