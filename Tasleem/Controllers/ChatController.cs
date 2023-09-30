using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TasleemDelivery.DTO;
using TasleemDelivery.Hubs;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        IUnitOfWork _unitOfWork;
        ChatService _ChatService;
        public ChatController(IHubContext<ChatHub> hubContext, IUnitOfWork unitOfWork, ChatService ChatService)
        {
            _hubContext = hubContext;
            _unitOfWork = unitOfWork;
            _ChatService = ChatService;

        }

        [HttpPost("SendMessageFromClient")]
        public async Task<IActionResult> SendMessageFromClient([FromBody] ChatMessageClientDTO message)
        {


            ChatMessageClientDTO chat = _ChatService.AddClientMsg(message);
            _unitOfWork.CommitChanges();

            // Send the message to clients using SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.ClientId, message.ClientMsg);
            ResultDTO result = new ResultDTO();
            result.Message = "Success";
            result.Data = chat;
            result.IsPass = true;
            return Ok(result);
        }
        [HttpGet("GetAllDeliveriesChatWithSpecificClient")]
        public IActionResult GetAllDeliveriesChatWithSpecificClient(string ClientId)
        {

            List<DeliveryChat> deliveryChats = _unitOfWork.DeliveryChatRepository
                .GetByExpression(del => del.ClientId == ClientId)
                .Include(d=>d.Delivery)
                .GroupBy(del => del.DeliveryId)
                .Select(group => group.OrderByDescending(delMsgTime => delMsgTime.DeliveryMsgTime).FirstOrDefault())
                .ToList();

            foreach(var item in deliveryChats)
            {
                ClientChat clientChat = _unitOfWork.ClientChatRepository
                .GetByExpression(del => del.DeliveryId == item.DeliveryId && del.ClientId ==ClientId)
                .Include(d => d.Delivery)
                .OrderByDescending(cliMsgTime => cliMsgTime.ClientMsgTime)
                .FirstOrDefault();
                                

                if ( clientChat.ClientMsgTime > item.DeliveryMsgTime)
                {
                    item.DeliveryMsg = clientChat.ClientMsg;
                    item.DeliveryMsgTime= clientChat.ClientMsgTime;
                }
            }

            ResultDTO result = new ResultDTO();
            result.Message = "Success";
            result.Data = deliveryChats;
            result.IsPass = true;
            return Ok(result);
        }

    }
}
