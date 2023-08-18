using ChilLaxBackEnd.Models;
using ChilLaxBackEnd.Models.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        ChilLaxEntities db = new ChilLaxEntities();

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            Employee emp = db.Employee.FirstOrDefault(e => e.emp_id == id);
            EmployeeViewModel evm = new EmployeeViewModel();
            evm.empvm = emp;
            return View(evm);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel evm)
        {
            Employee emp = db.Employee.FirstOrDefault(e => e.emp_id == evm.emp_id);

            if (emp != null)
            {
                if (evm.emp_permission.ToString() != null && evm.emp_name != null && evm.emp_account != null && evm.emp_password != null)
                {
                    emp.available = evm.available;
                    emp.emp_permission = evm.emp_permission;
                    emp.emp_name = evm.emp_name;
                    emp.emp_account = evm.emp_account;
                    emp.emp_password = evm.emp_password;
                    db.SaveChanges();
                }
            }
            else
            {
                //ModelState.AddModelError("", "無法儲存資料。請確保所有必填欄位都已填寫正確。");
                ViewBag.ErrorMessage = "請填寫所有必填欄位。";
                return RedirectToAction("Edit");
            }

            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmployeeViewModel evm)
        {
            Employee emp = new Employee();
            emp.available = evm.available;
            emp.emp_permission = evm.emp_permission;
            emp.emp_name = evm.emp_name;
            emp.emp_account = evm.emp_account;
            emp.emp_password = evm.emp_password;

            db.Employee.Add(emp);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult List()
        {
            List<EmployeeViewModel> viewModels = new List<EmployeeViewModel>();

            IEnumerable<Employee> employees = from e in db.Employee
                                              select e;

            foreach (Employee employee in employees)
            {
                EmployeeViewModel viewModel = new EmployeeViewModel
                {
                    empvm = employee
                };

                viewModels.Add(viewModel);
            }

            return View(viewModels);
        }
    }
}