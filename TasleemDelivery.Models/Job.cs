using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Job:IBaseModel<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Budget { get; set; }
        public string Details { get; set; }
        public string AddressDetails { get; set; }

        public int RequiredPoints { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        [ForeignKey("Delivery")]
        public string? DeliveryId { get; set; }
        public virtual Delivery? Delivery { get; set; }

        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual IEnumerable<SavedJob>? SavedJobs { get; set; }

        public virtual IEnumerable<Review>? Reviews { get; set; }

        [DefaultValue(false)]
        public bool IsVerified { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
