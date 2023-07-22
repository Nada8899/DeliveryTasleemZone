using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasleemDelivery.Models.InterFaces
{
    public interface IBaseModel<T> 
    {
        public T Id { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
