using AutoMapper;
using MyStockLibrary.DataAccess;

namespace ExamConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating the source object
            var employees = new List<Customer>()
            {
                new Customer
                {
                TenKhachHang = "James",
                DiaChi = "London"
                }
                ,
                new Customer
                {
                    TenKhachHang = "Bon",
                    DiaChi = "LA"
                }
            };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            var mapper = config.CreateMapper();

            // Chuyển đổi danh sách Employee qua danh sách EmployeeDto.
            var empDtos = employees.Select(emp => mapper.Map<Customer, KhachHang>(emp));
            foreach (var empDto in empDtos)
            {
                Console.WriteLine("Name:" + empDto.TenKhachHang +
                                  ", Address:" + empDto.DiaChi);
            }
            Console.ReadLine();

        }
    }
}