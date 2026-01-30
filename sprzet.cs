using System.Collections.Generic;
using System.Linq;
//klasa bazowa
class Sprzet
{
    public int Id { get; set; }
    public string Kolor { get; set; } = "";
    public bool Wypozyczony { get; set; }

    // KLUCZ DO JSON
    public string TypRoweru { get; set; } = "";

    public List<Czesc> Czesci { get; set; } = new();

    public decimal CenaCzesci => Czesci.Sum(c => c.Cena);

    public virtual decimal CenaZaDzien => 0; //polimorfizm

    public decimal ObliczCene(int dni)
    {
        return dni * CenaZaDzien + CenaCzesci;
    }
}
