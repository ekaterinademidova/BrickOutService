using BrickOutService.DataAccess.Data;
using BrickOutService.DataAccess.Repository.IRepository;
using BrickOutService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickOutService.DataAccess.Repository
{
    public class TypeOfDeviceRepository : Repository<TypeOfDevice>, ITypeOfDeviceRepository
    {
        private ApplicationDbContext _db;
        public TypeOfDeviceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(TypeOfDevice obj)
        {
            _db.TypesOfDevices.Update(obj);
        }
    }
}
