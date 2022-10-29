using HRMSProject.Models;
using HRMSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Controllers
{
    public class Designations : Controller
    {
        private readonly DesignationRepository _repository;

        public Designations(DesignationRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllDesignation());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VmDesignation model)
        {
            if (ModelState.IsValid)
            {
                int id = await _repository.AddDesignation(model);
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
            return View(await _repository.GetAllDesignationId(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VmDesignation model)
        {
            await _repository.EditDesignation(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteDesignation(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _repository.Details(id));
        }
    }
}
