using DemoApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication1.Controller
{
    internal class EmployeeController:Master
    {
        static List<Employee> employees = new List<Employee>();
        public static void EmployeeCRUD()
        {
            bool backToStep1 = false;

            while (!backToStep1)
            {

                Console.WriteLine("1. Read");
                Console.WriteLine("2. Create");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("0. Back to Step 1");
                Console.WriteLine("Enter your choice (0-4):");
                int choice = int.Parse(Console.ReadLine());
                BAL.Employee employee = new BAL.Employee();

                switch (choice)
                {
                    case 0:
                        backToStep1 = true;
                        start();
                        break;
                    case 1:
                        employee.ReadEmployees();
                        break;
                    case 2:
                        employee.CreateEmployee();
                        break;
                    case 3:
                        employee.UpdateEmployee();
                        break;
                    case 4:
                        employee.DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
