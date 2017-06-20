using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IBusInfoRepository : IGenericRepository<BusInfo>
    {
        BusInfo GetSingle(int id);
    }

    public class BusInfoRepository : GenericRepository<BusInfo>, IBusInfoRepository
    {
        public BusInfo GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
