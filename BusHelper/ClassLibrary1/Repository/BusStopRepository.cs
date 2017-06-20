using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IBusStopRepository : IGenericRepository<BusStop>
    {
        BusStop GetSingle(int id);
    }

    public class BusStopRepository : GenericRepository<BusStop>, IBusStopRepository
    {
        public BusStop GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
