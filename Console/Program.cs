using Data;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository();           
            
            Console.WriteLine("GET PERSON BY ID");
            Guid id = new Guid("7bdab699-7280-4a4d-a44c-17900b0003a6");

            Response response = repository.GetById(id);
            if (!response.Sucess) {
                DisplayError(response);
            } 
            Console.WriteLine(response.Person);
            Console.ReadLine();
        }

        static void DisplayError(Response response) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(response.Error);
            Console.Read();
        }
    }
}
