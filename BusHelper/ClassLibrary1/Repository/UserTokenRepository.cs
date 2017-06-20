using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IUserTokenRepository : IGenericRepository<UserToken>
    {
        UserToken GetSingle(int id);
    }

    public class UserTokenRepository : GenericRepository<UserToken>, IUserTokenRepository
    {
        public UserToken GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
