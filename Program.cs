using System.Text.Json;
using Amazone.Data;
using Amazone.Domain;
using Amazone.Domain;
namespace Migration_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!!!!!!!!!");

           LoadDefaultEmployeeData();
        }

        private static void LoadDefaultEmployeeData()
        {
            // 1.Read the Data.json file:
            string contentsAsString = File.ReadAllText("Data.json");

            // 2.Change the string into a List<Employee> == Deserialize
            var employees = JsonSerializer.Deserialize<List<Employee>>(contentsAsString);

            // 3.Call context to AddRange the new employees:
            using(var context = new AmazonContext())
            {
                // Add Bulk Employees
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }
    }
}
