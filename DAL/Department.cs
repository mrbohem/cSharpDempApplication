//using DAL.DBF.Models;
//using DAL.CDF;
using DAL.CDF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
//using DAL.DBF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections;
//using DAL.DBF.Models;

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
            //var data = db.Departments.Select(x => new Models.Department
            //{
            //    Id = x.Id,
            //    Name = x.Name
            //}).ToList();

            IEnumerable<Models.Department> data = db.Departments.FromSqlRaw("EXEC getAllDepartments").ToList();
            return data;
        }

        public Models.Department? get(int id) {

            var idParam = new SqlParameter("@id", SqlDbType.Int){ Value = id };

            Models.Department data = db.Departments.FromSqlRaw("EXEC getDepartmentById @id", idParam).AsEnumerable().FirstOrDefault();
            return data;

            //return db.Departments.Select(x => new Models.Department
            //{
            //    Id = x.Id,
            //    Name = x.Name
            //}).FirstOrDefault(c => c.Id == id);
        }

        public Models.Department create(string name)
        { 
            var nameParam= new SqlParameter("@Name", SqlDbType.VarChar)
            {
                Value = name
            };

            //var newlyInsertedIdParam = new SqlParameter
            //{
            //    ParameterName = "@NewlyInsertedId",
            //    SqlDbType = SqlDbType.Int,
            //    Direction = ParameterDirection.Output
            //};

            //var newlyInsertedIdParam = new SqlParameter("@NewlyInsertedId", System.Data.SqlDbType.Int);
            //newlyInsertedIdParam.Direction = System.Data.ParameterDirection.Output;

            Models.Department newlyCreatedRow = db.Departments.FromSqlRaw("EXEC createDepartment @name", nameParam).AsEnumerable().FirstOrDefault();
            return newlyCreatedRow;
            //db.Database.ExecuteSqlRaw("EXEC @NewlyInsertedId = createDepartment @Name",
            //newlyInsertedIdParam, nameParam);

            //int newlyInsertedId = Convert.ToInt32(newlyInsertedIdParam.Value);

            //Console.WriteLine(newlyInsertedId);
            //Models.Department department = new Models.Department { Name = name };
            //db.Departments.Add(department);
            //db.SaveChanges();

            // var affectedRows = db.Database.ExecuteSqlInterpolated($"exec deleteDepartment @id={department.Id}");

        }
        public Models.Department update(Models.Department department,string name) {

            var nameParam = new SqlParameter("@Name", SqlDbType.VarChar)
            {
                Value = name
            };

            var id = new SqlParameter("@id", SqlDbType.BigInt)
            {
                Value = department.Id
            };

            Models.Department newlyCreatedRow = db.Departments.FromSqlRaw("EXEC updateDepartment @name,@id", nameParam, id).AsEnumerable().FirstOrDefault();
            return newlyCreatedRow;
        }

        public int delete(Models.Department department) {
            var affectedRows = db.Database.ExecuteSqlInterpolated($"exec deleteDepartment @id={department.Id}");
            return affectedRows;
        }
    }
}
