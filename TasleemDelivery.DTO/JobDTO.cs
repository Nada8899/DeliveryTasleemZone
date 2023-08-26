using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;

namespace TasleemDelivery.DTO
{
    public class JobDTO
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Budget { get; set; }
        public string Details { get; set; }
        public int RequiredPoints { get; set; }
        public string AddressDetails { get; set; }
        public int NumOfProposal { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public  Client Client { get; set; }
        public DateTime? AcceptedDate { get; set; }
        


    }
}
