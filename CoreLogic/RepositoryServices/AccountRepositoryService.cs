using Entity;
using Entity.Models;

namespace CoreLogic.RepositoryServices
{
    public class AccountRepositoryService : BaseRepositoryService<Account>
    {
        public AccountRepositoryService(ProjectContext dbContext)
            : base(dbContext)
        {
        }
    }
}