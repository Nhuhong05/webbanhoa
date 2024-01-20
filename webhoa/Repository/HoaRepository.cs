using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webhoa.Entities;
using webhoa.Model;

namespace webhoa.Repository
{
    public class HoaRepository : IFlowerRepository
    {
        private WebbanhoaContext _context;
        private IMapper _mapper;

        public HoaRepository(WebbanhoaContext context, IMapper mapper) {
            _context = context;
            _mapper =mapper;
        }

        public async Task<int> AddHoaAsync(HoaVM model)
        {
            var newhoa = _mapper.Map<Hoa>(model);
            _context.Hoas!.Add(newhoa);
            await _context.SaveChangesAsync();
            return newhoa.MaSp;
        }

        public async Task DeleteHoaAsync(int MaSP)
        {
            var deletehoa = _context.Hoas!.SingleOrDefault(b => b.MaSp == MaSP);
            if(deletehoa != null)
            {
                _context.Hoas.Remove(deletehoa);
                await _context.SaveChangesAsync();


            }
        }

        public async Task<List<HoaVM>> getAllHoasAsync()
        {
            var haos = await _context.Hoas!.ToListAsync();
            return _mapper.Map<List<HoaVM>>(haos);
        }

        public async Task<HoaVM> getHoaAsync(int MaSp)
        {
            var hao = await _context.Hoas!.FindAsync(MaSp);
            return _mapper.Map<HoaVM>(hao);
        }

        public async Task UpdateHoaAsync(int MaSP, HoaVM model)
        {
            if (MaSP == model.MaSp)
            {
                var updatehoa = _mapper.Map<Hoa>(model);
                _context.Hoas!.Update(updatehoa);
                await _context.SaveChangesAsync();
            }
        }

       
    }
}
