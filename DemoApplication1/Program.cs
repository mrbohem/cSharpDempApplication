using DemoApplication1.Controller;
using System.Reflection;

Master.start();

// extention method

//temp table, global table,
//partisan by,
//union viopot,
//rank, dens rank,
//clustor and not clustor index,trigger,magic table,


//emp_data
//id, name, department_id, manager_id, doj, salary,





//1.delete duplicate records.


//    with empCte as (select *, ROW_NUMBER() over (partition by id,name, department_id, manager_id, doj, salary order by id) as number from emp)
//    delete from empCte where number >1





//2.nth nubmer salary
//    method-1 => select * from emp where salary = (
//                    SELECT DISTINCT Salary
//                    FROM emp
//                    ORDER BY Salary DESC
//                    OFFSET n-1 ROWS FETCH NEXT 1 ROW ONLY
//                );
//    Method-2 => with empCte as(
//                select *, dense_Rank() over (order by salary desc) as rank from emp
//                )
//                select * from empCte where rank = 3






//3.1 year complete data
//        methode-1 => select * from emp where DATEDIFF(day, doj, GETDATE()) = 365

//        method-2 => select name from emp 
//                    where datediff(year, doj, getdate())= 1
//                    and month(doj) = month(getDate())
//                    and day(doj) = day(getDate())







//4.get manager name not id if don't have id then use show Boss
//    select A.name, COALESCE(B.name, 'Boss') as manager from emp A 
//    left join emp B on A.manager_id = B.id


// entity framwork , dapper
// data first ,model first ,code first(Pratical)



//5.get record multiple depatment by multiple record id

// Scaffold-DbContext "Data Source=PS-IN-LT-17059;Initial Catalog=Demo;Integrated Security=True" Microsoft.EntityFrameWorkCore.SqlServer -outputdir Repository/Models 



// Scaffold-DbContext "Data Source=PS-IN-LT-17059;Initial Catalog=Demo;Integrated Security=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DBF/Models