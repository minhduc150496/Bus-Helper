using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IBeaconRepository : IGenericRepository<Beacon>
    {
        Beacon GetSingle(int id);
    }

    public class BeaconRepository : GenericRepository<Beacon>, IBeaconRepository
    {
        public Beacon GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
