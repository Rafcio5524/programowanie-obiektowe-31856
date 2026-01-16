namespace Lab2;

public abstract class Vehicle
{
    private string model;
    private int year;
    private string color;
    
    public string Color
    {
        set => color = value;
        get => color;
    }
    public string Model{get => model;}
    public int Year{get => year;}
    public Vehicle(string model, int year, string color)
    {
        this.model = model;
        this.year = year;
        this.color = color;
    }
}