using HRMSProject.Models;
using HRMSProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Controllers
{
    public class Banks : Controller
    {
        private readonly BankRepository _repository;

        public Banks(BankRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllBank());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VmBank model)
        {
            if (ModelState.IsValid)
            {
                int id = await _repository.AddBank(model);
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
            return View(await _repository.GetAllBankID(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VmBank model)
        {
            await _repository.EditBank(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteBank(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _repository.Details(id));
        }
    }
}
