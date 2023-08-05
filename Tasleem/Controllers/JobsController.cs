using AutoMapper;
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



        [HttpGet("AllJobs")]
        public IActionResult GetAllJobs() {
          List<JobDTO> jobs=  JobService.GetAllJobs();
            return Ok(jobs);
        }

        [HttpGet("GetJobById/{JobId}")]
        public IActionResult GetJobById(int JobId)
        {
            JobDTO jobDTO=JobService.GetJobByID(JobId);

            return Ok(jobDTO);
        }


        [HttpPost("AddJob")]
        public IActionResult AddJob(AddJobDTO jobDTO)
        {
            AddJobDTO job = JobService.AddJob(jobDTO);
            _unitOfWork.CommitChanges();

            ResultDTO result = new ResultDTO();
            result.Message = "Success";
            result.Data =job;
            result.IsPass = true;
            return Ok(result);
        }
        [HttpGet("GetJobsByClientId/{ClientId}")]
        public IActionResult GetJobsByClientId(string ClientId)
        {
            List<JobDTO> jobsDTO = JobService.GetJobsByClientId(ClientId);

            return Ok(jobsDTO);
        }

    }
}
