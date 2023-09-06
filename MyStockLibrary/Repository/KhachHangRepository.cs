using MyStockLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockLibrary.Repository
{
    public class KhachHangRepository: IKhachHangRepository
    {
        public IEnumerable<KhachHang> GetKhachHangs() => KhachHangDao.Instance.GetKhachHangList();
        public IEnumerable<KhachHang> GetKhachHangByName(string name) => KhachHangDao.Instance.GetKhachHangBySearchName(name);
        public KhachHang GetKhachHangByID(int id) => KhachHangDao.Instance.GetKhachHangByID(id);
        public void InsertKhachHang(KhachHang kh) => KhachHangDao.Instance.AddNew(kh);
        public void UpdateKhachHang(KhachHang kh) => KhachHangDao.Instance.Update(kh);
        public void DeleteKhachHang(int id) => KhachHangDao.Instance.Remove(id);
    }
}
