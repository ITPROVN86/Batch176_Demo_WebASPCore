using MyStockLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStockLibrary.Repository
{
    public interface INguoiDungRepository
    {
        IEnumerable<NguoiDung> GetNguoiDungs(string sortBy);
    }
}
