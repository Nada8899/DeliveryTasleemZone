using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;

namespace TasleemDelivery.Service
{
  
    public class JobService
    {
         IUnitOfWork _unitOfWork;
         IMapper _mapper;

        public JobService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<JobDTO> GetAllJobs()
        {
           

            IQueryable<Job> job = _unitOfWork.JobRepository.GetByExpression(e=>e.IsVerified==true);

            List<JobDTO> jobDTO = _mapper.ProjectTo<JobDTO>(job).ToList();

            return jobDTO;
        }

        public JobDTO GetJobByID(int JobId)
        {
            Job job=_unitOfWork.JobRepository.GetByID(JobId);
            JobDTO jobDTO = _mapper.Map<JobDTO>(job);

            return jobDTO;
        }


        public AddJobDTO AddJob(AddJobDTO jobDTO) {



            Job job = _mapper.Map<Job>(jobDTO);

            _unitOfWork.JobRepository.Add(job);
            _unitOfWork.SaveChanges();

            return jobDTO;
        }
    }
}
