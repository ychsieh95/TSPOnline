using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> SelectEquipmentsAsync();
    }
}
