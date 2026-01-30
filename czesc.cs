class Czesc
{
    public string Nazwa { get; set; } = "";
    public decimal Cena { get; set; }

    public override string ToString()
    {
        return $"{Nazwa} – {Cena} zł";
    }
}
