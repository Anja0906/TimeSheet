using Microsoft.EntityFrameworkCore;
using TimeSheet.Data.Entities;

namespace TimeSheet.Data.Test.Data
{
    public class TestDataContext : DataContext
    {
        public TestDataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
