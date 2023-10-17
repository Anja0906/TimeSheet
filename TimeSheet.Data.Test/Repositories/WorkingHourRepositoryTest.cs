using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using TimeSheet.Data.Entities;
using TimeSheet.Data.Repositories;
using Xunit;

namespace TimeSheet.Data.Test.Repositories
{
    public class WorkingHourRepositoryTest
    {
        public readonly DbContextOptions<DataContext> dbContextOptions;
        public WorkingHourRepositoryTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "MyTimeSheetDb")
            .Options;
        }

        [Fact]
        public async Task WhenPostIsSavedThenItShouldInsertNewEntry()
        {
        }
    }
}