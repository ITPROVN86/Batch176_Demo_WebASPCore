using MyStockLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockLibrary.Repository
{
    public interface IKhachHangRepository
    {
        IEnumerable<KhachHang> GetKhachHangs();
        IEnumerable<KhachHang> GetKhachHangByName(string name);
        KhachHang GetKhachHangByID(int id);
        void InsertKhachHang(KhachHang kh);
        void UpdateKhachHang(KhachHang kh);
        void DeleteKhachHang(int id);
    }
}
