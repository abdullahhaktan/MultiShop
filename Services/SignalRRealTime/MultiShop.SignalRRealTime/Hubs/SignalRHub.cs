using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTime.Services.SignalRCommentServices;
using MultiShop.SignalRRealTime.Services.SignaRMessageServices;

namespace MultiShop.SignalRRealTime.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;

        public SignalRHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }

        //public async Task SendStatisticCount

    }
}