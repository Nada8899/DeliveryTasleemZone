using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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

    }
}
