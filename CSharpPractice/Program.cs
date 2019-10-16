using System;
using CSharpPractice.Classes;
using CSharpPractice.Interfaces;

namespace CSharpPractice
{
    class Program
    {
        static void Main()
        {
            //Console.WriteLine("Hello World!");

            //Console.WriteLine(SimpleMath.Add(34,23.5));

            //using overload
            double[] numbers = new double[] { 1, 2, 3, 43, 34553 };
            var result = SimpleMath.Add(numbers);
            Console.WriteLine(result);


            BankAccount bankAccount = new BankAccount();
            bankAccount.AddToBalance(100);
            Console.WriteLine(bankAccount.Balance);

            ChildBankAccount childBankAccount = new ChildBankAccount();
            childBankAccount.AddToBalance(30);
            Console.WriteLine(childBankAccount.Balance);

            //Using the interfaces
            SimpleMath simpleMath = new SimpleMath();
            Console.WriteLine(Information(bankAccount));
            Console.WriteLine(Information(simpleMath));
        }

        private static string Information(IInformation information)
        {
            return information.GetInformation();
        }
    }

    class SimpleMath : IInformation
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        //Overloading
        public static double Add(double[] numbers)
        {
            double result = 0;
            foreach (double number in numbers)
            {
                result += number;
            }

            return result;
        }

        public string GetInformation()
        {
            return "Class that solves Simple Math.";
        }
    }
}
