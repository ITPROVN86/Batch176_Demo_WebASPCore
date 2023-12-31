﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using static System.Reflection.Metadata.BlobBuilder;

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

        #region Tìm kiếm, so sánh

        /// <summary>
        /// Chức năng: Hiển thị tất cả thông tin của khách hàng, kết hợp sắp xếp theo tên
        /// </summary>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<KhachHang> GetKhachHangList(string sortBy)
        {
            using var context = new MyStockContext();
            List<KhachHang> model = context.KhachHangs.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.TenKhachHang).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.TenKhachHang).ToList();
                        break;
                    case "address":
                        model = model.OrderBy(o => o.DiaChi).ToList();
                        break;
                    case "addressdesc":
                        model = model.OrderByDescending(o => o.DiaChi).ToList();
                        break;
                    case "id":
                        model = model.OrderBy(o => o.MaKhachHang).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.MaKhachHang).ToList();
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



        public IEnumerable<KhachHang> GetKhachHangBySearchName(string name, string CityName, string sortBy)
        {
            var context = new MyStockContext();
            /*var khachHangs = new List<KhachHang>();*/
            List<KhachHang> model = context.KhachHangs.ToList();

            try
            {
                /* if (!String.IsNullOrEmpty(name))
                 {*/
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.TenKhachHang.ToLower().Contains(name)).ToList();
                }
                if (!String.IsNullOrEmpty(CityName)) { 
                    model = model.Where(x => x.DiaChi.ToLower().Contains(CityName)).ToList();
                }
                switch (sortBy)
                    {
                        case "name":
                            model = model.OrderBy(o => o.TenKhachHang).ToList();
                            break;
                        case "namedesc":
                            model = model.OrderByDescending(o => o.TenKhachHang).ToList();
                            break;
                        case "address":
                            model = model.OrderBy(o => o.DiaChi).ToList();
                            break;
                        case "addressdesc":
                            model = model.OrderByDescending(o => o.DiaChi).ToList();
                            break;
                        case "id":
                            model = model.OrderBy(o => o.MaKhachHang).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.MaKhachHang).ToList();
                            break;
                        default:
                            break;
                    }
                /*}*/
                /*else
                {
                    return model;
                }*/
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }
        #endregion


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

        public IEnumerable<KhachHang> RemoveKhachHangSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyStockContext();
            var DeleteCatList = context.KhachHangs.Where(z => DeleteList.Contains(z.MaKhachHang)).ToList();
            context.KhachHangs.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }


        /* public IEnumerable<KhachHang> ListAllPaging(string stringQuery, int? page)
         {
             var context = new MyStockContext();
             return context.KhachHangs.ToPagedList(page ?? 1, 5);
         }

         public List<KhachHang> GetKHList(string stringQuery)
         {
             var context = new MyStockContext();
             var CL = context.KhachHangs.Where(x => x.TenKhachHang.Contains(stringQuery)).ToList();

             return CL;
         }*/
    }
}
