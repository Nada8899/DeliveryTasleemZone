using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasleemDelivery.DTO;
using TasleemDelivery.Repository.UnitOfWork;
using TasleemDelivery.Service;

namespace TasleemDelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsAndSuggestionsController : ControllerBase
    {
        ComplaintsAndSuggestionsService ComplaintsAndSuggestionsService;
        IUnitOfWork _unitOfWork;

        public ComplaintsAndSuggestionsController
        (ComplaintsAndSuggestionsService ComplaintsAndSuggestionsService, IUnitOfWork _unitOfWork)
        {

            this.ComplaintsAndSuggestionsService = ComplaintsAndSuggestionsService;
            this._unitOfWork = _unitOfWork;
        }


        [HttpPost("AddComplaintsAndSuggestions")]
        public IActionResult AddComplaintsAndSuggestions(ComplaintsAndSuggestionsDTO DTO)
        {
            ComplaintsAndSuggestionsDTO ComplaintsAndSuggestions = ComplaintsAndSuggestionsService.Add(DTO);
            _unitOfWork.CommitChanges();

            ResultDTO result = new ResultDTO();
            result.Message = "Success";
            result.Data = ComplaintsAndSuggestions;
            result.IsPass = true;
            return Ok(result);


        }

            [HttpGet("AddComplaintsAndSuggestions")]
            public IActionResult GetComplaintsAndSuggestions()
            {
               List< ComplaintsAndSuggestionsDTO>ComplaintsAndSuggestions = ComplaintsAndSuggestionsService.Get();
                _unitOfWork.CommitChanges();

                ResultDTO result = new ResultDTO();
                result.Message = "Success";
                result.Data = ComplaintsAndSuggestions;
                result.IsPass = true;
                return Ok(result);
            }

        }
    }
