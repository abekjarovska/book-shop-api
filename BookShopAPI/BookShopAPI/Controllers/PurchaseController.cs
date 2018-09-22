using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public PurchaseController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [Route("[action]/{UserID}")]
        [HttpGet]
        public ActionResult<IList<History>> PurchaseHistory(string Userid)
        {

            var purchaseItems = _repoWrapper.PurchaseService.PurchaseHistory(Userid);
            if (purchaseItems == null) return NotFound("Not found");
            return Ok(purchaseItems);
        }

        [Route("[action]/{Userid}")]
        [HttpPost("{Userid}")]
        public ActionResult<int> PurchaseBooks(string Userid, [FromBody] IList<PurchaseItems> purchaseItems)
        {
            int purchaseId = _repoWrapper.PurchaseService.PurchaseBook(Userid, purchaseItems);
            return Ok(purchaseId);
        }
    }
}