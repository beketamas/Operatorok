using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;
using System.Text.RegularExpressions;

namespace operatorok
{
    internal class Program
    {
        //1. feladat
        static List<Kifejezesek> lista = File.ReadAllLines("kifejezesek.txt").Select(x => new Kifejezesek(x)).ToList();
        static void Main(string[] args)
        {
            //2. feladat
            Console.WriteLine($"2. feladat: Kifejezések száma: {lista.Count}");
            //3. feladat
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {lista.Count(x => x.Operatorok == "mod")}");
            //4. feladat
            Console.WriteLine(lista.Exists(x => x.ElsoOperandus % 10 == 0 && x.MasodikOperandus % 10 == 0) ? "4. feladat: Van ilyen kifejezés!" : "4. feladat: Nincs ilyen kifejezés!");
            //5. feladat
            Console.WriteLine($"5. feladat: Statisztika");
            lista.Where(x => x.Operatorok == "+" ||
            x.Operatorok == "mod" ||
            x.Operatorok == "/" ||
            x.Operatorok == "div" ||
            x.Operatorok == "-" ||
            x.Operatorok == "*")
            .GroupBy(x => x.Operatorok).ToList().ForEach(x => Console.WriteLine($"\t{x.Key} -> {x.Count()} db"));
            //7. feladat
            string? bekeres = "";

            while (bekeres != "vége")
            {
                Console.Write($"7. feladat: Kérek egy kifejezést (pl.: 1 + 1): ");
                bekeres = Console.ReadLine();
                if (!Regex.IsMatch(bekeres, @"(\d\s('+'|-|'*'|/|div|mod)\s\d)|vége"))
                {
                    Console.WriteLine($"\t{bekeres} = Az operandusok közül valamelyik nem szám vagy a formátum nem megfelelő!");
                    continue;
                }
                Console.WriteLine($"\t{KifejezesKezelo(bekeres)}");
            }
            //8. feladat
            File.WriteAllLines("eredmenyek.txt", lista.Select(x => KifejezesKezelo($"{x.ElsoOperandus} {x.Operatorok} {x.MasodikOperandus}")));
            Console.WriteLine($"8. feladat: eredmenyek.txt");
        }

        //6. feladat
        public static string KifejezesKezelo(string kifejezes) 
        {
            if (kifejezes == "vége")
            {
                return "";
            }
            string[] tomb = kifejezes.Split();
            
            if ((tomb[2] == "0") && (tomb[1] == "/"|| tomb[1] == "%"|| tomb[1] == "mod"|| tomb[1] == "div"))
            {
                return $"{kifejezes} = Egyéb hiba!";
            }
            
            string eredmeny = "";
            switch (tomb[1])
            {
                case "+":
                    eredmeny = (int.Parse(tomb[0]) + int.Parse(tomb[2])).ToString();
                    break;
                case "-":
                    eredmeny = (int.Parse(tomb[0]) - int.Parse(tomb[2])).ToString();
                    break;
                case "*":
                    eredmeny = (int.Parse(tomb[0]) * int.Parse(tomb[2])).ToString();
                    break;
                case "/":
                    eredmeny = ((int.Parse(tomb[0]) * 0.1) / (int.Parse(tomb[2]) * 0.1)).ToString();
                    break;
                case "div":
                    eredmeny = (int.Parse(tomb[0]) / int.Parse(tomb[2])).ToString();
                    break;
                case "mod":
                    eredmeny = (int.Parse(tomb[0]) % int.Parse(tomb[2])).ToString();
                    break;
            }
            return (eredmeny == "") ? $"{kifejezes} = Hibás operátor!" : $"{kifejezes} = {eredmeny}";

        }

    }
}