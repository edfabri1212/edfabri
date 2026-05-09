using Ardalis.Specification;
using EFAA.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFAA.BusinessLogic.UseCases.Users.Specifications
{
    public class GetUserAuthenticatedSpec : Specification<User>
    {
        public GetUserAuthenticatedSpec(string userName, string password)
        {
            Query.Where(u => 
            u.UserNickname == userName 
            && u.UserPassword == password
            && u.UserStatus == true
            );

            Query.Include(u => u.Rol);
        }
    }
}
