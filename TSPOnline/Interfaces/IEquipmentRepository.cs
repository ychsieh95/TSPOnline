using System.Collections.Generic;
using System.Threading.Tasks;
using TSPOnline.Models;

namespace TSPOnline.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> SelectEquipmentsAsync();
    }
}
