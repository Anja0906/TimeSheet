using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using TimeSheet.Core.Exceptions;
using TimeSheet.Data.Entities;
using TimeSheet.Data.Mappers;
using TimeSheet.Data.Repositories;
using TimeSheet.Data.Test.Data;
using TimeSheet.Data.Test.Setup;
using Xunit;

namespace TimeSheet.Data.Test.Repositories
{
    public class WorkingHourRepositoryTest
    {
        private TestDataContext dataContext;
        private IMapper mapper;
        private DbContextOptions<DataContext> dbContextOptions;
        private WorkingHourRepository workingHourRepository;
        private readonly WorkingHourRepositoryTestSetup _setup;

        public WorkingHourRepositoryTest()
        {
            _setup = new WorkingHourRepositoryTestSetup();
        }
        private void SeedData(string name)
        {
            dbContextOptions = new DbContextOptionsBuilder<DataContext>()
                                                    .UseInMemoryDatabase(databaseName: name)
                                                    .Options;
            dataContext = new TestDataContext(dbContextOptions);
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            mapper = configuration.CreateMapper();
            workingHourRepository = new WorkingHourRepository(mapper, dataContext);
            dataContext.Database.EnsureCreated();
            var categories = new List<Category>
            {
                new Category { Name = "Category 1" },
                new Category { Name = "Category 2" },
                new Category { Name = "Category 3" },
                new Category { Name = "Category 4" },
                new Category { Name = "Category 5" }
            };
            dataContext.Categories.AddRange(categories);
            var clients = new List<Client>
            {
                new Client { Name = "Client 1", Address = "123 Main St", City = "City A", PostalCode = "12345", CountryId = 1 },
                new Client { Name = "Client 2", Address = "456 Elm St", City = "City B", PostalCode = "67890", CountryId = 2 },
                new Client { Name = "Client 3", Address = "789 Oak St", City = "City C", PostalCode = "54321", CountryId = 3 },
                new Client { Name = "Client 4", Address = "101 Pine St", City = "City D", PostalCode = "98765", CountryId = 4 },
                new Client { Name = "Client 5", Address = "202 Cedar St", City = "City E", PostalCode = "45678", CountryId = 5 }
            };
            dataContext.Clients.AddRange(clients);
            var countries = new List<Country>
            {
                new Country { Name = "Category 1" },
                new Country { Name = "Category 2" },
                new Country { Name = "Category 3" },
                new Country { Name = "Category 4" },
                new Country { Name = "Category 5" }
            };
            dataContext.Countries.AddRange(countries);
            var hashedPass = "ea2f2a1f41999bf4ead83a5d19af7ff46a87dfb57e7a340dd49eee98b6f4a5de";
            var hashedSalt = "17b83Vj8SSbSmLbQ";
            var employees = new List<Emplyee>
            {
                new Emplyee { Name = "Employee 1", Username = "user1", Email = "user1@example.com", PasswordHash = hashedPass, Salt = hashedSalt, HoursPerWeek = 40, EmplyeeStatus = EmplyeeStatus.Active, Role = Role.Worker },
                new Emplyee { Name = "Employee 2", Username = "user2", Email = "user2@example.com", PasswordHash = hashedPass, Salt = hashedSalt, HoursPerWeek = 35, EmplyeeStatus = EmplyeeStatus.Active, Role = Role.Worker },
                new Emplyee { Name = "Employee 3", Username = "user3", Email = "user3@example.com", PasswordHash = hashedPass, Salt = hashedSalt, HoursPerWeek = 37, EmplyeeStatus = EmplyeeStatus.Active, Role = Role.Worker },
                new Emplyee { Name = "Employee 4", Username = "admin1", Email = "admin1@example.com", PasswordHash = hashedPass, Salt = hashedSalt, HoursPerWeek = 40, EmplyeeStatus = EmplyeeStatus.Active, Role = Role.Admin },
                new Emplyee { Name = "Employee 5", Username = "admin2", Email = "admin2@example.com", PasswordHash = hashedPass, Salt = hashedSalt, HoursPerWeek = 40, EmplyeeStatus = EmplyeeStatus.Active, Role = Role.Admin }
            };
            dataContext.Employees.AddRange(employees);
            var projects = new List<Project>
            {
                new Project { Name = "Project 1", Description = "Description 1", IsActive = true, Status = ProjectStatus.Active, LeaderId = 1, CategoryId = 1, ClientId = 1 },
                new Project { Name = "Project 2", Description = "Description 2", IsActive = true, Status = ProjectStatus.Active, LeaderId = 2, CategoryId = 2, ClientId = 2 },
                new Project { Name = "Project 3", Description = "Description 3", IsActive = false, Status = ProjectStatus.Active, LeaderId = 3, CategoryId = 3, ClientId = 3 },
                new Project { Name = "Project 4", Description = "Description 4", IsActive = true, Status = ProjectStatus.Active, LeaderId = 1, CategoryId = 1, ClientId = 2 },
                new Project { Name = "Project 5", Description = "Description 5", IsActive = true, Status = ProjectStatus.Active, LeaderId = 2, CategoryId = 2, ClientId = 1 }
            };
            dataContext.Projects.AddRange(projects);
            var workingHours = new List<WorkingHour>()
                {
                    new WorkingHour { Date = new DateTime(2023, 10, 1), Description = "Description 1", ProjectId = 1, CategoryId = 1, Time = 9, Overtime = 2, EmplyeeId = 2},
                    new WorkingHour { Date = new DateTime(2023, 10, 2), Description = "Description 2", ProjectId = 2, CategoryId = 2, Time = 3, Overtime = 0, EmplyeeId = 1},
                    new WorkingHour { Date = new DateTime(2023, 10, 3), Description = "Description 3", ProjectId = 2, CategoryId = 1, Time = 7, Overtime = 0, EmplyeeId = 1},
                    new WorkingHour { Date = new DateTime(2023, 10, 4), Description = "Description 4", ProjectId = 2, CategoryId = 1, Time = 8, Overtime = 1, EmplyeeId = 1},
                    new WorkingHour { Date = new DateTime(2023, 10, 5), Description = "Description 5", ProjectId = 2, CategoryId = 2, Time = 6, Overtime = 0, EmplyeeId = 1},
                };
            dataContext.WorkingHours.AddRange(workingHours);
            dataContext.SaveChanges();
        }

