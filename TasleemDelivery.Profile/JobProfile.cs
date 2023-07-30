using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;

namespace TasleemDelivery.Profiles
{
    public class JobProfile :Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDTO>();
            CreateMap<AddJobDTO, Job>();

        }

    }
}
