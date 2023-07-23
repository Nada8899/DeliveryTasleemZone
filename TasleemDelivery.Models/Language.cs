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
    public class Language :IBaseModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }


        [ForeignKey("ApplicationUser")]
        public string ApplicationUserID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
