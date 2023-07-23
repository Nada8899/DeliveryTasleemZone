using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Proposal:IBaseModel<int>
    {
        public int Id { get; set; }

        public string CoverLetter { get; set; }
        public double ProposalPrice { get; set; }
        public DateTime ProposalDate { get; set; }
        [ForeignKey("Delivery")]
        public string DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }


        [DefaultValue(false)]
        public bool IsHire{ get; set; }
        public  DateTime? HireDate { get; set; }
        [ForeignKey("Job")]
        public int JobID { get; set; }
        public virtual Job Job { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
