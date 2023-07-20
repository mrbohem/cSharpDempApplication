using DemoApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApplication1.Controller
{
    internal class DepartmentController
    {
        public static List<Department> departments = new List<Department>();

        public static void DepartmentCRUD()
        {
            top:
            Console.WriteLine("please enter 1 for Read,2 for create,3 for update,4 for delete");
            Console.WriteLine("Enter your choice (1-4):");
            int choice = Convert.ToInt32(Console.ReadLine());
            BAL.Department department = new BAL.Department();
            switch (choice)
            {
                case 0:
                    Master.start();
                    break;
                case 1:
                    department.ReadDepartments();
                    break;
                case 2:
                    department.CreateDepartment();
                    break;
                case 3:
                    department.UpdateDepartment();
                    break;
                case 4:
                    department.DeleteDepartment();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
            goto top;
        }

        
    }
}
