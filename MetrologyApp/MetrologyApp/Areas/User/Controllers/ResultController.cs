using MetrologyApp.DataAccess;
using MetrologyApp.DataAccess.Repository.IRepository;
using MetrologyApp.Mathematics;
using MetrologyApp.Models;
using MetrologyApp.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace MetrologyApp.Controllers
{
    public class ResultController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResultController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Result> objResultList = _unitOfWork.Result.GetAll();

            return View(objResultList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Result obj)
        {
            if (ModelState.IsValid)
            {
                var nominalPoint = _unitOfWork.NominalPoint.GetFirstOrDefault(u => u.Id == obj.NominalPointId);
                var actualPoint = _unitOfWork.ActualPoint.GetFirstOrDefault(u => u.Id == obj.ActualPointId);

                IEnumerable<ActualPoint> objActualPointList = _unitOfWork.ActualPoint.GetAll();

                ActualPoint[] actualArray = objActualPointList.ToArray<ActualPoint>();

                if (nominalPoint != null && actualPoint != null)
                {
                    obj.deviation = Calculate.Deviation(nominalPoint, actualPoint);
                    obj.avgPointX = GetAverageActualPoint(actualArray).Item1;
                    obj.avgPointY = GetAverageActualPoint(actualArray).Item2;
                    obj.avgPointZ = GetAverageActualPoint(actualArray).Item3;


                    _unitOfWork.Result.Add(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "[Calculation added successfuly]";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "[The inserted ID value was not found]";
                    return View(obj);
                }

            }
            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var ResultDb = _unitOfWork.Result.GetFirstOrDefault(u => u.Id == id);

            if (ResultDb == null)
                return NotFound();

            return View(ResultDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Result obj)
        {
            if (ModelState.IsValid)
            {
                var nominalPoint = _unitOfWork.NominalPoint.GetFirstOrDefault(u => u.Id == obj.NominalPointId);
                var actualPoint = _unitOfWork.ActualPoint.GetFirstOrDefault(u => u.Id == obj.ActualPointId);

                IEnumerable<ActualPoint> objActualPointList = _unitOfWork.ActualPoint.GetAll();

                ActualPoint[] actualArray = objActualPointList.ToArray<ActualPoint>();


                if (nominalPoint != null && actualPoint != null)
                {
                    obj.deviation = Calculate.Deviation(nominalPoint, actualPoint);
                    obj.avgPointX = GetAverageActualPoint(actualArray).Item1;
                    obj.avgPointY = GetAverageActualPoint(actualArray).Item2;
                    obj.avgPointZ = GetAverageActualPoint(actualArray).Item3;

                    _unitOfWork.Result.Update(obj);
                    _unitOfWork.Save();
                    TempData["success"] = "[Calculation update successfuly]";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "[The inserted ID value was not found]";
                    return View(obj);
                }
            }
            return View(obj);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var ResultDb = _unitOfWork.Result.GetFirstOrDefault(u => u.Id == id);

            if (ResultDb == null)
                return NotFound();

            return View(ResultDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePoint(int? id)
        {
            var obj = _unitOfWork.Result.GetFirstOrDefault(u => u.Id == id);

            if (obj == null)
                return NotFound();

            _unitOfWork.Result.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "[Calculation deleted successfuly]";
            return RedirectToAction("Index");
        }

        public (double, double, double) GetAverageActualPoint(ActualPoint[] arr)
        {
            double x = 0, y = 0, z = 0;

            for(int i = 0; i < arr.Length; i++)
            {
                x += arr[i].X;
                y += arr[i].Y;
                z += arr[i].Z;
            }

            return (Calculate.AveragePoint(x, arr.Length), Calculate.AveragePoint(y, arr.Length), Calculate.AveragePoint(z, arr.Length));
        }

    }
}
