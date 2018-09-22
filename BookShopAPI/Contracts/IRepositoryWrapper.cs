using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUsersRepository Users { get; }
        IBooksRepository Books { get; }
        IPurchaseServiceRepository PurchaseService { get; }
    }
}
