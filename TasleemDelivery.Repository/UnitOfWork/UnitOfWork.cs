using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Data;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.Interfaces;
using TasleemDelivery.Repository.Repositories;

namespace TasleemDelivery.Repository.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        Context _context;
        UserManager<ApplicationUser> _userManager;

        public UnitOfWork(Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager= userManager;
            BeginTransaction();
        }

        public void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }

        public void CommitChanges()
        {
            try
            {
                _context.SaveChanges();
                _context.Database.CurrentTransaction.Commit();
            }
            catch
            {
                _context.Database.CurrentTransaction.Rollback();
            }
        }

        public void BeginTransaction()
        {
            if (_context.Database.CurrentTransaction is null)
            {
                _context.Database.BeginTransaction();
            }
        }

    

        public IGenericRepository<Client,string> ClientRepository => new GenericRepository<Client,string>(_context);
        public IGenericRepository<Delivery, string> DeliveryRepository => new GenericRepository<Delivery, string>(_context);
        public IGenericRepository<Admin, string> AdminRepository => new GenericRepository<Admin, string>(_context);
        public IGenericRepository<SubAdmin, string> SubAdminRepository => new GenericRepository<SubAdmin, string>(_context);
        public IGenericRepository<Chat, int> ChatRepository => new GenericRepository<Chat, int>(_context);
        public IGenericRepository<Location, int> LocationRepository => new GenericRepository<Location, int>(_context);
        public IGenericRepository<EducationLevel, int> EducationLevelRepository => new GenericRepository<EducationLevel, int>(_context);
        public IGenericRepository<Skill, int> SkillRepository => new GenericRepository<Skill, int>(_context);
        public IGenericRepository<Proposal, int> ProposalRepository => new GenericRepository<Proposal, int>(_context);
        public IGenericRepository<Review, int> ReviewRepository => new GenericRepository<Review, int>(_context);
        public IGenericRepository<Language, int> LanguageRepository => new GenericRepository<Language, int>(_context);
        public IGenericRepository<Job, int> JobRepository => new GenericRepository<Job, int>(_context);
        public IGenericRepository<SavedJob, int> SavedJobRepository => new GenericRepository<SavedJob, int>(_context);
        public IAccountRepository AccountRepository => new AccountRepository(_context,_userManager);


    }
}
