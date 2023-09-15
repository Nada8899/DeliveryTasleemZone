﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.Interfaces;

namespace TasleemDelivery.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        void CommitChanges();
        void BeginTransaction();
        IGenericRepository<Client,string> ClientRepository { get; }
        IGenericRepository<Delivery, string> DeliveryRepository { get; }
        IGenericRepository<Admin, string> AdminRepository { get; }
        IGenericRepository<SubAdmin, string> SubAdminRepository { get; }
        IGenericRepository<ClientChat, int> ClientChatRepository { get; }
        IGenericRepository<DeliveryChat, int> DeliveryChatRepository { get; }

        IGenericRepository<EducationLevel, int> EducationLevelRepository { get; }
        IGenericRepository<Skill, int> SkillRepository { get; }
        IGenericRepository<Job, int> JobRepository { get; }
        IGenericRepository<ComplaintsِnAndSuggestions, int> ComplaintsِnAndSuggestionsRepository { get; }

        IGenericRepository<SavedJob, int> SavedJobRepository { get; }
        IGenericRepository<Language, int> LanguageRepository { get; }
        IGenericRepository<Proposal, int> ProposalRepository { get; }
        IGenericRepository<Review, int> ReviewRepository { get; }
        IAccountRepository AccountRepository { get; }


    }
}
