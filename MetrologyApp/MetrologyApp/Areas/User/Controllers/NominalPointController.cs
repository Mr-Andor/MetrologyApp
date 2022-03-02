using MetrologyApp.DataAccess;
using MetrologyApp.DataAccess.Repository.IRepository;
using MetrologyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MetrologyApp.Controllers
{
    public class NominalPointController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public NominalPointController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<NominalPoint> objNominalPointList = _unitOfWork.NominalPoint.GetAll();
            return View(objNominalPointList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NominalPoint obj)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.NominalPoint.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "[Nominal Point added successfuly]";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var nominalPointDb = _unitOfWork.NominalPoint.GetFirstOrDefault(u => u.Id ==  id);

            if (nominalPointDb == null)
                return NotFound();

            return View(nominalPointDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NominalPoint obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.NominalPoint.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "[Nominal Point updated successfuly]";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var nominalPointDb = _unitOfWork.NominalPoint.GetFirstOrDefault(u => u.Id == id);

            if (nominalPointDb == null)
                return NotFound();

            return View(nominalPointDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePoint(int? id)
        {
            var obj = _unitOfWork.NominalPoint.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
                return NotFound();

            _unitOfWork.NominalPoint.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "[Nominal Point deleted successfuly]";
            return RedirectToAction("Index");
        }

    }
}
