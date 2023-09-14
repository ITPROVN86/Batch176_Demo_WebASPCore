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
        IEnumerable<KhachHang> GetKhachHangs(string sortBy);
        IEnumerable<KhachHang> GetKhachHangByName(string name,string CityName,string sortBy);
       /* IEnumerable<KhachHang> ListByKhachHangName(string stringQuery);*/
        KhachHang GetKhachHangByID(int id);
        void InsertKhachHang(KhachHang kh);
        void UpdateKhachHang(KhachHang kh);
        void DeleteKhachHang(int id);
        IEnumerable<KhachHang> DeleteSelectedKhachHang(IEnumerable<int> DeleteList);
    }
}
