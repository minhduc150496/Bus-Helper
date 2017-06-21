using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IBusInfo_VehicleRepository : IGenericRepository<BusInfo_Vehicle>
    {
        BusInfo_Vehicle GetSingle(int id);
    }

    public class BusInfo_VehicleRepository : GenericRepository<BusInfo_Vehicle>, IBusInfo_VehicleRepository
    {
        public BusInfo_Vehicle GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
