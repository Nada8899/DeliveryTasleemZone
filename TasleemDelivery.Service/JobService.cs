using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        ProposalService _ProposalService;
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public JobService(IMapper mapper, IUnitOfWork unitOfWork
             , ProposalService ProposalService)
        {
            _ProposalService = ProposalService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<JobDTO> GetAllJobs()
        {

            IQueryable<Job> job = _unitOfWork.JobRepository.GetAll(); 
            List<JobDTO> jobsDTO = _mapper.ProjectTo<JobDTO>(job).ToList();

            foreach (JobDTO jobDTO in jobsDTO)
            {
                jobDTO.NumOfProposal = _ProposalService.GetAllProposalsByJobID(jobDTO.Id).Count();
            }

            return jobsDTO;
        }

        public List<JobDTO> GetAllJobsWaiting()
        {

            IQueryable<Job> job = _unitOfWork.JobRepository.GetByExpression(e => e.IsVerified == IsVerified.waiting); 
            List<JobDTO> jobsDTO = _mapper.ProjectTo<JobDTO>(job).ToList();

            foreach (JobDTO jobDTO in jobsDTO)
            {
                jobDTO.NumOfProposal = _ProposalService.GetAllProposalsByJobID(jobDTO.Id).Count();
            }

            return jobsDTO;
        }
        public List<JobDTO> GetAllJobsConfirmed()
        {

            IQueryable<Job> job = _unitOfWork.JobRepository.GetByExpression(e => e.IsVerified == IsVerified.verified); 
            List<JobDTO> jobsDTO = _mapper.ProjectTo<JobDTO>(job).ToList();

            foreach (JobDTO jobDTO in jobsDTO)
            {
                jobDTO.NumOfProposal = _ProposalService.GetAllProposalsByJobID(jobDTO.Id).Count();
            }

            return jobsDTO;
        }


        public JobDTO GetJobByID(int JobId)
        {

            JobDTO jobDTO = GetAllJobs().FirstOrDefault(job => job.Id == JobId);
            jobDTO.NumOfProposal = _ProposalService.GetAllProposalsByJobID(JobId).Count();

            return jobDTO;
        }


        public AddJobDTO AddJob(AddJobDTO jobDTO)
        {



            Job job = _mapper.Map<Job>(jobDTO);

            _unitOfWork.JobRepository.Add(job);
            _unitOfWork.SaveChanges();

            return jobDTO;
        }
        public List<JobDTO> GetJobsByClientId(string ClientId)
        {
            IQueryable<Job> job = _unitOfWork.JobRepository.GetByExpression(e => e.ClientId == ClientId);
            List<JobDTO> jobsDTO = _mapper.ProjectTo<JobDTO>(job).ToList();

            return jobsDTO;
        }
        public List<JobDTO> GetJobsByCountryName(string CountryName)
        {
            IQueryable<Job> job = _unitOfWork.JobRepository.GetByExpression(e => e.CountryName == CountryName && e.IsVerified == IsVerified.verified);
            List<JobDTO> jobsDTO = _mapper.ProjectTo<JobDTO>(job).ToList();
            if (CountryName == "كل الدول")
            {
                jobsDTO = GetAllJobsConfirmed();
                return jobsDTO;
            }

            return jobsDTO;
        }

        public List<JobDTO> GetJobsByCountryCityName(string CountryName, string CityName)
        {
            IQueryable<Job> job = _unitOfWork.JobRepository.GetByExpression(e => e.CountryName == CountryName && e.CityName == CityName && e.IsVerified == IsVerified.verified);
            List<JobDTO> jobsDTO = _mapper.ProjectTo<JobDTO>(job).ToList();

            if (CityName == "كل المدن")
            {
                jobsDTO = GetJobsByCountryName(CountryName);
                return jobsDTO;
            }

            return jobsDTO;
        }
        public string ConfirmJobByClientID(string ClientID, int jobID)
        {
            Job job = _unitOfWork.JobRepository.GetByExpression(j => j.Id == jobID && j.ClientId == ClientID).FirstOrDefault();
            job.IsVerified = IsVerified.verified;

            _unitOfWork.JobRepository.Update(job);
            _unitOfWork.SaveChanges();

            return "Confirmed";
        }
        public string RejectJobByClientID(string ClientID, int jobID)
        {
            Job job = _unitOfWork.JobRepository.GetByExpression(j => j.Id == jobID && j.ClientId == ClientID).FirstOrDefault();
            job.IsVerified = IsVerified.denied;

            _unitOfWork.JobRepository.Update(job);
            _unitOfWork.SaveChanges();

            return "Rejected";
        }

    }
}