using BrickOutService.DataAccess.Data;
using BrickOutService.DataAccess.Repository;
using BrickOutService.DataAccess.Repository.IRepository;
using BrickOutService.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BrickOutService.Controllers
{
    public class TypeOfDeviceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TypeOfDeviceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<TypeOfDevice> objTypeOfDeviceList = _unitOfWork.TypeOfDevice.GetAll().ToList();
            return View(objTypeOfDeviceList);
        }

        public IActionResult Upsert(int? id)
        {
            TypeOfDevice? typeOfDevice = new();
            if (id == null || id == 0)
            {
                //create
                return View(typeOfDevice);
            }
            else
            {
                //update
                typeOfDevice = _unitOfWork.TypeOfDevice.Get(u => u.Id == id);
                if (typeOfDevice == null)
                {
                    return NotFound();
                }
                return View(typeOfDevice);
            }
        }

        [HttpPost]
        public IActionResult Upsert(TypeOfDevice obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.TypeOfDevice.Add(obj);
                    TempData["success"] = "The type of device is created successfully";
                }
                else
                {
                    _unitOfWork.TypeOfDevice.Update(obj);
                    TempData["success"] = "The type of device is updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
