using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    public class Employee
    {
        private DAL.Employee employee;
        public Employee()
        {
            employee = new DAL.Employee();
        }

        public void ReadEmployees()
        {
            Console.WriteLine("Employees:");
            IEnumerable<Models.Employee> employees = employee.get();
            if (employees.Count() == 0)
            {
                Console.WriteLine("No Employee found.");
            }
            else
            {
                foreach (Models.Employee employee in employees)
                {
                    Console.WriteLine($"Employee Id = {employee.Id} , Employee Name={employee.Name}");
                }
            }
        }

        public void CreateEmployee()
        {
            Console.WriteLine("Enter Employee name:");

            string name = Console.ReadLine();

            employee.create(name);

            Console.WriteLine("Employee created successfully.");
        }


        public void UpdateEmployee()
        {
            Console.WriteLine("Enter the index of the employee to update:");
            int id = int.Parse(Console.ReadLine());
            DAL.DBF.Models.Employee? row = employee.get(id);
            if (row != null)
            {
                Console.WriteLine("Enter the new name for the Employee:");
                string newName = Console.ReadLine();
                employee.update(row, newName);
                Console.WriteLine("Employee updated successfully.");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
        }

        public void DeleteEmployee()
        {
            Console.WriteLine("Enter the index of the Employee to delete:");
            int id = int.Parse(Console.ReadLine());
            DAL.DBF.Models.Employee? row = employee.get(id);

            if (row != null)
            {
                employee.delete(row);
                Console.WriteLine("Employee deleted successfully.");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }

        }
    }
}
