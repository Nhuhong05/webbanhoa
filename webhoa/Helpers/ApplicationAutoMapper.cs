using AutoMapper;
using webhoa.Entities;
using webhoa.Migrations;
using webhoa.Model;
using webhoa.ViewModel;

namespace webhoa.Helpers
{
    public class ApplicationAutoMapper : Profile
    {
        public ApplicationAutoMapper()
        {
            //CreateMap<Hoa, HoaVM>().ReverseMap();
            //CreateMap<LoaiHoa, LoaiHoaVM>().ReverseMap(); 
            CreateMap<Hoa, HoaVM>().ReverseMap();
            CreateMap<LoaiHoaVM, LoaiHoa>()
                .ForMember(des => des.Hoas, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<DonHang, DonHangVM>().ReverseMap();

        }
    }
}
