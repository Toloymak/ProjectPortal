using Entity;
using Entity.Models;

namespace CoreLogic.RepositoryServices
{
    public class PageRepositoryService : BaseRepositoryService<Page>
    {
        public PageRepositoryService(ProjectContext dbContext)
            : base(dbContext)
        {
        }
    }
}