using AutoMapper;
using MyStockLibrary.DataAccess;

namespace ExamConsole
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, KhachHang>();
        }
    }
}
