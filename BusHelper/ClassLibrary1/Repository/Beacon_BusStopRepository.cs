using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IBeacon_BusStopRepository : IGenericRepository<Beacon_BusStop>
    {
        Beacon_BusStop GetSingle(int id);
    }

    public class Beacon_BusStopRepository : GenericRepository<Beacon_BusStop>, IBeacon_BusStopRepository
    {
        public Beacon_BusStop GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
