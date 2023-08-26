using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.DTO
{
    public class GetClientProfileDataDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string? PhoneNum { get; set; }

        public byte[] ProfileImg { get; set; }
        public string OverView { get; set; }
        public virtual IEnumerable<string> Languges { get; set; }

    }
}
