using HRMSProject.Models;
using HRMSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Controllers
{
    public class CompanyTypes : Controller
    {
        private readonly CompanyTypeRepository _repository;

        public CompanyTypes(CompanyTypeRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllCompanyType());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VmCompanyType model)
        {
            if (ModelState.IsValid)
            {
                int id = await _repository.AddCompanyType(model);
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
            return View(await _repository.GetAllCompanyTypeID(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VmCompanyType model)
        {
            await _repository.EditCompanyType(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteCompany(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _repository.Details(id));
        }
    }
}
