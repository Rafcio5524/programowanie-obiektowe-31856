//dziedziczenie po sprzet
class RowerGorski : Sprzet
{
    public RowerGorski()
    {
        TypRoweru = "Górski";
    }

    public override decimal CenaZaDzien => 30; //polimorfizm
}
