using BrickOutService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrickOutService.DataAccess.Repository.IRepository
{
    public interface ITypeOfDeviceRepository : IRepository<TypeOfDevice>
    {
        void Update(TypeOfDevice obj);
    }
}
