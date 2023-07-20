using DAL.DBF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
using DAL.DBF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL
{
    public class Department
    {
        public DemoContext db;
        public Department()
        {
            db = new DemoContext();
        }
        public IEnumerable<Models.Department> get()
        {
            var data = db.Departments.Select(x => new Models.Department
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return data;
        }

        public DBF.Models.Department? get(int id) {
            return db.Departments.FirstOrDefault(c => c.Id == id);
        }

        public void create(string name)
        { 
            try{
                DBF.Models.Department department = new DBF.Models.Department { Name = name };
                db.Departments.Add(department);
                db.SaveChanges();
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
        public void update(DBF.Models.Department department,string name) {
            department.Name = name;
            db.SaveChanges();
        }

        public void delete(DBF.Models.Department department) {
            db.Departments.Remove(department);
            db.SaveChanges();
        }
        
    }
}
