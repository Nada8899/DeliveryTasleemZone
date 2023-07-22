using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Client :IBaseModel<string>
    {

        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public byte[] ProfileImg { get; set; }
       // public double Balance { get; set; }
        public string OverView { get; set; }
        public virtual IEnumerable<Languge> Languges { get; set; }

        public virtual IEnumerable<Job> Jobs { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public bool IsDeleted { get; set; }

    }
}
