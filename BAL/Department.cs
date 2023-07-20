using System.Reflection;
using DAL;
namespace BAL
{
    public class Department
    {
        private DAL.Department department;
        public Department()
        {
            department = new DAL.Department();
        }

        public void ReadDepartments()
        {
            Console.WriteLine("Departments:");
            IEnumerable<Models.Department> departments =  department.get();
            if (departments.Count()== 0)
            {
                Console.WriteLine("No departments found.");
            }
            else
            {
                foreach (Models.Department department in departments)
                {
                    Console.WriteLine($"Department Id = {department.Id} , Department Name={department.Name}");
                }
            }
        }

        public void CreateDepartment()
        {
            Console.WriteLine("Enter department name:");

            string name = Console.ReadLine();

            department.create(name);

            Console.WriteLine("Department created successfully.");
        }


        public void UpdateDepartment()
        {
            Console.WriteLine("Enter the index of the department to update:");
            int id = int.Parse(Console.ReadLine());
            DAL.DBF.Models.Department? row = department.get(id);
            if (row != null)
            {
                Console.WriteLine("Enter the new name for the department:");
                string newName = Console.ReadLine();
                department.update(row,newName);
                Console.WriteLine("Department updated successfully.");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }
        }

        public void DeleteDepartment()
        {
            Console.WriteLine("Enter the index of the department to delete:");
            int id = int.Parse(Console.ReadLine());
            DAL.DBF.Models.Department? row = department.get(id);
            
            if (row != null)
            {
                department.delete(row);
                Console.WriteLine("Department deleted successfully.");
            }
            else
            {
                Console.WriteLine("Record Not Found");
            }

        }
    }
}