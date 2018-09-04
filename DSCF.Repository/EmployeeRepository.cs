using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DSCF.Model;
using DSCF.View;

namespace DSCF.Repository
{
    public class EmployeeRepository
    {
        private DSMainContext db = new DSMainContext();
        public List<EmployeeViewModel> getAllEmployee()
        {
            List<EmployeeViewModel> list = new List<EmployeeViewModel>();

            list = (from a in db.employees
                    select new EmployeeViewModel
                    {
                        id = a.EMP_ID,
                        name = a.NAME,
                        email = a.EMAIL,
                        dept_id = a.DEPT_ID,
                        active = a.ACTIVE
                    }).Where(x => x.active == true).ToList();
            return list;
        }
        public EmployeeViewModel getEmployee(string id)
        {
            EmployeeViewModel detail = new EmployeeViewModel();

            detail = (from a in db.employees where a.EMP_ID == id
                          select new EmployeeViewModel
                          {
                              id = a.EMP_ID,
                              name = a.NAME,
                              email = a.EMAIL,
                              dept_id = a.DEPT_ID,
                              active = a.ACTIVE
                          }).SingleOrDefault();
            return detail;
        }
        public List<EmployeeViewModel> SearchListEmployee(string keywords)
        {
            List<EmployeeViewModel> list = new List<EmployeeViewModel>();
            list = (from a in db.employees
                    where
                        a.NAME.Contains(keywords) || a.DEPT_ID.Contains(keywords) || 
                        a.EMAIL.Contains(keywords) || a.EMP_ID.Contains(keywords)
                    select new EmployeeViewModel
                    {
                        id = a.EMP_ID,
                        name = a.NAME,
                        email = a.EMAIL,
                        dept_id = a.DEPT_ID,
                        active = a.ACTIVE
                    }).Where(x=>x.active==true).ToList();
            return list;
        }
        //public void 
    }
}
