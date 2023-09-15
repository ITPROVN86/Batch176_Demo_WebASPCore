using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStockLibrary.DataAccess;
using MyStockLibrary.Repository;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using X.PagedList;

namespace DemoNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CustomerController : BaseController
    {
        IKhachHangRepository khachHangRepository = null;
        public CustomerController() => khachHangRepository = new KhachHangRepository();
        // GET: CustomerController

        /* public ActionResult Index()
         {
             var khachHangList = khachHangRepository.GetKhachHangs();
             return View(khachHangList);
         }*/

        /*   [HttpGet]
           public ActionResult Index(string searchString)
           {
               if (!string.IsNullOrEmpty(searchString))
               {
                   searchString = searchString.ToLower();
               }
               var khachHangList = khachHangRepository.GetKhachHangByName(searchString);
               return View(khachHangList);

           }*/

        /*        public JsonResult GetCitys()
                {
                    var citys = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Đà Nẵng" },
                new SelectListItem { Value = "2", Text = "Huế" },
                new SelectListItem { Value = "3", Text = "Quảng Bình" }
            };
                    var result = new
                    {
                        City = citys,
                        AdditionalInfo = "Test"
                    };
                    ViewBag.City = citys;
                    return Json(result);
                }*/

        public IActionResult GetCityById(string searchString, string CityName, int? page, string sortBy)
        {
            var khachHangList = khachHangRepository.GetKhachHangByName(searchString is null ? null : searchString, CityName is null ? null : CityName.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
            return Ok(khachHangList);
        }

        [HttpGet]
        public ActionResult Index(string searchString,string CityName, int? page, string sortBy)
        {
            var khachHangList = khachHangRepository.GetKhachHangByName(searchString is null?null: searchString.ToLower(), CityName is null? null: CityName.ToLower(), sortBy).ToPagedList(page ?? 1, 5);
           /* }*/

            //Hiển thị thành phố
            var citys = new List<SelectListItem>
    {
        new SelectListItem { Value = "1", Text = "Đà Nẵng" },
        new SelectListItem { Value = "2", Text = "Huế" },
        new SelectListItem { Value = "3", Text = "Quảng Bình" }
    };

            ViewBag.City = citys;

            //TempData["searchString"] = searchString;
            return View(khachHangList);

        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        /*        [ValidateAntiForgeryToken]*/
        public ActionResult Create(KhachHang kh)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    khachHangRepository.InsertKhachHang(kh);
                    SetAlert("Tạo mới thành công", "error");
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Tạo mới khách hàng không thành công");
                }
            }
            catch
            {

            }
            return View(kh);
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var kh = khachHangRepository.GetKhachHangByID(id);
            return View(kh);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, KhachHang kh)
        {
            try
            {
                khachHangRepository.UpdateKhachHang(kh);
                SetAlert("Cập nhật thành công", "error");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        /* public ActionResult Delete(int id)
         {
             return View();
         }*/

        [HttpPost]
        public JsonResult DeleteId(int id)
        {
            try
            {
                var record = khachHangRepository.GetKhachHangByID(id);
                if (record == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy bản ghi" });
                }
                khachHangRepository.DeleteKhachHang(id);
                SetAlert("Xoá thành công", "error");
                /*return Json(new { success = true, id = id});*/
                return Json(new
                {
                    status = true
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                khachHangRepository.DeleteKhachHang(id);
                SetAlert("Xoá thành công", "error");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteMultiple(IEnumerable<int> SelectedCatDelete)
        {
            if (SelectedCatDelete.Count() == 0)
            {
                ViewBag.DelError = "Yes";
                ViewBag.DelTitle = "Delete operation has not been completed";
                ViewBag.DelMessage = "This record can not be deleted, beacuse one or more cost record use this customer.";
                return View("Error");
                //return RedirectToAction("ExceptionError", "Error", new { area = "" });
            }
            khachHangRepository.DeleteSelectedKhachHang(SelectedCatDelete);
            TempData["Message"] = $"Xoá {SelectedCatDelete.Count()} hàng thành công";
            return RedirectToAction("Index");
        }


        public JsonResult ListName(string q)
        {
            if (!string.IsNullOrEmpty(q))
            {
                var data = khachHangRepository.GetKhachHangByName(q.ToLower(),"", "name");
                var responseData = data.Select(kh => kh.TenKhachHang).ToList();
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
