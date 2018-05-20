using System.Collections.Generic;
using I4DABH4.Models;

namespace I4DABH4.Data.Traderinfo
{
    public interface ITradesRepo : IGenericDocumentRepo<ProsumerTradeStats>
    {
        void Add(ProsumerTradeStat prosumerInfo);
        IEnumerable<ProsumerTradeStat> GetAllById(long prosumerId);
        IEnumerable<ProsumerTradeStat> GetByDate(string datetime);
    }
}