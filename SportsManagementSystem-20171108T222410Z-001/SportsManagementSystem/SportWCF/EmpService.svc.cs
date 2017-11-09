using SportWCF.CRUD_ANGULAR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EmpService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EmpService.svc or EmpService.svc.cs at the Solution Explorer and start debugging.
    public class EmpService : IEmpService
    {
        public string deleteID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<Employee> toDelete = (from dl in db.Employees where dl.EmpNo.Equals(_id) select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.Employees.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }

        public List<employee> getAllEmployee()
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                List<employee> data = new List<employee>();
                var query = (from emp in db.Employees
                             select new employee
                             {
                                 EmpNo = Convert.ToInt32(emp.EmpNo),
                                 EmpName = emp.EmpName,
                                 Salary = Convert.ToInt32(emp.Salary),
                                 DeptName = emp.DeptName,
                                 Designation = emp.Designation,
                             }).ToList();
                foreach(employee emp in query)
                {
                    data.Add(emp);
                }
                return data;
            };
        }

        public employee getEmployeeByID(string strID)
        {
            int _id = Convert.ToInt32(strID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                var query = (from emp in db.Employees
                             where emp.EmpNo.Equals(_id)
                             select new employee
                             {
                                 EmpNo = Convert.ToInt32(emp.EmpNo),
                                 EmpName = emp.EmpName,
                                 Salary = Convert.ToInt32(emp.Salary),
                                 DeptName = emp.DeptName,
                                 Designation = emp.Designation,
                             }).First();
                return query;
            };
        }

        public string PostEmployee(employee employee)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var innerJoinQuery =
                       (from file in db.Employees
                        where file.EmpNo.Equals(Convert.ToInt32(employee.EmpNo))
                        select file);
                    if (innerJoinQuery.Count() == 0)
                    {
                        Employee res = new Employee();
                        res.EmpNo = employee.EmpNo;
                        res.EmpName = employee.EmpName;
                        res.DeptName = employee.DeptName;
                        res.Designation = employee.Designation;
                        db.Employees.InsertOnSubmit(res);
                        db.SubmitChanges();
                        return "success created";
                    }
                    else
                    {
                        Employee res = innerJoinQuery.Single();
                        res.EmpNo = employee.EmpNo;
                        res.EmpName = employee.EmpName;
                        res.DeptName = employee.DeptName;
                        res.Designation = employee.Designation;
                        // db.Employees.InsertOnSubmit(res);
                        db.SubmitChanges();
                        return "success edited";
                    }

                };
            }
            catch (Exception)
            {
                return "failed";
            }
        }

        public string PutEmployee(employee employee)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var innerJoinQuery =
                       (from file in db.Employees
                        where file.EmpNo.Equals(Convert.ToInt32(employee.EmpNo))
                        select file);
                    if(innerJoinQuery.Count() == 0)
                    {
                        Employee res = new Employee();
                        res.EmpNo = employee.EmpNo;
                        res.EmpName = employee.EmpName;
                        res.DeptName = employee.DeptName;
                        res.Designation = employee.Designation;
                        db.Employees.InsertOnSubmit(res);
                        db.SubmitChanges();
                        return "success created";
                    }else
                    {
                        Employee res = innerJoinQuery.Single();
                        res.EmpNo = employee.EmpNo;
                        res.EmpName = employee.EmpName;
                        res.DeptName = employee.DeptName;
                        res.Designation = employee.Designation;
                       // db.Employees.InsertOnSubmit(res);
                        db.SubmitChanges();
                        return "success edited";
                    }
                   
                };
            }
            catch (Exception)
            {
                return "failed";
            }
        }
    }
}
