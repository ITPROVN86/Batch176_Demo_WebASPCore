﻿using MyStockLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockLibrary.Repository
{
    public class KhachHangRepository: IKhachHangRepository
    {
        public IEnumerable<KhachHang> GetKhachHangs(string sortBy) => KhachHangDao.Instance.GetKhachHangList(sortBy);
        public IEnumerable<KhachHang> GetKhachHangByName(string name, string CityName, string sortBy) => KhachHangDao.Instance.GetKhachHangBySearchName(name, CityName, sortBy);
    /*    public IEnumerable<KhachHang> ListByKhachHangName(string stringQuery, ref int totalRecord, int pageIndex, int pageSize)=>KhachHangDao.Instance.ListByKhachHangName(stringQuery, ref totalRecord, pageIndex, pageSize);*/
        public KhachHang GetKhachHangByID(int id) => KhachHangDao.Instance.GetKhachHangByID(id);
        public void InsertKhachHang(KhachHang kh) => KhachHangDao.Instance.AddNew(kh);
        public void UpdateKhachHang(KhachHang kh) => KhachHangDao.Instance.Update(kh);
        public void DeleteKhachHang(int id) => KhachHangDao.Instance.Remove(id);
        public IEnumerable<KhachHang> DeleteSelectedKhachHang(IEnumerable<int> DeleteList)=> KhachHangDao.Instance.RemoveKhachHangSelected(DeleteList);
    }
}
