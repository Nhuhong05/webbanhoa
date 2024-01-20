using webhoa.Model;
using webhoa.ViewModel;

namespace webhoa.Repository
{
    public interface IdonhangRepositorycs
    {
        public Task<List<DonHangVM>> getAllDHAsync();
        public Task<DonHangVM> getDHAsync(int MaDh);
        public Task<int> AddDHAsync(DonHangVM model);
        public Task UpdateDHAsync(int MaDh, DonHangVM model);
        public Task DeleteDHAsync(int MaDh);
    }
}
