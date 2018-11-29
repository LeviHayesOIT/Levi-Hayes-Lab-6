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
    public class CandyController : Controller
    {
        private ICandyRepository _CandyRepo;
        public CandyController(ICandyRepository candyRepo)
        {
            _CandyRepo = candyRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CandyModel model = new CandyModel();
            model.CandyList = _CandyRepo.GetList();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CandyModel model)
        {
            Candy candy = new Candy();
            candy.productName = model.CandyName;
            _CandyRepo.Insert(candy);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _CandyRepo.Delete(id);
            return RedirectToAction("Index");

        }
    }
}