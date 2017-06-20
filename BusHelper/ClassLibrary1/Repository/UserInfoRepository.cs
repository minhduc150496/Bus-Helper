using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository;

namespace BusHelperDAL.Repository
{
    public interface IUserInfoRepository : IGenericRepository<UserInfo>
    {
        UserInfo GetSingle(int id);
    }

    public class UserInfoRepository : GenericRepository<UserInfo>, IUserInfoRepository
    {
        public UserInfo GetSingle(int id)
        {
            var result = GetAll().FirstOrDefault(x => x.id == id);
            return result;
        }
    }
}
