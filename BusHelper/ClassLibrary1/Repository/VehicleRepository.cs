using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        Vehicle GetSingle(int id);
    }

    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public Vehicle GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
