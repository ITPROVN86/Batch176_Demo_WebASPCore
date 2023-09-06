using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockLibrary.DataAccess
{
    public class KhachHangDao
    {
        private static KhachHangDao instance = null;
        private static readonly object instanceLock = new object();
        public static KhachHangDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new KhachHangDao();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<KhachHang> GetKhachHangList()
        {
            var khachHangs = new List<KhachHang>();
            try
            {
                using var context = new MyStockContext();
                khachHangs = context.KhachHangs.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return khachHangs;
        }

        public KhachHang GetKhachHangByID(int id)
        {
            KhachHang kh = null;
            try
            {
                using var context = new MyStockContext();
                kh = context.KhachHangs.SingleOrDefault(k => k.MaKhachHang == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return kh;
        }

        public IEnumerable<KhachHang> GetKhachHangBySearchName(string name)
        {
            var khachHangs = new List<KhachHang>();
            try
            {
                using var context = new MyStockContext();
                khachHangs = context.KhachHangs.Where(k => k.TenKhachHang.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return khachHangs;
        }

        public void AddNew(KhachHang kh)
        {

            try
            {
                KhachHang _kh = GetKhachHangByID(kh.MaKhachHang);
                if (_kh == null)
                {
                    using var context = new MyStockContext();
                    context.KhachHangs.Add(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(KhachHang kh)
        {

            try
            {
                KhachHang _kh = GetKhachHangByID(kh.MaKhachHang);
                if (_kh != null)
                {
                    using var context = new MyStockContext();
                    context.KhachHangs.Update(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                KhachHang _kh = GetKhachHangByID(id);
                if (_kh != null)
                {
                    using var context = new MyStockContext();
                    context.KhachHangs.Remove(_kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
