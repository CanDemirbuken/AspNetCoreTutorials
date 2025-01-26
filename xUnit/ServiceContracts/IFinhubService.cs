namespace ServiceContracts
{
    public interface IFinhubService
    {
        Dictionary<string, object> GetCompanyProfile(string stockSymbol);
        Dictionary<string, object> GetStockPriceQuote(string stockSymbol);
    }
}
