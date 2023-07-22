using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Review :IBaseModel<int>
    {
        public int Id { get; set; }

        public string Comment { get; set; }
        public int Rate { get; set; }
        public DateTime ReviewDate { get; set; }


        [ForeignKey("Job")]
        public int JobId { get; set; }
        public virtual Job Job { get; set; }



        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        public bool IsDeleted { get; set; }

    }
}