        [Fact]
        public async Task AddWorkingHour_ValidParameters_ShouldReturnValidObject()
        {
            SeedData("Test1");
            var workingHour = new WorkingHour(){Date = DateTime.Now, Description = "Test", ProjectId = 2, CategoryId = 1, Time = 9, Overtime = 1, EmplyeeId = 2};
            var mappedWorkingHour = mapper.Map<Core.Models.WorkingHour>(workingHour);
            var savedWorkingHour = await workingHourRepository.AddWorkingHour(2, mappedWorkingHour);
            Assert.Equal("Test", savedWorkingHour.Description);
        }
        [Fact]
        public void DeleteWorkingHour_ValidParameters_ShouldDelete()
        {
            SeedData("Test2");
            int workingHourId = 1;
            workingHourRepository.DeleteWorkingHour(workingHourId);
            Assert.Null(dataContext.WorkingHours.FirstOrDefault(wh => wh.Id == workingHourId));
        }

        [Fact]
        public void DeleteWorkingHour_InvalidParameters_ShouldThrowResouceNotFoundException()
        {
            SeedData("Test3");
            int workingHourId = 3454;
            var exception = Assert.Throws<ResourceNotFoundException>(() =>
            {
                workingHourRepository.DeleteWorkingHour(workingHourId);
            });
            Assert.Equal("WorkingHour with that id does not exist!", exception.Message);
        }
        [Fact]
        public async Task GetWorkingHourById_ValidParameters_ShouldReturnValidObject()
        {
            SeedData("Test4");
            int workingHourId = 1;
            var workingHour = await workingHourRepository.GetById(workingHourId);
            Assert.Equal("Description 1", workingHour.Description);
        }

        [Fact]
        public void GetWorkingHourById_InvalidParameters_ShouldThrowResouceNotFoundException()
        {
            SeedData("Test5");
            int workingHourId = 3454;
            var exception = Assert.Throws<ResourceNotFoundException>(() =>
            {
               var result = workingHourRepository.GetById(workingHourId);
            });
            Assert.Equal("WorkingHour with that id does not exist!", exception.Message);
        }

        [Fact]
        public async Task UpdateWorkingHour_ValidParameters_ShouldUpdate()
        {
            SeedData("Test6");
            var workingHourToUpdate = new Core.Models.WorkingHour() { Id = 1, Date = DateTime.Now, Description = "Test", ProjectId = 2, CategoryId = 1, Time = 9, Overtime = 1, EmplyeeId = 2 };
            var workingHour = await workingHourRepository.UpdateWorkingHour(workingHourToUpdate);
            Assert.Equal("Test", workingHour.Description);
        }

        [Fact]
        public void UpdateWorkingHour_InvalidParameters_ShouldThrowResouceNotFoundException()
        {
            SeedData("Test7");
            var workingHourToUpdate = new Core.Models.WorkingHour() { Id = 5678, Date = DateTime.Now, Description = "Test", ProjectId = 2, CategoryId = 1, Time = 9, Overtime = 1, EmplyeeId = 2 };
            var exception = Assert.Throws<ResourceNotFoundException>(() =>
            {
                var result = workingHourRepository.UpdateWorkingHour(workingHourToUpdate);
            });
            Assert.Equal("WorkingHour with that id does not exist!", exception.Message);
        }

        [Fact]
        public async Task GetAllWorkingHours_ValidParameters_ShouldReturnAll()
        {
            SeedData("Test8");
            var result = await workingHourRepository.GetAll();
            Assert.Equal(dataContext.WorkingHours.Count(), result.Count);
        }
        [Fact]
        public async Task GetCalendar_ValidParameters_ShouldReturnAll()
        {
            SeedData("Test9");
            int workerId = 1;
            DateTime startDate = new DateTime(2023, 10, 1);
            DateTime endDate = new DateTime(2023, 10, 30);
            var result = await workingHourRepository.GetCalendar(workerId, startDate, endDate);
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
        }
        [Fact]
        public async Task GetCalendar_ValidParameters_ReturnsEmptyDictionary()
        {
            SeedData("Test10");
            int workerId = 9;
            DateTime startDate = new DateTime(2023, 3, 1);
            DateTime endDate = new DateTime(2023, 3, 30);
            var result = await workingHourRepository.GetCalendar(workerId, startDate, endDate);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task Report_ValidInput_ShouldReturnFilteredData()
        {
            SeedData("Test11");
            var reportRequest = new Core.Models.ReportRequest { TeamMemberId = 1, ClientId = 2, ProjectId = 2, CategoryId = 2, From = DateTime.Parse("2023-10-01"), To = DateTime.Parse("2023-10-30") };
            var result = await workingHourRepository.Report(reportRequest);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task Report_InvalidInput_ShouldReturnEmpty()
        {
            SeedData("Test12");
            var reportRequest = new Core.Models.ReportRequest { TeamMemberId = 12, ClientId = 45, ProjectId = 5, CategoryId = 8, From = DateTime.Parse("2023-01-01"), To = DateTime.Parse("2023-01-30") };
            var result = await workingHourRepository.Report(reportRequest);
            Assert.NotNull(result);
            Assert.Empty(result);
        }

    }
}