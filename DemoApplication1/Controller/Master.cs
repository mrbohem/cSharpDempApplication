using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication1.Controller
{
    public class Master
    {
        public static void start()
        {
            xyz:
            Console.WriteLine("Please Enter 1 for Employee and 2 for Department");
            int choice;
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    EmployeeController.EmployeeCRUD();
                    break;
                case 2:
                    DepartmentController.DepartmentCRUD();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    goto xyz;
            }
        }
    }
}
