using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] ?ProfileImg { get; set; }

        public virtual IEnumerable<Language> ?Languges { get; set; }

        public virtual IEnumerable<ComplaintsِnAndSuggestions > Complaints { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
