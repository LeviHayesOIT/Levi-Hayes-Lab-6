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
using System.Diagnostics;

namespace Levi_Hayes_Lab_6.Controllers
{
    public class HomeController : Controller
    {
        private ITreaterRepository _TreaterRepository;
        private ICandyRepository _CandyRepository;
        private ICostumeRepository _CostumeRepository;
        public HomeController(ITreaterRepository treaterRepository, ICandyRepository candyRepository, ICostumeRepository costumeRepository)
        {
            _TreaterRepository = treaterRepository;
            _CandyRepository = candyRepository;
            _CostumeRepository = costumeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            TreaterModel model = new TreaterModel();
            model.TreaterList = _TreaterRepository.GetList();
            model.CandyList = _CandyRepository.GetList();
            model.CostumeList = _CostumeRepository.GetList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(TreaterModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", model);

            model.CostumeName = _CostumeRepository.GetList().Select(m => m).First(m => m.id == model.CostumeID).costume;
            model.CandyName = _CandyRepository.GetList().Select(m => m).First(m => m.id == model.CandyID).productName;
           
            _TreaterRepository.Insert(model.GetTreaterObject());
            return RedirectToAction("Index");

        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
