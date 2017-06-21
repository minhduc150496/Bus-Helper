using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IBusInfo_BusStopRepository : IGenericRepository<BusInfo_BusStop>
    {
        BusInfo_BusStop GetSingle(int id);
    }

    public class BusInfo_BusStopRepository : GenericRepository<BusInfo_BusStop>, IBusInfo_BusStopRepository
    {
        public BusInfo_BusStop GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
