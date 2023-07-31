using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;

namespace TasleemDelivery.DTO
{
    public class AddProposalDTO
    {
        public string CoverLetter { get; set; }
        public double ProposalPrice { get; set; }
        public DateTime ?ProposalDate { get; set; }
     
        public string DeliveryId { get; set; }

        public int JobID { get; set; }
    }
}
