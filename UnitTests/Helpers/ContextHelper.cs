using Entity;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.Helpers
{
    public class ContextHelper
    {
        public static ProjectContext GetContext()
        {
            var options = new DbContextOptionsBuilder<ProjectContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            
            var context = new ProjectContext();

            return context;
        }
    }
}