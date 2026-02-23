using System;
using System.Threading;

class GatinhoUltra
{
    static Random random = new Random();
    static string[] simbolos = { "😺", "🐟", "🐾", "💎", "🐶" };

    static int moedas = 200;
    static int jackpot = 500;

    static void Main()
    {
        Console.Title = "🐱 GATINHO ULTRA EDITION";
        Console.CursorVisible = false;

        while (moedas > 0)
        {
            DesenharInterface();

            Console.SetCursorPosition(0, 10);
            Console.Write("Digite sua aposta: ");

            if (!int.TryParse(Console.ReadLine(), out int aposta) || aposta <= 0 || aposta > moedas)
                continue;

            moedas -= aposta;
            jackpot += (int)(aposta * 0.1);

            string[] resultado = GirarCacaNiquel();

            AvaliarResultado(resultado, aposta);

            Console.SetCursorPosition(0, 18);
            Console.Write("Pressione qualquer tecla...");
            Console.ReadKey();
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("💀 Você ficou sem moedas!");
        Console.ResetColor();
    }

    static void DesenharInterface()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("======================================");
        Console.WriteLine("        🐱 GATINHO ULTRA EDITION");
        Console.WriteLine("======================================");
        Console.ResetColor();

        Console.WriteLine($"💰 Moedas: {moedas}");
        Console.WriteLine($"💎 Jackpot: {jackpot}");
        Console.WriteLine();
        Console.WriteLine("        ┌───────────────┐");
        Console.WriteLine("        │   ?   ?   ?   │");
        Console.WriteLine("        └───────────────┘");
        Console.WriteLine();
    }

    static string[] GirarCacaNiquel()
    {
        string[] resultado = new string[3];

        for (int i = 0; i < 10; i++)
        {
            Console.SetCursorPosition(12, 7);
            Console.Write($"{simbolos[random.Next(simbolos.Length)]}   {simbolos[random.Next(simbolos.Length)]}   {simbolos[random.Next(simbolos.Length)]}");
            Thread.Sleep(100);
        }

        for (int i = 0; i < 3; i++)
            resultado[i] = simbolos[random.Next(simbolos.Length)];

        Console.SetCursorPosition(12, 7);
        Console.Write($"{resultado[0]}   {resultado[1]}   {resultado[2]}");

        return resultado;
    }

    static void AvaliarResultado(string[] r, int aposta)
    {
        Console.SetCursorPosition(0, 14);

        if (r[0] == "💎" && r[1] == "💎" && r[2] == "💎")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("🎉🎉🎉 JACKPOT!!! 🎉🎉🎉");
            Console.WriteLine($"Você ganhou {jackpot} moedas!");
            moedas += jackpot;
            jackpot = 500;
        }
        else if (r[0] == r[1] && r[1] == r[2])
        {
            int premio = aposta * 3;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🔥 TRIPLO IGUAL!");
            Console.WriteLine($"Você ganhou {premio} moedas!");
            moedas += premio;
        }
        else if (r[0] == r[1] || r[1] == r[2] || r[0] == r[2])
        {
            int premio = aposta * 2;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("✨ DOIS IGUAIS!");
            Console.WriteLine($"Você ganhou {premio} moedas!");
            moedas += premio;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ Nada dessa vez...");
        }

        Console.ResetColor();
    }
}