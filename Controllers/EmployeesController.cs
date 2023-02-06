using EMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EMS.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> list = new List<Employee>();
            try
            {
                list = Employee.GetAllEmployees();

                if (list.Count < 1)
                {
                    ViewBag.Message = "No Employees found!";
                    return View();
                }

                return View(list);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            Employee emp = null;
            try
            {
                emp = Employee.GetSingleEmployee(id);

                if (emp == null)
                {
                    ViewBag.Message = "No Employee found!";
                    return View();
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                emp.CreatedDate = DateTime.Now;
                emp.UpdatedDate = DateTime.Now;

                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Validation failed!";
                    return View();
                }

                Employee.InsertEmployee(emp);

                ViewBag.Message = "Record inserted successfully!";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee emp = null;
            try
            {
                emp = Employee.GetSingleEmployee(id);

                if (emp == null)
                {
                    ViewBag.Message = "No Employee found!";
                    return View();
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                if (id != emp.EmployeeId)
                {
                    ViewBag.Error = "Id not matching!";
                    return View();
                }

                Employee newEmp = null;
                newEmp = Employee.GetSingleEmployee(id);
                if (newEmp == null)
                {
                    ViewBag.Error = "Employee not found!";
                    return View();
                }

                emp.CreatedDate = newEmp.CreatedDate;
                emp.UpdatedDate = DateTime.Now;

                if (!ModelState.IsValid)
                {
                    ViewBag.Error = "Validation failed!";
                    return View();
                }

                Employee.UpdateEmployee(emp);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            Employee emp = null;
            try
            {
                emp = Employee.GetSingleEmployee(id);

                if (emp == null)
                {
                    ViewBag.Message = "No Employee found!";
                    return View();
                }

                return View(emp);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // POST: EmployeesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                if (id == null)
                {
                    ViewBag.Error = "Id is required!";
                    return View();
                }

                Employee.DeleteEmployee(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}
