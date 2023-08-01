using Microsoft.AspNetCore.Identity;
using TasleemDelivery.Data;
using TasleemDelivery.DTO;
using TasleemDelivery.Models;
using TasleemDelivery.Repository.Interfaces;

namespace TasleemDelivery.Repository.Repositories
{
    public class AccountRepository :IAccountRepository
    {
        Context _context;
        UserManager<ApplicationUser> _userManager;

        public AccountRepository(Context context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<string> ForgetPassAsync(ForgetPasswordDTO forgetPasswordDTO)
        {
           ApplicationUser user= _context.Users.FirstOrDefault(usr=>usr.UserName== forgetPasswordDTO.UserName);

            if(user !=null)
            {
                IdentityUserRole<string> userRole=_context.UserRoles.FirstOrDefault(usrRole => usrRole.UserId == user.Id);
                if(userRole !=null)
                {
                    IdentityRole<string> role=_context.Roles.FirstOrDefault(r => r.Id == userRole.RoleId);

                    if(role.Name=="Delivery")
                    {
                        Delivery delivery=_context.Delivery.FirstOrDefault(d=>d.Id ==user.Id);
                        if(forgetPasswordDTO.Answer == delivery.Answer)
                        {
                            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                            string newPssHash=passwordHasher.HashPassword(user, forgetPasswordDTO.NewPass);

                            user.PasswordHash = newPssHash;
                            var result=await _userManager.UpdateAsync(user);
                            return "Password Changed Successfully";
                        }
                        else
                        {
                            return "Wrong Answer";
                        }
                    }
                    else if (role.Name == "Client")
                    {
                        Client client=_context.Client.FirstOrDefault(c => c.Id == user.Id);
                        if(client !=null)
                        {
                            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                           string newPassHash=passwordHasher.HashPassword(user, forgetPasswordDTO.NewPass);

                            user.PasswordHash = newPassHash;
                            var result=await _userManager.UpdateAsync(user);

                            return "Password Changed Successfully";

                        }
                        else
                        {
                            return "Wrong Answer";
                        }
                    }
                    else if (role.Name == "Admin")
                    {
                        Admin admin = _context.Admin.FirstOrDefault(c => c.Id == user.Id);
                        if (admin != null)
                        {
                            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                            string newPassHash = passwordHasher.HashPassword(user, forgetPasswordDTO.NewPass);

                            user.PasswordHash = newPassHash;
                            var result =await _userManager.UpdateAsync(user);

                            return "Password Changed Successfully";

                        }
                        else
                        {
                            return "Wrong Answer";
                        }
                    }
                    else if(role.Name == "SubAdmin")
                    {
                        SubAdmin subAdmin = _context.SubAdmin.FirstOrDefault(c => c.Id == user.Id);
                        if (subAdmin != null)
                        {
                            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
                            string newPassHash = passwordHasher.HashPassword(user, forgetPasswordDTO.NewPass);

                            user.PasswordHash = newPassHash;
                            var result =await _userManager.UpdateAsync(user);

                            return "Password Changed Successfully";

                        }
                        else
                        {
                            return "Wrong Answer";
                        }
                    }
                    else
                    {
                        return "There is no exist role with that name";
                    }
                }
                return "User Doesn't have Role";
            }
            return "There's No User With This UserName";
        }

    }
}
