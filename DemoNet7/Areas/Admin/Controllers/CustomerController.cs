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
            if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
            {
                var khachHangList = khachHangRepository.GetKhachHangByName(searchString);

                return View(khachHangList);
            }
            return View("Index");
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(KhachHang kh)
        {
            try
            {
                khachHangRepository.InsertKhachHang(kh);
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
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
