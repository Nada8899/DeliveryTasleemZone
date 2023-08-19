using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.DTO
{
    public class AddJobDTO
    {
        public string Title { get; set; }
        public double Budget { get; set; }
        public string Details { get; set; }
        public string AddressDetails { get; set; }

        public int RequiredPoints { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string ClientId { get; set; }
    }
}
