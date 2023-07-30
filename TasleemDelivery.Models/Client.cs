using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models.InterFaces;
using System.ComponentModel;


namespace TasleemDelivery.Models
{
    public class Client :IBaseModel<string>
    {

        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string? FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string? Address { get; set; }
        public byte[]? ProfileImg { get; set; }
       // public double Balance { get; set; }
        public string? OverView { get; set; }
        public virtual IEnumerable<Language>? Languges { get; set; }

        public virtual IEnumerable<Job>? Jobs { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
