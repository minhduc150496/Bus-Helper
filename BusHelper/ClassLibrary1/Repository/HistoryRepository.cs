using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IHistoryRepository : IGenericRepository<History>
    {
        History GetSingle(int id);
    }

    public class HistoryRepository : GenericRepository<History>, IHistoryRepository
    {
        public History GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
