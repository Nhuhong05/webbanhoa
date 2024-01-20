using AutoMapper;
using Microsoft.EntityFrameworkCore;
using webhoa.Entities;
using webhoa.Model;
using webhoa.ViewModel;

namespace webhoa.Repository
{
    public class DonHangRepository : IdonhangRepositorycs
    {

        private WebbanhoaContext _context;
        private IMapper _mapper;

        public DonHangRepository(WebbanhoaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      

        public async Task<int> AddDHAsync(DonHangVM model)
        {
            var newdh = _mapper.Map<DonHang>(model);
            _context.DonHangs!.Add(newdh);
            await _context.SaveChangesAsync();
            return newdh.MaDh;
        }

        public async Task DeleteDHAsync(int MaDh)
        {
            var delete = _context.DonHangs!.SingleOrDefault(b => b.MaDh == MaDh);
            if (delete != null)
            {
                _context.DonHangs.Remove(delete);
                await _context.SaveChangesAsync();


            }
        }

        public async Task<List<DonHangVM>> getAllDHAsync()
        {
            var dh = await _context.DonHangs!.ToListAsync();
            return _mapper.Map<List<DonHangVM>>(dh);
        }

        public async Task<DonHangVM> getDHAsync(int MaDh)
        {
            var dh = await _context.DonHangs!.FindAsync(MaDh);
            return _mapper.Map<DonHangVM>(dh);
        }

     

        public async Task UpdateDHAsync(int MaDh, DonHangVM model)
        {
            if (MaDh == model.MaDh)
            {
                var update = _mapper.Map<DonHang>(model);
                _context.DonHangs!.Update(update);
                await _context.SaveChangesAsync();
            }

        }

      
    }
}
