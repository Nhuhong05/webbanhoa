using webhoa.ViewModel;

namespace webhoa.Repository
{
    public interface ILoaiHoaRepository
    {
        public Task<List<LoaiHoaVM>> getAllLoaiHoasAsync();
        public Task<LoaiHoaVM> getLoaiHoaAsync(int MaLoai);
        public Task<int> AddLoaiHoaAsync(LoaiHoaVM model);
        public Task UpdateLoaiHoaAsync(int MaLoai, LoaiHoaVM model);
        public Task DeleteLoaiHoaAsync(int MaLoai);
    }
}
