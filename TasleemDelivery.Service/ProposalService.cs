﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.UnitOfWork;

namespace TasleemDelivery.Service
{
    public class ProposalService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public ProposalService(IUnitOfWork unitOfWork, IMapper mapper)
        {
           _mapper= mapper;
           _unitOfWork= unitOfWork;
        }

        public string AddProposal(AddProposalDTO addProposalDTO)
        {
            Job job=_unitOfWork.JobRepository.GetByID(addProposalDTO.JobID);
            Delivery delivery =_unitOfWork.DeliveryRepository.GetByID(addProposalDTO.DeliveryId);
            if (addProposalDTO != null && delivery.Points >= job.RequiredPoints && GetAllProposalsByJobID(job.Id).Count<10)
            {

                Proposal proposal = _mapper.Map<Proposal>(addProposalDTO);
                proposal.ProposalDate=DateTime.Now;

                    _unitOfWork.ProposalRepository.Add(proposal);
                    _unitOfWork.SaveChanges();

                return "تم التقديم بنجاح";
            }
           

            return "عدد التقديمات أكبر من 10 أو عدد النقاط المطلوبة للتوصيل أكبر من عدد النقاط المتبقية لك";
        }

        public List< AddProposalDTO> GetAllProposalsByJobID(int jobID)
        {
           
              IQueryable<Proposal> props = _unitOfWork.ProposalRepository.GetByExpression(prop =>prop.JobID == jobID);

               List<AddProposalDTO> proposals = _mapper.ProjectTo<AddProposalDTO>(props).ToList();
                       


            return proposals;
        }
    }
}
