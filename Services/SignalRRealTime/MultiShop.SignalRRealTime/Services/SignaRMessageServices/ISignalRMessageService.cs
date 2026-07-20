namespace MultiShop.SignalRRealTime.Services.SignaRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
