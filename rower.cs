//dziediczenie po sprzet
class Rower : Sprzet
{
    public Rower()
    {
        TypRoweru = "Zwykły";
    }

    public override decimal CenaZaDzien => 20; //polimorfizm
}
