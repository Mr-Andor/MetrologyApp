using MetrologyApp.DataAccess;
using MetrologyApp.DataAccess.Repository.IRepository;
using MetrologyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetrologyApp.Controllers
{
    public class ActualPointController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActualPointController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ActualPoint> objActualPointList = _unitOfWork.ActualPoint.GetAll();
            return View(objActualPointList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ActualPoint obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ActualPoint.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "[Actual Point added successfuly]";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var ActualPointDb = _unitOfWork.ActualPoint.GetFirstOrDefault(u => u.Id == id);

            if (ActualPointDb == null)
                return NotFound();

            return View(ActualPointDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ActualPoint obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ActualPoint.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "[Actual Point updated successfuly]";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var ActualPointDb = _unitOfWork.ActualPoint.GetFirstOrDefault(u => u.Id == id);

            if (ActualPointDb == null)
                return NotFound();

            return View(ActualPointDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePoint(int? id)
        {
            var obj = _unitOfWork.ActualPoint.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
                return NotFound();

            _unitOfWork.ActualPoint.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "[Actual Point deleted successfuly]";
            return RedirectToAction("Index");
        }

    }
}
