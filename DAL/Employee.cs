using Models;
using DAL.CDF;

namespace DAL
{
    public class Employee
    {
        public DemoContext db;
        public Employee()
        {
            db = new DemoContext();
        }
        public IEnumerable<Models.Employee> get()
        {
            var data = db.Employees.Select(x => new Models.Employee
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return data;
        }

        public Models.Employee? get(int id)
        {
            return db.Employees.Select(x => new Models.Employee
            {
                Id = x.Id,
                Name = x.Name,
                departmentId = x.departmentId,
                designation = x.designation,
            }).FirstOrDefault(c => c.Id == id);
        }

        public void create(string name,int departmentId,string designation)
        {
            try
            {
                Models.Employee employee = new Models.Employee { Name = name,departmentId=departmentId,designation=designation };
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void update(Models.Employee employee, string name)
        {
            employee.Name = name;
            db.SaveChanges();
        }

        public void delete(Models.Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }
    }
}