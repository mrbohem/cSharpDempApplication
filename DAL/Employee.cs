using DAL.DBF.Models;

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

        public DBF.Models.Employee? get(int id)
        {
            return db.Employees.FirstOrDefault(c => c.Id == id);
        }

        public void create(string name)
        {
            try
            {
                DBF.Models.Employee employee = new DBF.Models.Employee { Name = name };
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void update(DBF.Models.Employee employee, string name)
        {
            employee.Name = name;
            db.SaveChanges();
        }

        public void delete(DBF.Models.Employee employee)
        {
            db.Employees.Remove(employee);
            db.SaveChanges();
        }

    }
}