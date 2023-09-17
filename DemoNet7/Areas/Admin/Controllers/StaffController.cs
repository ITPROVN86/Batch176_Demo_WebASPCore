using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStockLibrary.DataAccess;
using MyStockLibrary.Repository;
using System.Globalization;
using X.PagedList;

namespace DemoNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class StaffController : BaseController
    {
        INhanVienRepository nhanVienRepository = null;
        public StaffController() => nhanVienRepository = new NhanVienRepository();

        public IActionResult GetCityById(string searchString, string CityName, int? page, string sortBy)
        {
            var khachHangList = nhanVienRepository.GetNhanVienByName(searchString is null ? null : searchString, CityName is null ? null : CityName.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
            return Ok(khachHangList);
        }
        // GET: StaffController
        public ActionResult Index(string searchString, string CityName, int? page, string sortBy)
        {
            var nhanVienList = nhanVienRepository.GetNhanVienByName(searchString is null ? null : searchString.ToLower(), CityName is null ? null : CityName.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
            //Hiển thị thành phố
            var citys = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Đà Nẵng" },
        new SelectListItem { Value = "2", Text = "Huế" },
        new SelectListItem { Value = "3", Text = "Quảng Bình" }
    };

            ViewBag.City = citys;
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
                    SetAlert("Tạo mới thành công", "error");
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
                SetAlert("Cập nhật thành công", "error");
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

        public JsonResult ListName(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                var data = nhanVienRepository.GetNhanVienByName(q.ToLower(), "", "name");
                var responseData = data.Select(kh => kh.TenNhanVien).ToList();
                return Json(new
                {
                    data = responseData,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
    }
}
