using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webhoa.Entities;
using webhoa.ViewModel;

namespace webhoa.Repository
{
    public class LoaiHoaRepsitory : ILoaiHoaRepository
    {
        private WebbanhoaContext _context;
        private IMapper _mapper;

        public LoaiHoaRepsitory(WebbanhoaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddLoaiHoaAsync(LoaiHoaVM model)
        {
            var newhoa = _mapper.Map<LoaiHoa>(model);
            _context.LoaiHoas!.Add(newhoa);
            await _context.SaveChangesAsync();
            return newhoa.MaLoai;
        }

        public async Task DeleteLoaiHoaAsync(int MaLoai)
        {
            var deletehoa = _context.LoaiHoas!.SingleOrDefault(b => b.MaLoai == MaLoai);
            if (deletehoa != null)
            {
                _context.LoaiHoas.Remove(deletehoa);
                await _context.SaveChangesAsync();


            }
        }

        public async Task<List<LoaiHoaVM>> getAllLoaiHoasAsync()
        {
            var haos = await _context.LoaiHoas!.ToListAsync();
            //return haos;
            return _mapper.Map<List<LoaiHoaVM>>(haos);
        }

        public async Task<LoaiHoaVM> getLoaiHoaAsync(int MaLoai)
        {
            var loaihoa = await _context.LoaiHoas!.FindAsync(MaLoai);
            return _mapper.Map<LoaiHoaVM>(loaihoa);
        }

        public async Task UpdateLoaiHoaAsync(int MaLoai, LoaiHoaVM model)
        {
            if (MaLoai == model.MaLoai)
            {
                var updatehoa = _mapper.Map<LoaiHoa>(model);
                _context.LoaiHoas!.Update(updatehoa);
                await _context.SaveChangesAsync();
            }
        }


    }
}
