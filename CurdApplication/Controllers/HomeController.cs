using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudApplication.Modul;
using CrudApplication.Class.CrudApplicationRepository;

namespace CurdApplication.Controllers
{
    public class HomeController : Controller
    {
        CrudApplicationRepo repo = null;

        public HomeController()
        {
            repo = new CrudApplicationRepo();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(PersonDetailModal person)
        {
            if (ModelState.IsValid)
            {
                int id = repo.AddPersonDetail(person);
                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Success = "Your Detail has been sent. Thank you!";
                }
            }
           
            return View();
        }

        public ActionResult DetailShowPage()
        {
            var Result = repo.GetPerosonDetail();
            return View(Result);
        }

        public ActionResult Details(int Id)
        {
            var DetailsResult = repo.PersonIndividualDetail(Id);
            return View(DetailsResult);
        }

        public ActionResult Edit(int Id)
        {
            var DetailsResult = repo.PersonIndividualDetail(Id);
            return View(DetailsResult);
        }

        [HttpPost]
        public ActionResult Edit(PersonDetailModal person)
        {
            if (ModelState.IsValid)
            {
                repo.PersonEditDetail(person.Id, person);
                return RedirectToAction("DetailShowPage");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            repo.DeleteDetail(Id);
            return RedirectToAction("DetailShowPage");
        }

        public ActionResult PopModelDetails(int Id)
        {
            var DetailsResult = repo.PersonIndividualDetail(Id);
            return PartialView(DetailsResult);
        }



    }
}