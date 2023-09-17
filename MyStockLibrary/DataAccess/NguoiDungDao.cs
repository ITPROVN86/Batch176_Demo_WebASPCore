using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockLibrary.DataAccess
{
    public class NguoiDungDao
    {
        private static NguoiDungDao instance = null;
        private static readonly object instanceLock = new object();
        public static NguoiDungDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NguoiDungDao();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<NguoiDungViewModel> GetNguoiDungList(string sortBy)
        {
            using var context = new MyStockContext();
            var model
    = from u in context.NguoiDungs
      where u.LoaiNguoiDung == 1 || u.LoaiNguoiDung == 2
      select new NguoiDungViewModel
      {
          TenDangNhap = u.TenDangNhap,
          LoaiNguoiDung = u.LoaiNguoiDung,
          MaNguoiDung = u.LoaiNguoiDung == 1 ? "KH0"+u.MaNguoiDung:"NV0" + u.MaNguoiDung,
          TenNguoiDung = u.LoaiNguoiDung == 1 ? context.KhachHangs.FirstOrDefault(c => c.MaKhachHang == u.MaNguoiDung).TenKhachHang : context.NhanViens.FirstOrDefault(n => n.MaNhanVien == u.MaNguoiDung).TenNhanVien,
          GioiTinh = u.Status
      };

      
            //List<NguoiDung> model = context.NguoiDungs.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenDangNhap);
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenDangNhap);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model.ToList();
        }

        public IEnumerable<NguoiDungViewModel> GetNguoiDungByNames(string name, int userType, string sortBy)
        {
            using var context = new MyStockContext();
            var model
    = from u in context.NguoiDungs
      where u.LoaiNguoiDung == 1 || u.LoaiNguoiDung == 2 || u.LoaiNguoiDung == 3
      select new NguoiDungViewModel
      {
          TenDangNhap = u.TenDangNhap,
          LoaiNguoiDung = u.LoaiNguoiDung,
          MaNguoiDung = u.LoaiNguoiDung == 1 ? "KH0" + u.MaNguoiDung : "NV0" + u.MaNguoiDung,
          TenNguoiDung = u.LoaiNguoiDung == 1 ? context.KhachHangs.FirstOrDefault(c => c.MaKhachHang == u.MaNguoiDung).TenKhachHang : u.LoaiNguoiDung == 2 ? context.NhanViens.FirstOrDefault(n => n.MaNhanVien == u.MaNguoiDung).TenNhanVien:"Admin",
          GioiTinh = u.Status
      };


            //List<NguoiDung> model = context.NguoiDungs.ToList();
            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.TenNguoiDung.ToLower().Contains(name));
                }
                if (userType!=0)
                {
                    model = model.Where(x => x.LoaiNguoiDung==userType);
                }
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenNguoiDung);
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenNguoiDung);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model.ToList();
        }
    }
}
