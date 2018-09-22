using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPurchaseServiceRepository
    {
        IList<History> PurchaseHistory(string UserId);
        int PurchaseBook(string UserId, IList<PurchaseItems> purchaseItems);
    }
}
