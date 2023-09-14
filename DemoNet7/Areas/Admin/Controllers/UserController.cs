using DemoNet7.Areas.Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStockLibrary.Repository;
using X.PagedList;

namespace DemoNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        INguoiDungRepository nguoiDungRepository = null;
        public UserController() => nguoiDungRepository = new NguoiDungRepository();
        // GET: UserController
        public ActionResult Index(int? page, string sortBy)
        {
            var nguoiDungList = nguoiDungRepository.GetNguoiDungs(sortBy).ToPagedList(page ?? 1, 5);
            List<LoaiNguoiDung> list_NguoiDung = new List<LoaiNguoiDung>
            {
                new LoaiNguoiDung{Id=1,Name="Quản trị", Color="Red"},
                new LoaiNguoiDung{Id =2,Name="Nhân viên", Color = "Blue"}
            };
            ViewBag.LoaiNguoiDung = list_NguoiDung;
            return View(nguoiDungList);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
