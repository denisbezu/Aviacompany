using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.Entities;
using Microsoft.AspNet.Identity;

namespace Aviacompany.Controllers
{
    public class RequestController : BaseController
    {
        private IRequestRepositiry _requestRepositiry;
        private IBrigadeRepository _brigadeRepository;
        public RequestController(IRequestRepositiry requestRepositiry, IBrigadeRepository brigadeRepository)
        {
            _requestRepositiry = requestRepositiry;
            _brigadeRepository = brigadeRepository;
        }

        public ActionResult Index()
        {
            return View(_requestRepositiry.Requests);
        }

        public ActionResult Refuse(int requestId)
        {
            TempData["message"] = "Заявка №" + requestId + " отклонена!";
            Request request = _requestRepositiry.Requests.First(req => req.RequestId == requestId);
            request.RequestType = RequestType.Rejected;
            _requestRepositiry.SaveRequest(request);
            return RedirectToAction("Index");
        }

        public ActionResult Accept(int requestId)
        {
            TempData["message"] = "Заявка №" + requestId + " принята!";
            Request request = _requestRepositiry.Requests.First(req => req.RequestId == requestId);
            request.RequestType = RequestType.Accepted;
            _requestRepositiry.SaveRequest(request);
            return RedirectToAction("Index");
        }


        //[HttpPost]
        //public ActionResult Delete(int cityId)
        //{
        //    City deletedFligt = _requestRepositiry.DeleteCity(cityId);
        //    return RedirectToAction("Index");
        //}

        public ActionResult Create(int brigadeId)
        {
            Brigade brigade = _brigadeRepository.Brigades.First(p => p.BrigadeId == brigadeId);
            return View(new Request() { BrigadeId = brigadeId, Brigade = brigade});
        }

        [HttpPost]
        public ActionResult Create(Request request)
        {
            if (request.Message == null || request.Message.Trim().Length == 0)
            {
                return View(request);
            }
            _requestRepositiry.SaveRequest(request);
            return RedirectToAction("Index", "Home");
        }
    }
}