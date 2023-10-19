using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Data.Entities;
using TimeSheet.Data.Mappers;
using TimeSheet.Data.Repositories;
using TimeSheet.Data.Test.Data;

namespace TimeSheet.Data.Test.Setup
{
    public class WorkingHourRepositoryTestSetup
    {
        public TestDataContext DataContext { get; set; }
        public IMapper Mapper { get; set; }
        public WorkingHourRepository WorkingHourRepository { get; private set; }

        private DbContextOptions<DataContext> dbContextOptions;
        public WorkingHourRepositoryTestSetup()
        {
            InitializeDataContext("TestDb");
        }
        public void InitializeDataContext(string dbName)
        {
             dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            DataContext = new TestDataContext(dbContextOptions);

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            Mapper = configuration.CreateMapper();
            WorkingHourRepository = new WorkingHourRepository(Mapper, DataContext);
            DataContext.Database.EnsureCreated();
        }
    }
}
