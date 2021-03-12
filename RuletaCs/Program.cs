using System;

namespace RuletaCs
{
    class Program
    {
       const byte totalNumeros = 37;
       enum columnas { derecha, central,izquierda };
       static void Main(string[] args)
        {
            string numero;
            string[] numeros = GetNumeros();
            do
            {
                numero = IngresarNumero();
                switch (numero)
                {
                    case "*":
                        break;
                    case "0":
                        Console.WriteLine("Jugada anulada");
                        break;
                    case string value when esNumero(value, numeros):
                        ReportNumber(value);
                        break;
                    default:
                        Console.WriteLine("Valor incorrecto");
                        break;
                }
            } while (numero != "*");
        }

        private static string IngresarNumero()
        {
            string numero;
            Console.Write("Ingrese un número: ");
            numero = Console.ReadLine();
            return numero;
        }

        private static void ReportNumber(string value)
        {
            Console.WriteLine(value);
            var number = Convert.ToByte(value);

            InformarColor(number);

            InformarColumna(number);

            InformarMitad(number);

            InformarParImpar(number);
        }

        private static void InformarParImpar(byte number)
        {
            if (isPar(number))
                Console.WriteLine("Es Par");
            else
                Console.WriteLine("Es impar");
        }

        private static void InformarMitad(byte number)
        {
            if (isMenor(number))
                Console.WriteLine("Es menor");
            else
                Console.WriteLine("Es mayor");
        }

        private static void InformarColumna(byte number)
        {
            switch (getColumna(number))
            {
                case columnas.izquierda:
                    Console.WriteLine("Columna izquierda");
                    break;
                case columnas.central:
                    Console.WriteLine("Columna central");
                    break;
                default:
                    Console.WriteLine("Columna derecha");
                    break;
            }
        }

        private static void InformarColor(byte number)
        {
            if (isRojo(number))
                Console.WriteLine("Es rojo");
            else
                Console.WriteLine("Es negro");
        }

        static columnas getColumna(byte number)
        {
            if (number % 3 == 0)
                return columnas.derecha;
            else if (++number % 3 == 0)
                return columnas.central;
            else
                return columnas.izquierda;
        }
        private static bool isRojo(byte number)
        {
            byte[] rojos = { 1, 3, 5, 7, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 30, 32, 34, 36 };
            foreach (byte rojo in rojos)
                if (rojo == number)
                    return true;
            return false;
        }

        private static bool isMenor(byte number)
        {
            return number <= totalNumeros / 2;
        }

        private static bool isPar(byte number)
        {
            return number % 2 == 0;
        }

        private static string[] GetNumeros()
        {
            string[] numeros = new string[totalNumeros];
            for (byte x = 0; x < totalNumeros; x++)
                numeros[x] = Convert.ToString(x);
            return numeros;
        }

        static bool esNumero(string value, string[] numeros)
        {
            foreach (string numero in numeros)
                if (value == numero)
                    return true;
            return false;
        }
    }
}
