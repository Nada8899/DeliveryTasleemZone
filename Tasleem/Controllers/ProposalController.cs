using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TasleemDelivery.DTO;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        ProposalService _proposalService;
        IUnitOfWork _unitOfWork;
        public ProposalController(ProposalService proposalService, IUnitOfWork unitOfWork)
        {
            _proposalService = proposalService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("AddProposal")]
        public IActionResult AddProposal(AddProposalDTO addProposalDTO)
        {
            ResultDTO result = new ResultDTO();
            if (ModelState.IsValid)
            {
                string proposalResult = _proposalService.AddProposal(addProposalDTO);
                _unitOfWork.CommitChanges();

                result.Data = addProposalDTO;
                if (proposalResult == "عدد التقديمات أكبر من 10 أو عدد النقاط المطلوبة للتوصيل أكبر من عدد النقاط المتبقية لك")
                {
                    result.Message = proposalResult;
                    result.IsPass = false;
                }
                else
                {
                    result.Message = "Success";
                    result.IsPass = true;
                }

                return Ok(result);

            }
            result.Data = ModelState;
            result.Message = "Failed";
            result.IsPass = false;

            return BadRequest(result);
        }

        [HttpGet("GetAllProposalsByJobID/{jobID}")]
        public IActionResult GetAllProposalsByJobID(int jobID)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
                List<AddProposalDTO> AllProposals = _proposalService.GetAllProposalsByJobID(jobID);

                result.Message = "Success";
                result.IsPass = true;
                result.Data = AllProposals;

                return Ok(result);

            }
            else
            {
                result.Data = ModelState;
                result.Message = "Failed";
                result.IsPass = false;

                return BadRequest(result);
            }

        }


        [HttpPost("checkDeliveryAvilableinJobPost")]
        public IActionResult checkDeliveryAvilableinJobPost(checkDeliveryAvilableinJobPostDTO dTO)
        {
            ResultDTO result = new ResultDTO();

            if (ModelState.IsValid)
            {
               Boolean isFound = _proposalService.checkDeliveryAvilableinJobPost(dTO);

                result.Message = "Success";
                result.IsPass = true;
                result.Data = isFound;

                return Ok(result);

            }
            else
            {
                result.Data = ModelState;
                result.Message = "Failed";
                result.IsPass = false;

                return BadRequest(result);
            }

        }

    }
}
