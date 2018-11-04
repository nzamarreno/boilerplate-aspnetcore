namespace Boilerplate.Tests.Helpers
{
    using Boilerplate.Repositories;
    using Microsoft.EntityFrameworkCore;

    public class GetContext
    {
        public static DatabaseContext ReturnContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "master")
                .Options;

            return new DatabaseContext(options);
        }
    }
}
