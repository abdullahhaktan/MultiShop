namespace MultiShop.WebUi.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<long> GetCategoryCountAsync();
        Task<long> GetProductCountAsync();
        Task<long> GetBrandCountAsync();
        Task<decimal> GetProductAvgPriceAsync();
        Task<string> GetMinPriceProductNameAsync();
        Task<string> GetMaxPriceProductNameAsync();
    }
}
