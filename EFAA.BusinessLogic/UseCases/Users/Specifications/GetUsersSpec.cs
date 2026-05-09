using Ardalis.Specification;
using EFAA.Entities;

namespace EFAA.BusinessLogic.UseCases.Users.Specifications;

public class GetUsersSpec : Specification<User>
{
    public GetUsersSpec()
    {
        Query.Include(u => u.Rol);
    }
}