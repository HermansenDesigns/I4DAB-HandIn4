using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I4DABH4.Data.Traderinfo;
using I4DABH4.Dto;
using I4DABH4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace I4DABH4.Controllers
{
    [Produces("application/json")]
    [Route("api/TradeInfo")]
    public class TradeInfoController : Controller
    {
        private readonly TradesRepo _tradesRepo;
        public TradeInfoController(IUnitOfWork tradingrepo)
        {
            _tradesRepo = tradingrepo.TradesRepo;
        }

        // GET: api/TradeInfo
        [HttpGet]
        public IEnumerable<NetBalanceDto> Get()
        {
            return _tradesRepo.GetAll().Select(item =>
            {
                var dto = new NetBalanceDto();
                dto.NetBalance = item.NetBalance;
                dto.TimeStamp = ProsumerTradeStats.IdToDate(item.Id);
                return dto;
            });
        }

        // GET: api/TradeInfo/5
        [HttpGet("{time}", Name = "Get")]
        public IEnumerable<ProsumerTradeStat> Get(DateTime time)
        {
            return _tradesRepo.Get(ProsumerTradeStats.DateToId(time))?.TradeStats;
        }
        
        // POST: api/TradeInfo
        [HttpPost]
        public void Post([FromBody]ProsumerTradeStat model)
        {
            _tradesRepo.Add(model);
        }
        
        // PUT: api/TradeInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
