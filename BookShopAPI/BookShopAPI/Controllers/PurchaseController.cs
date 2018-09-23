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
        private ILoggerManager _logger;

        public PurchaseController(IRepositoryWrapper repoWrapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }

        [Route("[action]/{UserId}")]
        [HttpGet]
        public ActionResult<IList<History>> PurchaseHistory(string UserId)
        {

            var purchaseItems = _repoWrapper.PurchaseService.PurchaseHistory(UserId);
            if (purchaseItems == null)
            {
                _logger.LogInfo("api/Purchase/" + UserId + ". Not found");
                return NotFound("Not found");
            }
            _logger.LogInfo("api/Purchase/" + UserId + ". User found");
            return Ok(purchaseItems);
        }

        [Route("[action]/{UserId}")]
        [HttpPost("{Userid}")]
        public ActionResult<int> PurchaseBooks(string UserId, [FromBody] IList<PurchaseItems> purchaseItems)
        {
            int purchaseId = _repoWrapper.PurchaseService.PurchaseBook(UserId, purchaseItems);
           
            _logger.LogInfo("api/Purchase/" + UserId + ", purchaseId: " + purchaseId.ToString());
            return Ok(purchaseId);
        }
    }
}