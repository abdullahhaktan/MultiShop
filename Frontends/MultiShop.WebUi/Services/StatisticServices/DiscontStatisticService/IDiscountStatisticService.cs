namespace MultiShop.WebUi.Services.StatisticServices.DiscontStatisticService
{
    public interface IDiscountStatisticService
    {
        Task<int> GetDiscountCouponCountAsync();
    }
}