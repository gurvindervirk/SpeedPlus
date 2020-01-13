using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using DataContext;
using VegaBusinessLayer;
using VegaModel;

namespace MasterLayout.Controllers
{
    [Authorize(Roles = "ADMIN, USER, SUPERUSER, SUPERADMIN")]
    
    [SessionState(SessionStateBehavior.Default)]
    public class VegetableController : Controller
    {
        private VegetableLogic _logic;
        public VegetableController()
        {
            GenericRepository<VegetableModel> repo = new GenericRepository<VegetableModel>();
            _logic = new VegetableLogic(repo);
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _logic.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(VegetableModel model)
        {
            bool isUsernameExists = _logic.Authenticate(model.Vegetable);

            if (isUsernameExists == true)
            {
                ModelState.AddModelError("", errorMessage: "Vegetable Already Used try unique one!");
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Add(model);
                    TempData["SuccessMessage"] = "Saved Successfully";
                    return RedirectToAction("Index", "Vegetable");
                }
            }
            catch (DbUpdateException  /* ex */ )
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            VegetableModel model = _logic.Get(Id);
            Session["vegName"] = Convert.ToString(model.Vegetable);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VegetableModel model)
        {
            var oldname = Session["vegName"] as string;
            if (oldname != model.Vegetable)
            {
                bool isValid = _logic.Authenticate(model.Vegetable);
                if (isValid == true)
                {
                    ModelState.AddModelError("", errorMessage: "Vegetable Already Used try unique one!");
                }
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _logic.Update(model);
                    TempData["SuccessMessage"] = "Updated Successfully";
                    return RedirectToAction("Index", "Vegetable");
                }
            }
            catch (DbUpdateException  /* ex */ )
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteLogin(int Id, bool? saveChangesError = false)
        {
            VegetableModel model = _logic.Get(Id);
            if (model == null)
            {
                return HttpNotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id)
        {
            try
            {
                _logic.Delete(Id);
                TempData["SuccessMessage"] = "Deleted Successfully";
                return RedirectToAction("Index", "Vegetable");
            }
            catch (DbUpdateException  /* ex */ )
            {
                return RedirectToAction(nameof(Delete), new { Id, saveChangesError = true });
            }
        }
        [HttpPost]
        public JsonResult IsVegNameExists(string vegetable)
        {
            var oldname = Session["vegName"] as string;
            if (oldname != vegetable)
            {
                bool isValid = _logic.Authenticate(vegetable);
                return Json(isValid);
            }
            else
            {
                return Json(false);
            }
        }
    }
}