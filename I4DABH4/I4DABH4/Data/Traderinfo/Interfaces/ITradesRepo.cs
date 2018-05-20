using I4DABH4.Models;

namespace I4DABH4.Data.Traderinfo
{
    public interface ITradesRepo : IGenericDocumentRepo<ProsumerTradeStats>
    {
        void Add(ProsumerTradeStat prosumerInfo);
    }
}