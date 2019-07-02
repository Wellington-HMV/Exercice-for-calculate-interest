using System;
using System.Globalization;
using Entities;
using Service;

namespace Secao_14___ExeProp_Class_196_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Enter number of contract: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("date (dd/MM/yyyy : ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue);
            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(contract, installments);
            Console.WriteLine("Instalments: ");
            foreach(Installment x in contract.Installments)
            {
                Console.WriteLine(x);
            }
        }
    }
}
