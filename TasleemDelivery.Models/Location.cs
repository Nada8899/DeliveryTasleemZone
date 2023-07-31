using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Location :IBaseModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public virtual IEnumerable<Job> Jobs { get; set; }
    }
}
