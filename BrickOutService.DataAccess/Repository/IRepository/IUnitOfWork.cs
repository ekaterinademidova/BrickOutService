namespace BrickOutService.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITypeOfDeviceRepository TypeOfDevice { get; }
        IBrandRepository Brand { get; }
        void Save();
    }
}
