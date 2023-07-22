using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Admin:IBaseModel<string>
    {
        [Key]
        [ForeignKey("ApplicationUser")]

        public string Id { get; set; }

        public string FullName { get; set; }
        public string Address { get; set; }
        public byte[] ProfileImg { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
