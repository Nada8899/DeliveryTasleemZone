using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class SavedJob :IBaseModel<int>
    {
        public int Id { get; set; }


        [ForeignKey("Delivery")]
        public string DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }

        public bool IsDeleted { get; set; }


    }
}
