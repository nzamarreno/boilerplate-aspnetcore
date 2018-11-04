using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using training.Repositories;

namespace training.Tests.Helpers
{
    public class GetContext
    {
        public static TrainingContext ReturnContext()
        {
            var options = new DbContextOptionsBuilder<TrainingContext>()
                .UseInMemoryDatabase(databaseName: "master")
                .Options;

            return new TrainingContext(options);
        }
    }
}
