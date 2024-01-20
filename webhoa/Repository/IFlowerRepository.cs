using System.Diagnostics.Eventing.Reader;
using webhoa.Model;
using webhoa.ViewModel;

namespace webhoa.Repository
{
    public interface IFlowerRepository
    {
        public Task<List<HoaVM>> getAllHoasAsync();
        public Task<HoaVM> getHoaAsync(int MaSp);
        public Task<int> AddHoaAsync(HoaVM model);
        public Task UpdateHoaAsync(int MaSP, HoaVM model);
        public Task DeleteHoaAsync(int MaSP);


      


    }
}
