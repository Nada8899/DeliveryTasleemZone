using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TasleemDelivery.Data;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.Interfaces;

namespace TasleemDelivery.Repository.Repositories
{
    public class AccountRepository :IAccountRepository
    {


        Context _context;
        private readonly UserManager<ApplicationUser> userManager;
     



        public AccountRepository(Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
      

       
        }


        public void AddDelivery(Delivery delivery)
        {
            _context.Delivery.Add(delivery);

        }

        public void AddAdmin(Admin admin )
        {
            _context.Admin.Add(admin);

        }

        public void AddSubAdmin(SubAdmin SubAdmin)
        {
            _context.SubAdmin.Add(SubAdmin);

        }
        public void AddClient(Client client)
        {
            _context.Client.Add(client);

        }
    }
}
