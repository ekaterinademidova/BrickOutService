using BrickOutService.DataAccess.Data;
using BrickOutService.DataAccess.Repository.IRepository;

namespace BrickOutService.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ITypeOfDeviceRepository TypeOfDevice { get; private set; }
        public IBrandRepository Brand { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            TypeOfDevice = new TypeOfDeviceRepository(_db);
            Brand = new BrandRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
