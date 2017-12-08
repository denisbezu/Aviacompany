using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.Concrete;
using Aviacompany.Library.Entities;
using Microsoft.AspNet.Identity;

namespace Aviacompany.Controllers
{
    public class CityController : BaseController
    {
        private ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }
        // GET: City
        public ActionResult Index()
        {
            return View(_cityRepository.Cities);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                _cityRepository.SaveCity(new City() { CityName = name });
                return RedirectToAction("Index");
            }
            return View(name);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        [HttpPost]
        public ActionResult Delete(int cityId)
        {
            City deletedFligt = _cityRepository.DeleteCity(cityId);
            return RedirectToAction("Index");
        }

        public ViewResult Edit(int cityId)
        {
            City city = _cityRepository.Cities
                .FirstOrDefault(g => g.CityId == cityId);
            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                _cityRepository.SaveCity(city);
                return RedirectToAction("Index");
            }
                return View(city);
        }
    }
}