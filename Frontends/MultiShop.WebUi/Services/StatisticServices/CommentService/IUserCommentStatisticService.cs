namespace MultiShop.WebUi.Services.StatisticServices.CommentService
{
    public interface IUserCommentStatisticService
    {
        Task<int> GetTotalCommentCountAsync();
        Task<int> GetActiveCommentCountASync();
        Task<int> GetPassiveCommentCountAsync();
    }
}
