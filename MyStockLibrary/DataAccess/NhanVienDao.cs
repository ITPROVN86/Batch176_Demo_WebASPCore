using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockLibrary.DataAccess
{
    public class NhanVienDao
    {
        private static NhanVienDao instance = null;
        private static readonly object instanceLock = new object();
        public static NhanVienDao Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NhanVienDao();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<NhanVien> GetNhanVienList(string sortBy)
        {
            using var context = new MyStockContext();
            List<NhanVien> model = context.NhanViens.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenNhanVien).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenNhanVien).ToList();
                        break;
                    case "address":
                        model = model.OrderBy(o => o.DiaChi).ToList();
                        break;
                    case "addressdesc":
                        model = model.OrderByDescending(o => o.DiaChi).ToList();
                        break;
                    case "id":
                        model = model.OrderBy(o => o.MaNhanVien).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaNhanVien).ToList();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }

        public NhanVien GetNhanVienByID(int id)
        {
            NhanVien nv = null;
            try
            {
                using var context = new MyStockContext();
                nv = context.NhanViens.SingleOrDefault(k => k.MaNhanVien == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nv;
        }

        public void AddNew(NhanVien nv)
        {

            try
            {
                NhanVien _nv = GetNhanVienByID(nv.MaNhanVien);
                if (_nv == null)
                {
                    using var context = new MyStockContext();
                    context.NhanViens.Add(nv);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Staff is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(NhanVien nv)
        {

            try
            {
                NhanVien _nv = GetNhanVienByID(nv.MaNhanVien);
                if (_nv != null)
                {
                    using var context = new MyStockContext();
                    context.NhanViens.Update(nv);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Staff does not already exist.");
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
                NhanVien _nv = GetNhanVienByID(id);
                if (_nv != null)
                {
                    using var context = new MyStockContext();
                    context.NhanViens.Remove(_nv);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Staff does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NhanVien> RemoveNhanVienSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyStockContext();
            var DeleteCatList = context.NhanViens.Where(z => DeleteList.Contains(z.MaNhanVien)).ToList();
            context.NhanViens.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }

        public bool ChangeStatus(int id)
        {
            using var context = new MyStockContext();
            var nv = context.NhanViens.Find(id);
            nv.GioiTinh = !nv.GioiTinh;
            //context.NhanViens.Update(nv);
            context.SaveChanges();
            return nv.GioiTinh;
        }
    }
}
