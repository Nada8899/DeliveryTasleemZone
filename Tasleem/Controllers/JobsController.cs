﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        JobService JobService;
        IUnitOfWork _unitOfWork;

        public JobsController(JobService jobService, IUnitOfWork _unitOfWork)
        {

            this.JobService = jobService;
            this._unitOfWork = _unitOfWork;
        }



        [HttpGet("GetAllJobsWaiting")]
        public IActionResult GetAllJobsWaiting()
        {
            List<JobDTO> jobs = JobService.GetAllJobsWaiting();
            return Ok(jobs);
        }

        [HttpGet("GetAllJobsConfirmed")]
        public IActionResult GetAllJobsConfirmed()
        {
            List<JobDTO> jobs = JobService.GetAllJobsConfirmed();
            return Ok(jobs);
        }


        [HttpGet("GetJobById/{JobId}")]
        public IActionResult GetJobById(int JobId)
        {
            JobDTO jobDTO = JobService.GetJobByID(JobId);

            return Ok(jobDTO);
        }


        [HttpPost("AddJob")]
        public IActionResult AddJob(AddJobDTO jobDTO)
        {
            AddJobDTO job = JobService.AddJob(jobDTO);
            _unitOfWork.CommitChanges();

            ResultDTO result = new ResultDTO();
            result.Message = "Success";
            result.Data = job;
            result.IsPass = true;
            return Ok(result);
        }
        [HttpGet("GetJobsByClientId/{ClientId}")]
        public IActionResult GetJobsByClientId(string ClientId)
        {
            List<JobDTO> jobsDTO = JobService.GetJobsByClientId(ClientId);

            return Ok(jobsDTO);
        }
        [HttpGet("GetJobsByCountryName/{CountryName}")]
        public IActionResult GetJobsByCountryName(string CountryName)
        {
            List<JobDTO> jobsDTO = JobService.GetJobsByCountryName(CountryName);

            return Ok(jobsDTO);
        }
        [HttpGet("GetJobsByCountryName/{CountryName}/{CityName}")]
        public IActionResult GetJobsByCountryName(string CountryName, string CityName)
        {
            List<JobDTO> jobsDTO = JobService.GetJobsByCountryCityName(CountryName, CityName);

            return Ok(jobsDTO);
        }

        [HttpPut("ConfirmJob/{ClientID}/{JobID}")]
        public IActionResult ConfirmJob(string ClientID, int JobID)
        {
            string result = JobService.ConfirmJobByClientID(ClientID, JobID);
            _unitOfWork.CommitChanges();

            return Ok(new { msg=result});

        }
        [HttpPut("RejectJob/{ClientID}/{JobID}")]
        public IActionResult RejectJob(string ClientID, int JobID)
        {
            string result = JobService.RejectJobByClientID(ClientID, JobID);
            _unitOfWork.CommitChanges();

            return Ok(new { msg = result });

        }


    }
}