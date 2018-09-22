using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contracts
{
    public interface IUsersRepository : IRepositoryBase<Users>
    {
        void UnRegisterUser(String id);
    }
}
