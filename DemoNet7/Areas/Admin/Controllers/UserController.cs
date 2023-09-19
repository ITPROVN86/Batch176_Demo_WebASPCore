using DemoNet7.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyStockLibrary.Repository;
using X.PagedList;

namespace DemoNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class UserController : BaseController
    {
        INguoiDungRepository nguoiDungRepository = null;
        public UserController() => nguoiDungRepository = new NguoiDungRepository();
        // GET: UserController
        public ActionResult Index(string searchString, int UserType, int? page, string sortBy)
        {
            var nguoiDungList = nguoiDungRepository.GetNguoiDungByNames(searchString is null ? null : searchString, UserType, sortBy).ToPagedList(page ?? 1, 5);

            List<LoaiNguoiDung> list_NguoiDung = new List<LoaiNguoiDung>
            {
                new LoaiNguoiDung{Id=1,Name="Khách hàng", Color="Green"},
                new LoaiNguoiDung{Id =2,Name="Nhân viên", Color = "Blue"},
                new LoaiNguoiDung{Id =3,Name="Quản trị", Color = "Red"}
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

        public JsonResult ListName(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                var data = nguoiDungRepository.GetNguoiDungByNames(q.ToLower(), 0, "name");
                var responseData = data.Select(kh => kh.TenNguoiDung).ToList();
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
