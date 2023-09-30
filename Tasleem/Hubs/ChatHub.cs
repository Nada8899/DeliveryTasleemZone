using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;
using TasleemDelivery.Data;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;

namespace TasleemDelivery.Hubs
{
    [HubName("chat")]
    public sealed class ChatHub:Hub
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChatHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }
        public async Task ClientSendMessage(SendClientDeliveryMsgDTO sendClientMsgDTO)
        {
            await base.OnConnectedAsync();

            //save on database

            ClientChat clientChat = new ClientChat()
            {
                ClientMsg= sendClientMsgDTO.Msg,
                ClientMsgTime=DateTime.Now,
                ClientId=sendClientMsgDTO.ClientId,
                DeliveryId=sendClientMsgDTO.DeliveryId,
            };
            _unitOfWork.ClientChatRepository.Add(clientChat);
            _unitOfWork.CommitChanges();

            //Prodcast

            await Clients.All.SendAsync("DeliveryReceiveMessage", sendClientMsgDTO.Msg);
        }

        public async Task DeliverySendMessage(SendClientDeliveryMsgDTO sendDeliveryMsgDTO)
        {

            await base.OnConnectedAsync();

            //save on database

            DeliveryChat deliveryChat = new DeliveryChat()
            {
                DeliveryMsg = sendDeliveryMsgDTO.Msg,
                DeliveryMsgTime = DateTime.Now,
                ClientId = sendDeliveryMsgDTO.ClientId,
                DeliveryId = sendDeliveryMsgDTO.DeliveryId,
            };
             _unitOfWork.DeliveryChatRepository.Add(deliveryChat);

            _unitOfWork.CommitChanges();

            //Prodcast
            await Clients.All.SendAsync("ClientReceiveMessage", sendDeliveryMsgDTO.Msg);

         
        }
    }
}
