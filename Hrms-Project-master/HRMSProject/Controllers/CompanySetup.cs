using HRMSProject.Models;
using HRMSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Controllers
{
    public class CompanySetup : Controller
    {
        private readonly CompanySetupRepository _repository;
        private readonly CompanyTypeRepository _comp;

        public CompanySetup(CompanySetupRepository repository, CompanyTypeRepository companyTypeRepository)
        {
            _repository = repository;
            _comp = companyTypeRepository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllCompanySetup());
        }
        [HttpGet]
        public async  Task<IActionResult> Create()
        {

            ViewBag.Companytype = new SelectList(await _comp.GetcompanyTypeDropDown(), "CompanyTypeId", "CompanyTypeName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VmCompnaySetup model)
        {
            if (ModelState.IsValid)
            {
                int id = await _repository.AddCompnaySetup(model);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Companytype = new SelectList(await _comp.GetcompanyTypeDropDown(), "CompanyTypeId", "CompanyTypeName");
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _repository.GetAllCompanySetupID(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VmCompnaySetup model)
        {
            await _repository.EditCompanySetup(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteCompanySetupID(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _repository.Details(id));
        }
    }
}

