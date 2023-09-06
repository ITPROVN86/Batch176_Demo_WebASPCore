using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStockLibrary.DataAccess;
using MyStockLibrary.Repository;

namespace DemoNet7.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        IKhachHangRepository khachHangRepository = null;
        public CustomerController() => khachHangRepository = new KhachHangRepository();
        // GET: CustomerController

        /* public ActionResult Index()
         {
             var khachHangList = khachHangRepository.GetKhachHangs();
             return View(khachHangList);
         }*/

        [HttpGet]
        public ActionResult Index(string searchString)
        {

            var khachHangList = khachHangRepository.GetKhachHangByName(searchString);
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
                khachHangRepository.InsertKhachHang(kh);
                TempData["Message"] = "Tạo mới thành công";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                TempData["Message"] = "Cập nhật thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                khachHangRepository.DeleteKhachHang(id);
                TempData["Message"] = "Xoá thành công";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
