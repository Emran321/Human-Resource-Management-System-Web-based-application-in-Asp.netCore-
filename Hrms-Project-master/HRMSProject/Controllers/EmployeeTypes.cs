using HRMSProject.Models;
using HRMSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Controllers
{
    public class EmployeeTypes : Controller
    {
        private readonly EmployeeTypeRepository _repository;

        public EmployeeTypes(EmployeeTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllEmployeeType());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VmEmployeeType model)
        {
            if (ModelState.IsValid)
            {
                int id = await _repository.AddEmployeeType(model);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _repository.GetAllEmployeeTypeID(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VmEmployeeType model)
        {
            await _repository.EditEmployeeType(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _repository.Details(id));
        }
    }

}
