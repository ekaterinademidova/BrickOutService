using BrickOutService.DataAccess.Data;
using BrickOutService.DataAccess.Repository;
using BrickOutService.DataAccess.Repository.IRepository;
using BrickOutService.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrickOutService.Controllers
{
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Brand> objBrandList = _unitOfWork.Brand.GetAll().ToList();
            return View(objBrandList);
        }

        public IActionResult Upsert(int? id)
        {
            Brand? brand = new();
            if (id == null || id == 0)
            {
                //create
                return View(brand);
            }
            else
            {
                //update
                brand = _unitOfWork.Brand.Get(u => u.Id == id);
                if (brand == null)
                {
                    return NotFound();
                }
                return View(brand);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Brand obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Brand.Add(obj);
                    TempData["success"] = "The brand is created successfully";
                }
                else
                {
                    _unitOfWork.Brand.Update(obj);
                    TempData["success"] = "The brand is updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
