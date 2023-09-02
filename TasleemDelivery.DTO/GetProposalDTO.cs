using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;

namespace TasleemDelivery.DTO
{
    public class GetProposalDTO
    {
        public DateTime ProposalDate { get; set; }

        public string DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }

        public int JobID { get; set; }
        public virtual Job Job { get; set; }
    }
}
