using System;
using System.Collections.Generic;
using System.Linq;

class Wypozyczalnia
{
    private List<Sprzet> sprzety = new(); // kolekcje generyczne

    
    private List<Czesc> magazynCzesci = new()
    {
        new Czesc { Nazwa = "Uchwyt na bidon", Cena = 25 },
        new Czesc { Nazwa = "Uchwyt na telefon", Cena = 40 },
        new Czesc { Nazwa = "Koszyk", Cena = 35 },
        new Czesc { Nazwa = "Lampki LED", Cena = 45 },
        new Czesc { Nazwa = "Licznik", Cena = 60 },
        new Czesc { Nazwa = "Bagażnik", Cena = 80 }
    };

    public void Dodaj(Sprzet s) => sprzety.Add(s);

    public void Usun(int id) => sprzety.RemoveAll(s => s.Id == id);

    public void Wyswietl()
    {
        if (!sprzety.Any())
        {
            Console.WriteLine("Brak rowerów.");
            return;
        }

        foreach (var s in sprzety)
        {
            Console.WriteLine(
                $"ID: {s.Id} | Typ: {s.TypRoweru} | Kolor: {s.Kolor} | Wypożyczony: {s.Wypozyczony}");

            if (s.Czesci.Any())
                foreach (var c in s.Czesci)
                    Console.WriteLine($"   - {c}");
        }
    }

    public void DodajCzescDoRoweru()
    {
        if (!sprzety.Any())
        {
            Console.WriteLine("Brak rowerów.");
            return;
        }

        if (!magazynCzesci.Any())
        {
            Console.WriteLine("Brak dostępnych części.");
            return;
        }

        Console.Write("Podaj ID roweru: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
            return;

        var rower = sprzety.FirstOrDefault(r => r.Id == id);
        if (rower == null)
        {
            Console.WriteLine("Nie znaleziono roweru.");
            return;
        }

        Console.WriteLine("Dostępne części:");
        for (int i = 0; i < magazynCzesci.Count; i++)
            Console.WriteLine($"{i + 1}. {magazynCzesci[i]}");

        Console.Write("Wybierz numer części: ");
        if (!int.TryParse(Console.ReadLine(), out int wybor))
            return;

        if (wybor < 1 || wybor > magazynCzesci.Count)
        {
            Console.WriteLine("Niepoprawny wybór.");
            return;
        }

        var czesc = magazynCzesci[wybor - 1];
        rower.Czesci.Add(czesc);
        magazynCzesci.RemoveAt(wybor - 1);

        Console.WriteLine($"Dodano część: {czesc.Nazwa}");
    }

    public void Wypozycz()
    {
        Console.Write("ID roweru: ");
        int id = int.Parse(Console.ReadLine()!);

        var r = sprzety.FirstOrDefault(s => s.Id == id);
        if (r == null || r.Wypozyczony)
        {
            Console.WriteLine("Nie można wypożyczyć.");
            return;
        }

        Console.WriteLine($"Rower: {r.TypRoweru}, Kolor: {r.Kolor}");
        foreach (var c in r.Czesci)
            Console.WriteLine($" - {c}");

        Console.WriteLine("1. 7 dni\n2. 14 dni\n3. 30 dni");
        int dni = Console.ReadLine() switch
        {
            "1" => 7,
            "2" => 14,
            "3" => 30,
            _ => 0
        };

        if (dni == 0) return;

        Console.WriteLine($"Cena: {r.ObliczCene(dni)} zł");
        r.Wypozyczony = true;
    }

    public void Zwroc()
    {
        Console.Write("ID roweru: ");
        int id = int.Parse(Console.ReadLine()!);

        var r = sprzety.FirstOrDefault(s => s.Id == id);
        if (r == null || !r.Wypozyczony)
        {
            Console.WriteLine("Ten rower nie jest wypożyczony.");
            return;
        }

        r.Wypozyczony = false;
        Console.WriteLine("Rower zwrócony.");
    }

    public List<Sprzet> PobierzWszystkie() => sprzety;
}
