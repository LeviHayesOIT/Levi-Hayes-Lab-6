using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Levi_Hayes_Lab_6.Models;
using Levi_Hayes_Lab_6.Repositories;
using Levi_Hayes_Lab_6.ExtensionMethods;

namespace Levi_Hayes_Lab_6.Controllers
{
    public class CostumeController : Controller
    {
        private ICostumeRepository _CostumeRepo;
        public CostumeController(ICostumeRepository costumeRepo)
        {
            _CostumeRepo = costumeRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CostumeModel model = new CostumeModel();
            model.CostumeList = _CostumeRepo.GetList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CostumeModel model)
        {
            Costume costume = new Costume();
            costume.id = model.CostumeID;
            costume.costume = model.CostumeName;
            _CostumeRepo.Insert(costume);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _CostumeRepo.Delete(id);
            return RedirectToAction("Index");

        }
    }
}