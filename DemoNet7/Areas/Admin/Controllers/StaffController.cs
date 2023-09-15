using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStockLibrary.DataAccess;
using MyStockLibrary.Repository;
using System.Globalization;
using X.PagedList;

namespace DemoNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class StaffController : Controller
    {
        INhanVienRepository nhanVienRepository = null;
        public StaffController() => nhanVienRepository = new NhanVienRepository();
        // GET: StaffController
        public ActionResult Index(int? page, string sortBy)
        {
            var nhanVienList = nhanVienRepository.GetNhanViens(sortBy).ToPagedList(page ?? 1, 5);
            return View(nhanVienList);
        }


        // GET: StaffController/Details/5
        public ActionResult Details(int id)
        {
            var nv = nhanVienRepository.GetNhanVienByID(id);
            return View(nv);
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhanVien nv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nhanVienRepository.InsertNhanVien(nv);
                    TempData["Message"] = "Tạo mới thành công";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới nhân viên không thành công");
                }
            }
            catch
            {

            }
            return View(nv);
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            var nv = nhanVienRepository.GetNhanVienByID(id);
            return View(nv);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NhanVien nv)
        {
            try
            {
                nhanVienRepository.UpdateNhanVien(nv);
                TempData["Message"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffController/Delete/5
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

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new NhanVienDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}
