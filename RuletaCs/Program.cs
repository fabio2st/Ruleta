using System;

namespace RuletaCs
{
    class Program
    {
       const byte totalNumbers = 36;
       enum Columns { derecha, central,izquierda };
       static void Main(string[] args)
       {
            string value;
            string[] boardNumbers = GetBoard();
            ushort[] numbers = new ushort[36];
            do
            {
                value = InputValue();
                switch (value)
                {
                    case "*":
                        FinalReport(numbers);
                        break;
                    case "0":
                        Console.WriteLine("Jugada anulada");
                        break;
                    case string v when IsNumber(v, boardNumbers):
                        byte number = Convert.ToByte(v);
                        ReportNumber(number);
                        CountNumber(number, numbers);
                        break;
                    default:
                        Console.WriteLine("Valor incorrecto");
                        break;
                }
            } while (value != "*");
        }
        private static void FinalReport(ushort[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                    Console.WriteLine($"{i+1} -> {numbers[i]}");
            }
        }
        private static void CountNumber(byte number, ushort[] numeros)
        {
            numeros[number-1]++;
        }
        private static string InputValue()
        {
            string value;
            Console.Write("Ingrese un número o * para salir: ");
            value = Console.ReadLine();
            return value;
        }
        private static void ReportNumber(byte number)
        {
            Console.WriteLine(number);
            ReportColor(number);
            ReportColumn(number);
            ReportHalf(number);
            ReportEvenOrOdd(number);
        }
        private static void ReportEvenOrOdd(byte number)
        {
            if (number % 2 == 0)
                Console.WriteLine("Es Par");
            else
                Console.WriteLine("Es impar");
        }
        private static void ReportHalf(byte number)
        {
            if (number <= totalNumbers / 2)
                Console.WriteLine("Es menor");
            else
                Console.WriteLine("Es mayor");
        }
        private static void ReportColumn(byte number)
        {
            Columns column = getColumn(number);
            Console.WriteLine($"Columna {column}");
        }
        private static void ReportColor(byte number)
        {
            if (IsRed(number))
                Console.WriteLine("Es rojo");
            else
                Console.WriteLine("Es negro");
        }
        static Columns getColumn(byte number)
        {
            if (number % 3 == 0)
                return Columns.derecha;
            else if ((number+1) % 3 == 0)
                return Columns.central;
            else
                return Columns.izquierda;
        }
        private static bool IsRed(byte number)
        {
            byte[] reds = { 1, 3, 5, 7, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 30, 32, 34, 36 };
            foreach (byte red in reds)
                if (red == number)
                    return true;
            return false;
        }
        private static string[] GetBoard()
        {
            string[] numbers = new string[totalNumbers];
            for (byte x = 0; x < totalNumbers; x++)
                numbers[x] = Convert.ToString(x+1);
            return numbers;
        }
        static bool IsNumber(string value, string[] numbers)
        {
            foreach (string number in numbers)
                if (value == number)
                    return true;
            return false;
        }
    }
}