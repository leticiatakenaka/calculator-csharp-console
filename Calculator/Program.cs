using System;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;

           
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            Console.WriteLine("Calculadora C# Console\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                Console.Write("Digite um número e pressione enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Não é um valor válido. Por favor digite um valor válido: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Digite outro número e pressione Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Não é um valor válido. Por favor digite um valor válido: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Escolha um tipo de operação:");
                Console.WriteLine("\ta - Adicionar");
                Console.WriteLine("\ts - Subtrair");
                Console.WriteLine("\tm - Multiplicar");
                Console.WriteLine("\td - Dividir");
                Console.Write("Sua opção:");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Essa operação vai resultar num erro matemático.\n");
                    }
                    else Console.WriteLine("Seu resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh não! Um erro ocorreu, veja detalhes: .\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Pressione 'n' e Enter para fechar o aplicativo, ou pressione outra letra e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}