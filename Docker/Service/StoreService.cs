using DockerDemo.Data;
using DockerDemo.Docker.Interface;
using DockerDemo.Docker.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo.Docker.Service
{
    public class StoreService : IStoreService
    {

        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddStore(Store store)
        {
            _context.Stores.Add(store);
            await _context.SaveChangesAsync();
        }

        public Task DeleteStore(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Store>>> GetStores()
        {
            return await _context.Stores.ToListAsync();
        }

        public Task<ActionResult<IEnumerable<Store>>> GetStoreById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStore(Store store)
        {
            throw new NotImplementedException();
        }

    }
}
