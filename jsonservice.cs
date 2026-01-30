using System.Collections.Generic;
using System.IO;
using System.Text.Json;

static class JsonService
{
    public static void Zapisz(string plik, List<Sprzet> dane)
    {
        File.WriteAllText(plik,
            JsonSerializer.Serialize(dane, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
    }

    public static List<Sprzet> Wczytaj(string plik)
    {
        if (!File.Exists(plik))
            return new();

        var json = File.ReadAllText(plik);
        var lista = JsonSerializer.Deserialize<List<Sprzet>>(json) ?? new();

        //  ODTWARZANIE TYPÓW
        List<Sprzet> wynik = new();

        foreach (var s in lista)
        {
            Sprzet rower = s.TypRoweru == "Górski"
                ? new RowerGorski()
                : new Rower();

            rower.Id = s.Id;
            rower.Kolor = s.Kolor;
            rower.Wypozyczony = s.Wypozyczony;
            rower.Czesci = s.Czesci;

            wynik.Add(rower);
        }

        return wynik;
    }
}
