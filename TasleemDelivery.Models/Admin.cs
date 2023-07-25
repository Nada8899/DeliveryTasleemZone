using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TasleemDelivery.Models.InterFaces;

namespace TasleemDelivery.Models
{
    public class Admin:IBaseModel<string>
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string ?FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string ?Address { get; set; }
        public byte[] ?ProfileImg { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
