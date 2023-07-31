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

        public AccountRepository(Context context)
        {
            _context = context;
        }


        

       public string GetQuestionByUserName(string userName)
       {
            ApplicationUser User=_context.Users.FirstOrDefault(usr=>usr.UserName==userName);

            if(User!=null)
            {
                IdentityUserRole<string> UserRole=_context.UserRoles.FirstOrDefault(usrRole => usrRole.UserId == User.Id);
                if (UserRole != null)
                {

                    IdentityRole<string> Role = _context.Roles.FirstOrDefault(role => role.Id == UserRole.RoleId);

                    if (Role.Name == "Delivery")
                    {
                        Delivery delivery = _context.Delivery.FirstOrDefault(delv => delv.Id == User.Id);

                        if (delivery != null)
                        {
                            return delivery.Question;

                        }

                    }
                    else if (Role.Name == "Client")
                    {
                        Client client = _context.Client.FirstOrDefault(client => client.Id == User.Id);

                        if (client != null)
                        {
                            return client.Question;

                        }
                    }
                    else if (Role.Name == "Admin")
                    {
                        Admin admin = _context.Admin.FirstOrDefault(adm => adm.Id == User.Id);

                        if (admin != null)
                        {
                            return admin.Question;

                        }
                    }
                    else if (Role.Name == "SubAdmin")
                    {
                        SubAdmin subAdmin = _context.SubAdmin.FirstOrDefault(sub => sub.Id == User.Id);

                        if (subAdmin != null)
                        {
                            return subAdmin.Question;

                        }

                    }
                }else
                {
                    return "Role doesn't exsist";
                }
                
            }
            return "لا يوجد حساب بهذا الاسم";
        }


    }
}
