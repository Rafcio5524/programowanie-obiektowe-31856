using System;

class Program
{
    static void Main()
    {
        Wypozyczalnia w = new();
        string plik = "rowery.json";

        foreach (var r in JsonService.Wczytaj(plik))
            w.Dodaj(r);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Dodaj rower");
            Console.WriteLine("2. Usuń rower");
            Console.WriteLine("3. Wyświetl rowery");
            Console.WriteLine("4. Wypożycz");
            Console.WriteLine("5. Zwróć");
            Console.WriteLine("6. Dodaj część do roweru");
            Console.WriteLine("7. Zapisz i wyjdź");

            Console.Write("Wybór: ");
            int wybor = int.Parse(Console.ReadLine()!);
//warunki
            if (wybor == 1)
            {
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine()!);
                Console.Write("Kolor: ");
                string kolor = Console.ReadLine()!;
                Console.Write("Typ (1-zwykły, 2-górski): ");
                int t = int.Parse(Console.ReadLine()!);

                Sprzet r = t == 2 ? new RowerGorski() : new Rower();
                r.Id = id;
                r.Kolor = kolor;
                w.Dodaj(r);
            }
            else if (wybor == 2)
            {
                w.Usun(int.Parse(Console.ReadLine()!));
            }
            else if (wybor == 3)
            {
                w.Wyswietl();
                Console.ReadKey();
            }
            else if (wybor == 4)
            {
                w.Wypozycz();
                Console.ReadKey();
            }
            else if (wybor == 5)
            {
                w.Zwroc();
                Console.ReadKey();
            }
            else if (wybor == 6)
            {
                w.DodajCzescDoRoweru();
                Console.ReadKey();
            }
            else if (wybor == 7)
            {
                JsonService.Zapisz(plik, w.PobierzWszystkie());
                break;
            }
        }
    }
}
