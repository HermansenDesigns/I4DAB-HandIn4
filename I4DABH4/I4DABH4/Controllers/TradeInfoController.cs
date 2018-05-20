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
        // GET: api/GetAllForProsumer
        [HttpGet("GetAll/{ProsumerId}")]
        public IEnumerable<ProsumerTradeStat> Get(long ProsumerId)
        {
            return _tradesRepo.GetAllById(ProsumerId);
        }

        // GET: api/TradeInfo/yy
        [HttpGet("{yy}")]
        public IEnumerable<ProsumerTradeStat> Get(string yy)
        {
            return _tradesRepo.GetByDate(yy);
        }
        // GET: api/TradeInfo/yy/MM
        [HttpGet("{yy}/{MM}")]
        public IEnumerable<ProsumerTradeStat> Get(string yy, string MM)
        {
            return _tradesRepo.GetByDate(yy+MM);
        }
        // GET: api/TradeInfo/yy/MM/dd
        [HttpGet("{yy}/{MM}/{dd}")]
        public IEnumerable<ProsumerTradeStat> Get(string yy, string MM, string dd)
        {
            return _tradesRepo.GetByDate(yy + MM + dd);
        }
        // GET: api/TradeInfo/yy/MM/dd/HH
        [HttpGet("{yy}/{MM}/{dd}/{HH}")]
        public IEnumerable<ProsumerTradeStat> Get(string yy, string MM, string dd, string HH)
        {
            return _tradesRepo.GetByDate(yy + MM + dd + HH);
        }
        // POST: api/TradeInfo
        [HttpPost]
        public void Post([FromBody]ProsumerTradeStat model)
        {
            _tradesRepo.Add(model);
        }
  
    }
}
