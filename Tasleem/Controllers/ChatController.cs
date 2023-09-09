using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TasleemDelivery.DTO;
using TasleemDelivery.Hubs;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ChatController(IHubContext<ChatHub> hubContext, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _hubContext = hubContext;
            _unitOfWork = unitOfWork;
            _mapper= mapper;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessageFromClient([FromBody] ChatMessageClientDTO message)
        {
            // Process the message (e.g., store it in a database)
            ClientChat chat=_mapper.Map<ClientChat>(message);

            _unitOfWork.ChatRepository.Add(chat);
            _unitOfWork.CommitChanges();


            // Send the message to clients using SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.ClientId, message.ClientMsg);

            return Ok("Done");
        }

    }
}
